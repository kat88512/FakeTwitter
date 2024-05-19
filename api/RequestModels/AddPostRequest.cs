using api.Configuration;
using FastEndpoints;
using FluentValidation;

namespace api.RequestModels
{
    public class AddPostValidator : Validator<AddPostRequest>
    {
        public AddPostValidator()
        {
            RuleFor(p => p.Text)
                .NotEmpty()
                .MaximumLength(StringLengths.PostMaxLength);
        }
    }

    public class AddPostRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
