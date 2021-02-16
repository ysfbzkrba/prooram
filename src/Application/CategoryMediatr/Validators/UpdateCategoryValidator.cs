using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.Validators
{
    using FluentValidation;
    using MediatR;
    using prooram.Application.CategoryMediatr.Commands;

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(rule => rule.Id)
                .NotNull().WithMessage("Id can not be null.")
                .NotEmpty().WithMessage("Id can not be empty.");

            RuleFor(rule => rule.CategoryName)
                .Length(2, 100).WithMessage("CategoryName contains 100 chars maximum.")
                .NotEmpty().WithMessage("CategoryName can not be null.");
        }
    }
}
