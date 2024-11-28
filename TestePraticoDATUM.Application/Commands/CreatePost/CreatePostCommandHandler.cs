using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Entities;
using TestePraticoDATUM.Core.Repositories;

namespace TestePraticoDATUM.Application.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var project = new Post(request.Title, request.Description, request.IdUser);

            await _postRepository.AddAsync(project);

            return project.Id;
        }
    }
}