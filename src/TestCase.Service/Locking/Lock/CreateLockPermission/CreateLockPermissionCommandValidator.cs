using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Repository.Membership.Contracts;
using TestCase.Service.Membership.Lookups.Contracts;
using TestCase.Service.Security.Lookups.Contracts;
using TestCase.Service.Validation;

namespace TestCase.Service.Locking.Lock.CreateLockPermission
{
    /// <summary>
    /// Create lock permission command validator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Validation.BaseModelValidator{TestCase.Service.Locking.Lock.CreateLockPermission.CreateLockPermissionCommand}" />
    public class CreateLockPermissionCommandValidator : BaseModelValidator<CreateLockPermissionCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleLookup roleLookup;
        private readonly IPermissionLookup permissionLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLockPermissionCommandValidator" /> class.
        /// </summary>
        /// <param name="roleLookup">The role lookup.</param>
        /// <param name="permissionLookup">The permission lookup.</param>
        public CreateLockPermissionCommandValidator(
            IUserRepository userRepository,
            IRoleLookup roleLookup, 
            IPermissionLookup permissionLookup)
        {
            this.userRepository = userRepository;
            this.roleLookup = roleLookup;
            this.permissionLookup = permissionLookup;

            RuleFor(model => model.LockId)
                .NotEmpty().WithMessage("LockId is required");
            RuleFor(model => model.Permission)
                .NotEmpty().WithMessage("Permission is required");
            RuleFor(model => model.UserName)
                .Must((model, field) =>
                {
                    if (String.IsNullOrEmpty(model.Role))
                    {
                        return !String.IsNullOrEmpty(field);
                    }
                    return true;
                }).WithMessage("Either User or Role is required");
                
            RuleFor(model => model.Role)
                .Must((model, field) =>
                {
                    if (String.IsNullOrEmpty(model.UserName))
                    {
                        return !String.IsNullOrEmpty(field);
                    }
                    return true;
                }).WithMessage("Either Roles or User is required");
        }

        public override async Task ValidateAsync(CreateLockPermissionCommand model)
        {
            await base.ValidateAsync(model);

            var permissionExists = await this.permissionLookup.GetAsync(model.Permission) != null;
            if (!permissionExists)
            {
                throw new ValidationException("Permission doesn't exist.");
            }

            if (!String.IsNullOrEmpty(model.UserName))
            {
                var userExists = await this.userRepository.GetAsync(model.UserName) != null;
                if (!userExists)
                {
                    throw new ValidationException("User doesn't exist.");
                }
            }

            if (!String.IsNullOrEmpty(model.Role))
            {
                var roleExists = await this.permissionLookup.GetAsync(model.Role) != null;
                if (!roleExists)
                {
                    throw new ValidationException("Role doesn't exist.");
                }
            }
        }
    }
}
