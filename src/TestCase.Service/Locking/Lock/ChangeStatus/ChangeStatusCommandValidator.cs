using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Repository.Locking.Contracts;
using TestCase.Service.Validation;

namespace TestCase.Service.Locking.Lock.ChangeStatus
{
    /// <summary>
    /// Change status validator.
    /// </summary>
    /// <seealso cref="TestCase.Service.Validation.BaseModelValidator{TestCase.Service.Locking.Lock.ChangeStatus.ChangeStatusCommand}" />
    public class ChangeStatusCommandValidator : BaseModelValidator<ChangeStatusCommand>
    {
        private readonly ILockRepository lockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStatusCommandValidator" /> class.
        /// </summary>
        /// <param name="lockRepository">The lock repository.</param>
        public ChangeStatusCommandValidator(ILockRepository lockRepository)
        {
            this.lockRepository = lockRepository;

            RuleFor(model => model.UserId)
                .NotEmpty().WithMessage("UserId is required.");
            RuleFor(model => model.LockId)
                .NotEmpty().WithMessage("LockId is required");
        }

        /// <summary>
        /// Asynchronously validates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public override async Task ValidateAsync(ChangeStatusCommand model)
        {
            await base.ValidateAsync(model);

            var existingLock = await this.lockRepository.GetLockAsync(model.LockId);
            if (existingLock == null)
            {
                throw new ArgumentException("Lock not found."); //Implement custom exception, this should return 404 status code
            }
        }
    }
}
