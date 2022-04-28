using FluentValidation;
using MarvicSolution.Services.System.Users.Requests;
using MarvicSolution.Services.System.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Validators
{
    public class Login_Validate : AbstractValidator<Login_Request>
    {
        private readonly IUser_Service _userService;
        public Login_Validate(IUser_Service userService)
        {
            _userService = userService;

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!");
            RuleFor(x => x.UserName).NotNull().WithMessage("Please Enter 'CountryCode'");
        }
    }
}
