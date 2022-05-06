using FluentValidation;
using MarvicSolution.Services.Label_Request.Requests;

namespace MarvicSolution.Services.Label_Request.Validators
{
    public class Update_Label_Validate : AbstractValidator<Update_Label_Request>
    {
        public Update_Label_Validate()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name id is required!");
            RuleFor(x => x.Id_Updator)
               .NotEmpty().WithMessage("Id_Updator is required!");
        }
    }
}
