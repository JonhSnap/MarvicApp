﻿using FluentValidation;
using MarvicSolution.Services.Sprint_Request.Requests;

namespace MarvicSolution.Services.Sprint_Request.Validators
{
    public class Update_Sprint_Validate : AbstractValidator<Update_Sprint_Request>
    {
        public Update_Sprint_Validate()
        {
            RuleFor(x => x.Id_Project)
                .NotEmpty().WithMessage("Id_Project id is required!");
            RuleFor(x => x.Sprint_Name)
               .NotEmpty().WithMessage("Sprint_Name id is required!");
            RuleFor(x => x.Id_Creator)
               .NotEmpty().WithMessage("Creator id is required!");
            RuleFor(x => x.Start_Date)
               .NotEmpty().WithMessage("Start_Date id is required!");
            RuleFor(x => x.End_Date)
               .NotEmpty().WithMessage("End_Date id is required!");
        }
    }
}
