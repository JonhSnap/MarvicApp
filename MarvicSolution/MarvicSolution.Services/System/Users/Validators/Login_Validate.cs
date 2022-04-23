using FluentValidation;
using MarvicSolution.Services.System.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Validators
{
    public class Login_Validate : AbstractValidator<Login_Request>
    {
        public Login_Validate()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!");
        }
    }
}
