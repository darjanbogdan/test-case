using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Service.Membership.Registration;
using Xunit;

namespace TestCase.Service.Tests.Membership
{
    [Trait("Category", "Membership")]
    [Trait("Membership", "RegisterUser")]
    public class RegisterUserCommandValidatorTests
    {
        [Fact(DisplayName = "Should register user validation pass when command is valid.")]
        public void Should_RegisterUserValidationPass_When_CommandIsValid()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = "test@test.to",
                Password = "testpassword",
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldNotThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when user name not exists.")]
        public void Should_RegisterUserValidationFail_When_UserNameNotExists()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = String.Empty,
                Email = "test@test.to",
                Password = "testpassword",
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when email not exists.")]
        public void Should_RegisterUserValidationFail_When_EmailNotExists()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = String.Empty,
                Password = "testpassword",
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when email is not valid.")]
        public void Should_RegisterUserValidationFail_When_EmailIsNotValid()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = "invalidemail",
                Password = "testpassword",
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when email is larger than 256 chars.")]
        public void Should_RegisterUserValidationFail_When_EmailIsTooLarge()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = new string('e', 250) + "@te.com", //256 chars total
                Password = "testpassword",
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when password not exist.")]
        public void Should_RegisterUserValidationFail_When_PasswordNotExists()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = "test@email.com",
                Password = String.Empty,
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when password is larger than 100 chars.")]
        public void Should_RegisterUserValidationFail_When_PasswordIsTooLarge()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = "test@email.com",
                Password = new string('p', 101),
                ConfirmPassword = "testpassword"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            f.ShouldThrow<ValidationException>();
        }

        [Fact(DisplayName = "Should register user validation fail when confirm password is not correct.")]
        public void Should_RegisterUserValidationFail_When_ConfirmPasswordIsNotCorrect()
        {
            var registerUserValidator = new RegisterUserCommandValidator();

            var validModel = new RegisterUserCommand
            {
                UserName = "testusername",
                Email = "test@email.com",
                Password = "testpassword",
                ConfirmPassword = "testpasswordwrong"
            };

            Func<Task> f = async () => await registerUserValidator.ValidateAsync(validModel);
            var a = f.ShouldThrow<ValidationException>();
        }
    }
}
