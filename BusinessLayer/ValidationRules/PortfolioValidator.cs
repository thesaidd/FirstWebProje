using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator :AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("AD BOŞ OLAMAZ");
            RuleFor(x => x.ImageuUrl).NotEmpty().WithMessage("URL1 BOŞ OLAMAZ");
            RuleFor(x => x.ImageuUrl2).NotEmpty().WithMessage("URL2 BOŞ OLAMAZ");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("PROJE BOŞ OLAMAZ");
            RuleFor(x => x.Name).MinimumLength(7).WithMessage("PROJE BOŞ OLAMAZ");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("PROJE BOŞ OLAMAZ");
        }
    }
}
