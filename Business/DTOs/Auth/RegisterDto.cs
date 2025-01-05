using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.DTOs.Auth
{
    public record RegisterDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterValidation:AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Name bos ola bilmez")
                .NotNull().WithMessage("Name null ola bilmez")
                .MinimumLength(3).WithMessage("Name-in uzunlugu min 3 olmalidi")
                .MaximumLength(20);
            RuleFor(x=>x.Username)
                .NotEmpty().WithMessage("Name bos ola bilmez")
                .NotNull().WithMessage("Name null ola bilmez")
                .MinimumLength(3).WithMessage("Name-in uzunlugu min 3 olmalidi")
                .MaximumLength(20);
            RuleFor(x => x.Email)
     .NotEmpty()
     .NotNull()
     .Must(x =>
     {
         Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail\.com$");
         var match = regex.Match(x);
         return match.Success;
     }).WithMessage("duzgun ver");

            RuleFor(x => x.Password)
               .NotEmpty()
                .WithMessage("bos ola bilmez")
                .NotNull()
                .WithMessage("bos ola bilmez")
                .MinimumLength(8)
                .WithMessage("name uzunlugu min 8 max ola biler");
            RuleFor(x => x)
               .Must(x => x.Password == x.ConfirmPassword);
        }
    }
}
