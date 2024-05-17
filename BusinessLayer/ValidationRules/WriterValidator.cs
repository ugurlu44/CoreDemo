using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator :AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar ad soyad kısmı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalıdır")
            .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
            .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
            .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
            .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir"); ;
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.WriterPassword).WithMessage("Aynı şifreyi girdiğinizden emin olun");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter girin");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("50 karakterden fazla giriş yapılamaz");
            //RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Resim alan boş bırakılamaz");
            
            
        }
    }
}
