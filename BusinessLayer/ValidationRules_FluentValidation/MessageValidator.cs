using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLayer.ValidationRules_FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(message => message.MessageSenderMail)
            .NotEmpty().WithMessage("Gönderen alanı boş olamaz.")
            .MaximumLength(100).WithMessage("Gönderen alanı en fazla 100 karakter olabilir.");

            RuleFor(message => message.MessageReceiverMail)
                .NotEmpty().WithMessage("Alıcı alanı boş olamaz.")
                .MaximumLength(100).WithMessage("Alıcı alanı en fazla 100 karakter olabilir.");

            RuleFor(message => message.MessageSubject)
                .NotEmpty().WithMessage("Konu alanı boş olamaz.")
                .MaximumLength(200).WithMessage("Konu alanı en fazla 200 karakter olabilir.");

            RuleFor(message => message.MessageContent)
                .NotEmpty().WithMessage("Mesaj içeriği boş olamaz.")
                .MaximumLength(1000).WithMessage("Mesaj içeriği en fazla 1000 karakter olabilir.");

            RuleFor(message => message.MessageDate)
                .NotEmpty().WithMessage("Mesaj tarihi boş olamaz.");
                
        }
    }
}
