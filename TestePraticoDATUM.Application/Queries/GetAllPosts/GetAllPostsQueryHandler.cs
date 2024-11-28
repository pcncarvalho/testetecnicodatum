using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Application.ViewModels;
using TestePraticoDATUM.Core.Repositories;

namespace TestePraticoDATUM.Application.Queries.GetAllPosts
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<PostViewModel>>
    {
        private readonly IPostRepository _postRepository;
        public GetAllPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<PostViewModel>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();

            var postsViewModel = posts
                .Select(p => new PostViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
                .ToList();

            return postsViewModel;
        }
    }
}
