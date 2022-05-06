using FluentValidation;
using MarvicSolution.Services.Label_Request.Requests;

namespace MarvicSolution.Services.Label_Request.Validators
{
    public class Create_Label_Validate : AbstractValidator<Create_Label_Request>
    {
        public Create_Label_Validate()
        {
            RuleFor(x => x.Id_Project)
                .NotEmpty().WithMessage("Id_Project id is required!");
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name id is required!");
            RuleFor(x => x.Id_Creator)
               .NotEmpty().WithMessage("Id_Creator is required!");
        }
    }
}
