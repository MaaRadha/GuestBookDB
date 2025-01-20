using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedBackWebApi.Data;
using FeedBackWebApi.Models;
using AutoMapper;
using System.Net.Mime;
using FeedBackWebApi.DTO.PostReactionDTOs;
using FeedBackWebApi.DTO.PostCommentDTOs;

namespace FeedBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PostReactionsController : ControllerBase
    {
        private readonly FeedbackDBContext _context;
        private readonly IMapper _mapper; // Adding mapper

        public PostReactionsController(FeedbackDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PostReactions
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PostReadReactionDto>>> GetPostReactions()
        {
            var PostReadModel = await _context.PostReactions.ToListAsync();

            return Ok(_mapper.Map<List<PostReadReactionDto>>(PostReadModel));
        }

        // GET: api/PostReactions/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostReadReactionDto>> GetPostReaction(int id)
        {
            var postReaction = await _context.PostReactions.FindAsync(id);

            if (postReaction == null)
            {
                return NotFound();
            }

            var PostReactionModel = _mapper.Map<PostReadReactionDto>(postReaction);

            return Ok(PostReactionModel);

            //return Ok(_mapper.Map<PostReadReactionDto>(postReaction));
        }

        // PUT: api/PostReactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPostReaction(int id, PostUpdataReactionDto postUpdateDto)
        {
            if (id != postUpdateDto.Id)
            {
                return BadRequest();
            }

            var PostReactionModel = await _context.PostReactions.FindAsync(id);

            if (PostReactionModel == null)
            {
                return NotFound();
            }

            // mapper
            _mapper.Map(postUpdateDto, PostReactionModel);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!PostReactionExists(id))
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

        // POST: api/PostReactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostReadReactionDto>> PostPostReaction(PostCreateReactionDto postCreateDto)
        {
            var PostCreateReaction = _mapper.Map<PostReaction>(postCreateDto);

            _context.PostReactions.Add(PostCreateReaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostReaction", new { id = PostCreateReaction.Id }, PostCreateReaction);
        }

        // DELETE: api/PostReactions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePostReaction(int id)
        {
            var postReaction = await _context.PostReactions.FindAsync(id);
            if (postReaction == null)
            {
                return NotFound();
            }

            _context.PostReactions.Remove(postReaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostReactionExists(int id)
        {
            return _context.PostReactions.Any(e => e.Id == id);
        }
    }
}
