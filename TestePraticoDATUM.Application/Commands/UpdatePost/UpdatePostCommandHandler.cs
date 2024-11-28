using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePraticoDATUM.Core.Repositories;

namespace TestePraticoDATUM.Application.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        public UpdatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var project = await _postRepository.GetByIdAsync(request.Id);

            project.Update(request.Title, request.Description, request.IdUser);

            await _postRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
