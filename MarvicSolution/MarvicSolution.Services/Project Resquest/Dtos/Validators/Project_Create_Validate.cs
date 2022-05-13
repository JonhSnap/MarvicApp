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
    public class Project_Create_Validate : AbstractValidator<Project_CreateRequest>
    {
        public Project_Create_Validate()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project name is required!");
            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Project key is required!");
            RuleFor(x => x.Access)
                .NotEmpty().WithMessage("Project access is required!");
            RuleFor(x => x.Id_Lead)
                .NotEmpty().WithMessage("Id Creator is required!");
            RuleFor(x => x.DateStarted)
                .NotEmpty().WithMessage("Date started is required!");
            RuleFor(x => x.DateEnd)
                .NotEmpty().WithMessage("Date end is required!");
        }
    }
}
