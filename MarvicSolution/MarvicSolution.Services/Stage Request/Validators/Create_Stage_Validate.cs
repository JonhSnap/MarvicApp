using FluentValidation;
using MarvicSolution.Services.Stage_Request.Requests;

namespace MarvicSolution.Services.Stage_Request.Validators
{
    public class Create_Stage_Validate : AbstractValidator<Create_Stage_Request>
    {
        public Create_Stage_Validate()
        {
            RuleFor(x => x.Id_Creator)
                .NotEmpty().WithMessage("Id_Updator id is required!");
            RuleFor(x => x.Stage_Name)
               .NotEmpty().WithMessage("Stage_Name id is required!");
            RuleFor(x => x.Id_Project)
               .NotEmpty().WithMessage("Id_Project id is required!");
        }
    }
}
