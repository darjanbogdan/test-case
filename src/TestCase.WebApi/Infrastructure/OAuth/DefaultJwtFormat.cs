
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace TestCase.WebApi.Infrastructure.OAuth
{
    /// <summary>
    /// Default JWT format.
    /// </summary>
    /// <seealso cref="Microsoft.Owin.Security.ISecureDataFormat{Microsoft.Owin.Security.AuthenticationTicket}" />
    public class DefaultJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private readonly string issuer;
        private readonly string audience;
        private readonly byte[] audienceSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultJwtFormat"/> class.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="audienceSecret">The secret.</param>
        public DefaultJwtFormat(string issuer, string audience, string audienceSecret)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.audienceSecret = Encoding.UTF8.GetBytes(audienceSecret);
        }

        /// <summary>
        /// Protects the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            if (!issued.HasValue || !expires.HasValue)
            {
                return null;
            }

            var securityKey = new SymmetricSecurityKey(this.audienceSecret);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(this.issuer, this.audience, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        /// <summary>
        /// Unprotects the specified protected text.
        /// </summary>
        /// <param name="protectedText">The protected text.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public AuthenticationTicket Unprotect(string protectedText)
        {
            if (String.IsNullOrWhiteSpace(protectedText))
            {
                throw new ArgumentNullException(nameof(protectedText));
            }

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(protectedText) as JwtSecurityToken;
            if (token == null)
            {
                throw new ArgumentException(nameof(protectedText), "Invalid JWT Token");
            }

            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(this.audienceSecret),
                ValidAudiences = new[] { this.audience},
                ValidateIssuer = true,
                ValidIssuer = this.issuer,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true
            };

            const string IssuedAtClaimName = "iat";
            const string ExpiryClaimName = "exp";

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken = null;

            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(protectedText, validationParameters, out validatedToken);
            var claimsIdentity = (ClaimsIdentity)claimsPrincipal.Identity;

            var authenticationExtra = new AuthenticationProperties(new Dictionary<string, string>());
            if (claimsIdentity.Claims.Any(c => c.Type == ExpiryClaimName))
            {
                string expiryClaim = claimsIdentity.Claims.Where(c => c.Type == ExpiryClaimName).Select(c => c.Value).Single();
                authenticationExtra.ExpiresUtc = epoch.AddSeconds(Convert.ToInt64(expiryClaim, CultureInfo.InvariantCulture));
            }

            if (claimsIdentity.Claims.Any(c => c.Type == IssuedAtClaimName))
            {
                string issued = claimsIdentity.Claims.Where(c => c.Type == IssuedAtClaimName).Select(c => c.Value).Single();
                authenticationExtra.IssuedUtc = epoch.AddSeconds(Convert.ToInt64(issued, CultureInfo.InvariantCulture));
            }

            var returnedIdentity = new ClaimsIdentity(claimsIdentity.Claims, "JWT");

            return new AuthenticationTicket(returnedIdentity, authenticationExtra);
        }
    }
}