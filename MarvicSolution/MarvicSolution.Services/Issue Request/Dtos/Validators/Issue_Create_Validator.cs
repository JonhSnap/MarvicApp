using FluentValidation;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Validators
{
    public class Issue_Create_Validator : AbstractValidator<Issue_CreateRequest>
    {
        public Issue_Create_Validator()
        {
            RuleFor(x=>x.Id_Project)
                .NotEmpty().WithMessage("Id Project í required!");

            RuleFor(x => x.Id_IssueType)
                .NotEmpty().WithMessage("Id Project is required!");
            RuleFor(x => x.Id_Stage)
                .NotEmpty().WithMessage("Id Project is required!");
            
            RuleFor(x => x.Summary)
                .NotEmpty().WithMessage("Id Project is required!");
        }
    }
}
