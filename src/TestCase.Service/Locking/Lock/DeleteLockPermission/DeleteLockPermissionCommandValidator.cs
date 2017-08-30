using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Validation;

namespace TestCase.Service.Locking.Lock.DeleteLockPermission
{
    /// <summary>
    /// Delete lock permission command validator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Validation.BaseModelValidator{TestCase.Service.Locking.Lock.DeleteLockPermission.DeleteLockPermissionCommand}" />
    public class DeleteLockPermissionCommandValidator : BaseModelValidator<DeleteLockPermissionCommand>
    {
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLockPermissionCommandValidator"/> class.
        /// </summary>
        public DeleteLockPermissionCommandValidator(ILockRepository lockRepository)
        {
            RuleFor(model => model.LockPermissionId)
                .NotEmpty().WithMessage("LockPermissionId is required.");
            RuleFor(model => model.LockId)
                .NotEmpty().WithMessage("LockId is required.");
            this.lockRepository = lockRepository;
        }

        /// <summary>
        /// Asynchronously validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public override async Task ValidateAsync(DeleteLockPermissionCommand model)
        {
            await base.ValidateAsync(model);

            var existingPolicy = await this.lockRepository.GetLockPermissionAsync(model.LockPermissionId);
            if (existingPolicy == null)
            {
                throw new ValidationException("LockPermission doesn't exist");
            }
        }
    }
}
