using FluentValidation;
using MarvicSolution.Services.Comment_Request.Requests;

namespace MarvicSolution.Services.Comment_Request.Validators
{
    class Edit_Comment_Validate : AbstractValidator<Edit_Comment_Request>
    {
        public Edit_Comment_Validate()
        {
            RuleFor(x => x.Content)
               .NotEmpty().WithMessage("Content id is required!");
        }
    }
}
