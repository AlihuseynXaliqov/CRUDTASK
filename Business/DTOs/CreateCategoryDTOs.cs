using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.DTOs
{
    public class CreateCategoryDTOs
    {
        public string Name { get; set; }
    }
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTOs>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name bos ola bilmez")
                .NotNull().WithMessage("Name null ola bilmez")
                .MinimumLength(3).WithMessage("Name-in uzunlugu min 3 ola biler")
                .MaximumLength(20).WithMessage("Name-in uzunlugu max 20 ola biler")
                ;
        }
    }
}
