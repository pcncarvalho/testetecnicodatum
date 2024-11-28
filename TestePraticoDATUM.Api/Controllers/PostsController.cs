using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestePraticoDATUM.Api.PostNotification;
using TestePraticoDATUM.Application.Commands.CreatePost;
using TestePraticoDATUM.Application.Commands.DeletePost;
using TestePraticoDATUM.Application.Commands.UpdatePost;
using TestePraticoDATUM.Application.Queries.GetAllPosts;
using TestePraticoDATUM.Application.Queries.GetPostById;

namespace TestePraticoDATUM.Api.Controllers
{
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/posts?query=nova tecnologia 2025
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string query)
        {
            var getAllPostsQuery = new GetAllPostsQuery(query);

            var posts = await _mediator.Send(getAllPostsQuery);

            return Ok(posts);
        }

        // api/posts/2
        [HttpGet("{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPostByIdQuery(id);

            var post = await _mediator.Send(query);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                if (id > 0)
                {
                    // Call SignalR Post Notifications
                    var notificationSignalR = new ReceivePostNotification();
                    await notificationSignalR.ReceivePost();
                }

                return CreatedAtAction(nameof(GetById), new { id = id }, command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // api/posts/2
        [HttpPut("{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePostCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/posts/3 DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePostCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}