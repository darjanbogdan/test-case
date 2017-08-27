using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;

namespace TestCase.WebApi.Infrastructure.Security
{
    /// <summary>
    /// Default JWT format.
    /// </summary>
    /// <seealso cref="Microsoft.Owin.Security.ISecureDataFormat{Microsoft.Owin.Security.AuthenticationTicket}" />
    public class DefaultJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string issuer;
        private readonly string audience;
        private readonly string audienceSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultJwtFormat"/> class.
        /// </summary>
        /// <param name="issuer">The issuer.</param>
        /// <param name="audienceSecret">The secret.</param>
        public DefaultJwtFormat(string issuer, string audience, string audienceSecret)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.audienceSecret = audienceSecret;
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
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(audienceSecret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(signingCredentials);

            var utcNow = DateTimeOffset.UtcNow;
            var payload = new JwtPayload(data.Identity.Claims)
            {
                { "iss", issuer },
                { "aud", audience },
                { "iat", data.Properties.IssuedUtc.GetValueOrDefault(utcNow).UtcDateTime },
                { "exp", data.Properties.ExpiresUtc.GetValueOrDefault(utcNow.AddHours(2)).UtcDateTime }
            };
            
            var token = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();
            var serializedToken = handler.WriteToken(token);
            return serializedToken;
        }

        /// <summary>
        /// Unprotects the specified protected text.
        /// </summary>
        /// <param name="protectedText">The protected text.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}