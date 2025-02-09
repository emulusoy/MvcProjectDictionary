using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu Alani Bos Gecemezsiniz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Bu Alani Bos Gecemezsiniz!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter olmali!");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("30 Karakterden fazla giris yapamazsiniz!");
            
        }
    }
}
