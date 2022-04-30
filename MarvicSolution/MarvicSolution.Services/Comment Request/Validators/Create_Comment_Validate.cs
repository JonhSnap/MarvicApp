using FluentValidation;
using MarvicSolution.Services.Comment_Request.Requests;

namespace MarvicSolution.Services.Comment_Request.Validators
{
    public class Create_Comment_Validate : AbstractValidator<Create_Comment_Request>
    {
        public Create_Comment_Validate()
        {
            RuleFor(x => x.Id_Issue)
                .NotEmpty().WithMessage("Id_Issue id is required!");
            RuleFor(x => x.Id_User)
               .NotEmpty().WithMessage("Id_User id is required!");
            RuleFor(x => x.Content)
               .NotEmpty().WithMessage("Content id is required!");
        }
    }
}
