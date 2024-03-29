﻿using FluentValidation;
using MarvicSolution.Services.System.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Validators
{
    public class Register_Validate : AbstractValidator<Register_Request>
    {
        public Register_Validate()
        {
            RuleFor(x=>x.FullName)
                .NotEmpty().WithMessage("Full name is required!");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .Matches(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?").WithMessage("Invalid email!");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required!");
        }
    }
}
