using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Application.ViewModels;

namespace TestePraticoDATUM.Application.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<List<PostViewModel>>
    {
        public GetAllPostsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
