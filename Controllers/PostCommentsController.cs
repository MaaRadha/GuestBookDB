using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedBackWebApi.Data;
using FeedBackWebApi.Models;
using FeedBackWebApi.DTO.PostCommentDTOs;
using AutoMapper;
using System.Net.Mime;

namespace FeedBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PostCommentsController : ControllerBase
    {
        private readonly FeedbackDBContext _context;
        private readonly IMapper _mapper; // Adding mapper

        public PostCommentsController(FeedbackDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PostComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReadCommentDto>>> GetPostComments()
        {
            var modelPost = await _context.PostComments.ToListAsync();

            return Ok(_mapper.Map <List<PostReadCommentDto>> (modelPost));
        }

        // GET: api/PostComments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostReadCommentDto>> GetPostComment(int id)
        {
            var postComment = await _context.PostComments.FindAsync(id);

            if (postComment == null)
            {
                return NotFound();
            }
             
            return Ok(_mapper.Map<List<PostReadCommentDto>>(postComment));

            //return postComment;
        }

        // PUT: api/PostComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPostComment(int id, PostUpdateCommentDto postUpdateDto)
        {
            if (id != postUpdateDto.Id)
            {
                return BadRequest();
            }

            var postComment = await _context.PostComments.FindAsync(id);

            if (postComment == null)
            {
                return NotFound();
            }

            // Mapper 
            _mapper.Map(postUpdateDto, postComment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PostComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostReadCommentDto>> PostPostComment(PostCreateCommentDto postCreateDto)
        {
            var postComment = _mapper.Map<PostComment>(postCreateDto);

            _context.PostComments.Add(postComment);
            await _context.SaveChangesAsync();

            var postReadDto = _mapper.Map<PostReadCommentDto>(postComment);
            return CreatedAtAction("GetPostComment", new { id = postComment.Id }, postReadDto);
        }

        // DELETE: api/PostComments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostComment(int id)
        {
            var postComment = await _context.PostComments.FindAsync(id);
            if (postComment == null)
            {
                return NotFound();
            }

            _context.PostComments.Remove(postComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostCommentExists(int id)
        {
            return _context.PostComments.Any(e => e.Id == id);
        }
    }
}
