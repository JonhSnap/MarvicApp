using FluentValidation;
using MarvicSolution.Services.Stage_Request.Requests;

namespace MarvicSolution.Services.Stage_Request.Validators
{
    public class Update_Stage_Validate : AbstractValidator<Update_Stage_Request>
    {
        public Update_Stage_Validate()
        {
            RuleFor(x => x.Stage_Name)
                .NotEmpty().WithMessage("Stage_Name id is required!");
            RuleFor(x => x.Id_Updator)
               .NotEmpty().WithMessage("Stage_Name id is required!");
        }
    }
}
