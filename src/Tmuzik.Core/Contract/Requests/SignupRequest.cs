using System;
using FluentValidation;

namespace Tmuzik.Core.Contract.Requests
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
    }

    public class SignupRequestValidator : AbstractValidator<SignupRequest> 
    {
        public SignupRequestValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email address");
            RuleFor(x => x.Password)
                .Equal(x => x.PasswordConfirm)
                .WithMessage(x => "Passwords did not match");
        }
    }
}