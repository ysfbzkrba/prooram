using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.Validators
{
    using FluentValidation;
    using prooram.Application.CategoryMediatr.Commands;
    using prooram.Application.Common.Interfaces;

    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {

        //private readonly IApplicationDbContext _context;
        //IApplicationDbContext context
        public CreateCategoryValidator()
        {
            RuleFor(rule => rule.CategoryName)
                .Length(2, 100).WithMessage("CategoryName contains 100 chars maximum.")
                //.MaximumLength(100).WithMessage("CategoryName contains 100 chars maximum.")
                .NotEmpty().WithMessage("CategoryName can not be null.");
                //.Must(MustBeUnique).WithMessage("this category already exists.");
            
        }


        //private bool MustBeUnique(string CategoryName)
        //{
        //    if (!string.IsNullOrWhiteSpace(CategoryName))
        //    {
        //        var result = _context.Categories.Any(x => x.CategoryName == CategoryName);
        //        return result;
        //    }
        //    return false;
        //}
    }
}
