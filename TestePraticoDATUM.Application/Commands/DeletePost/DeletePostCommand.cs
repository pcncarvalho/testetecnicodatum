using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePraticoDATUM.Application.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public DeletePostCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
