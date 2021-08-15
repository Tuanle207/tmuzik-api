using System;
using FluentValidation;

namespace Tmuzik.Core.Contract.Requests
{
    public class RefreshLoginRequest
    {
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }

    public class RefreshLoginRequestValidator : AbstractValidator<RefreshLoginRequest>
    {
        public RefreshLoginRequestValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.RefreshToken).NotNull();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}