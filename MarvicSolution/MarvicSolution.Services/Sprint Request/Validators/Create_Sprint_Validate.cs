using FluentValidation;
using MarvicSolution.Services.Sprint_Request.Requests;

namespace MarvicSolution.Services.Sprint_Request.Validators
{
    public class Create_Sprint_Validate : AbstractValidator<Create_Sprint_Request>
    {
        public Create_Sprint_Validate()
        {
            RuleFor(x => x.Id_Project)
                .NotEmpty().WithMessage("Id_Project id is required!");
            RuleFor(x => x.Sprint_Name)
               .NotEmpty().WithMessage("Sprint_Name id is required!");
            RuleFor(x => x.Creator)
               .NotEmpty().WithMessage("Creator id is required!");
        }
    }
}
