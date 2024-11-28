using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Application.ViewModels;
using TestePraticoDATUM.Core.Repositories;

namespace TestePraticoDATUM.Application.Queries.GetPostById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostViewModel>
    {
        private readonly IPostRepository _postRepository;
        public GetProjectByIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostViewModel> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);

            if (post == null) return null;

            var projectDetailsViewModel = new PostViewModel(
                post.Id,
                post.Title,
                post.Description,
                post.CreatedAt);

            return projectDetailsViewModel;
        }
    }
}