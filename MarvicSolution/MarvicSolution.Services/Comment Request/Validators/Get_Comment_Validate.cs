using FluentValidation;
using MarvicSolution.Services.Comment_Request.Request;

namespace MarvicSolution.Services.Comment_Request.Validators
{
    class Get_Comment_Validate: AbstractValidator<Get_Comment_Request>
    {
        public Get_Comment_Validate()
        {
            RuleFor(x => x.Id_Issue)
                .NotEmpty().WithMessage("Id_Issue id is required!");
        }
    }
}
