using FluentValidation;
using MarvicSolution.Services.System.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Validators
{
    public class Get_User_Validate : AbstractValidator<Get_User_Request>
    {
        public Get_User_Validate()
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("User id is required!");
        }
    }
}
