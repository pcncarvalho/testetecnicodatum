using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Application.ViewModels;

namespace TestePraticoDATUM.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
