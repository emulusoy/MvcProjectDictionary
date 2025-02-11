using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.ContactUsername)
           .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
           .MaximumLength(30).WithMessage("Kullanıcı adı en fazla 30 karakter olabilir.");

            RuleFor(contact => contact.ContactMail)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(50).WithMessage("E-posta adresi en fazla 50 karakter olabilir.");

            RuleFor(contact => contact.ContactSubject)
                .NotEmpty().WithMessage("Konu boş olamaz.")
                .MaximumLength(50).WithMessage("Konu en fazla 50 karakter olabilir.");

            RuleFor(contact => contact.ContactMessage)
                .NotEmpty().WithMessage("Mesaj boş olamaz.")
                .MaximumLength(int.MaxValue).WithMessage("Mesaj çok uzun.");
        }
    }
}
