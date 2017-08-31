using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using FluentAssertions;
using Moq;
using TestCase.Core.Command;
using TestCase.Service.Membership.Registration;
using TestCase.Repository.Membership.Contracts;
using TestCase.Model.Membership;
using TestCase.Service.Membership.Lookups.Contracts;
using AutoMapper;
using System.Threading.Tasks;

namespace TestCase.Service.Tests.Membership
{
    [Trait("Category", "Membership")]
    [Trait("Membership", "RegisterUser")]
    public class RegisterUserCommandHandlerTests
    {
        [Fact(DisplayName = "Should register user when register command is valid.")]
        public void Should_RegisterUser_When_CommandIsValid()
        {
            var userRepositoryMock = new Mock<IUserRepository>();

            var roleLookupMock = new Mock<IRoleLookup>();
            roleLookupMock.Setup(r => r.GetUserRoleAsync()).ReturnsAsync(new Role());

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<RegisterUserCommand, User>(It.IsAny<RegisterUserCommand>())).Returns(new User());

            var target = new RegisterUserCommandHandler(userRepositoryMock.Object, roleLookupMock.Object, mapperMock.Object);

            var command = new RegisterUserCommand();

            Func<Task> func = async () => await target.HandleAsync(command);
            func.ShouldNotThrow(); //Should not throw any kind of exception
        }

        [Fact(DisplayName = "Should throw exception when register command is null.")]
        public void Should_ThrowException_When_CommandIsNull()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var roleLookupMock = new Mock<IRoleLookup>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<RegisterUserCommand, User>(It.IsAny<RegisterUserCommand>())).Returns((User)null);

            var target = new RegisterUserCommandHandler(userRepositoryMock.Object, roleLookupMock.Object, mapperMock.Object);

            var command = new RegisterUserCommand();

            Func<Task> func = async () => await target.HandleAsync(command);
            func.ShouldThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Should throw exception when user exists.")]
        public void Should_ThrowException_When_UserExists()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.RegisterAsync(It.IsAny<User>(), It.IsAny<string>())).ThrowsAsync(new ArgumentException("user exists"));

            var roleLookupMock = new Mock<IRoleLookup>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<RegisterUserCommand, User>(It.IsAny<RegisterUserCommand>())).Returns((User)null);

            var target = new RegisterUserCommandHandler(userRepositoryMock.Object, roleLookupMock.Object, mapperMock.Object);

            var command = new RegisterUserCommand();

            Func<Task> func = async () => await target.HandleAsync(command);
            func.ShouldThrow<Exception>();
        }

        [Fact(DisplayName = "Should throw exception when password is null or empty.")]
        public void Should_ThrowException_When_PasswordIsNullOrEmpty()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.RegisterAsync(It.IsAny<User>(), It.IsAny<string>())).ThrowsAsync(new ArgumentException("password is empty."));

            var roleLookupMock = new Mock<IRoleLookup>();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<RegisterUserCommand, User>(It.IsAny<RegisterUserCommand>())).Returns((User)null);

            var target = new RegisterUserCommandHandler(userRepositoryMock.Object, roleLookupMock.Object, mapperMock.Object);

            var command = new RegisterUserCommand();

            Func<Task> func = async () => await target.HandleAsync(command);
            func.ShouldThrow<Exception>();
        }
    }
}
