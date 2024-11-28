using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Entities;

namespace TestePraticoDATUM.Application.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>
    {
        public required string Title { get; set; }
        public required string Description { get; set;}
        public int IdUser { get; set; }
    }
}
