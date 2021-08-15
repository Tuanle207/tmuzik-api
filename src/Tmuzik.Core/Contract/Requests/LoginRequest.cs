using FluentValidation;

namespace Tmuzik.Core.Contract.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}