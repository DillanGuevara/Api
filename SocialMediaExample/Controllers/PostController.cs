using Microsoft.AspNetCore.Mvc;
using SocialMediaExample.Entities;
using SocialMediaExample.Interfaces;

namespace SocialMediaExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Invalid post data.");
            }

            await _postService.RegisterPostAsync(post);
            return Ok(post);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var users = await _postService.GetAllPostsAsync(pageNumber, pageSize);

            if (!users.Any())
                return NotFound("No posts found.");

            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post updatedPost)
        {
            if (id != updatedPost.IdPost)
                return BadRequest("The post ID in the request doesn't match the ID in the post object.");

            var existingPost = await _postService.GetPostByIdAsync(id);
            if (existingPost == null)
                return NotFound("Post not found.");

            existingPost.IdUser = updatedPost.IdUser;
            existingPost.Date = updatedPost.Date;
            existingPost.Description = updatedPost.Description;

            await _postService.UpdatePostAsync(existingPost);

            return Ok("The post update is correct.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var existingPost = await _postService.GetPostByIdAsync(id);
            if (existingPost == null)
                return NotFound();

            await _postService.DeletePostAsync(id);
            return Ok("The post delete is correct");
        }
    }
}
