using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Required field to be filled");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Required field to be filled");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Required field to be filled");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Required field to be filled");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Required field to be filled");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Required field to be filled");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En az 2 karakter olmali!");
            RuleFor(x => x.WriterSurname).MaximumLength(30).WithMessage("30 Karakterden fazla giris yapamazsiniz!");
        }
    }
}
