using FluentValidation;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Resquest.Dtos.Validators
{
    public class AddMember_Validate : AbstractValidator<AddMember_Request>
    {
        public AddMember_Validate()
        {
            RuleFor(x => x.IdProject)
                .NotEmpty().WithMessage("Project id is required!");
            RuleFor(x => x.UserNames)
                .NotEmpty().WithMessage("UserNames is required!");
        }
    }
}
