﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator() 
        { 
            RuleFor(x => x.CategryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz!"); 
            RuleFor(x => x.CategryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.CategryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayınız.");
        }
    }
}
