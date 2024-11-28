using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePraticoDATUM.Application.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int IdUser { get; set; }
    }
}
