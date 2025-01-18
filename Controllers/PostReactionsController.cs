using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedBackWebApi.Data;
using FeedBackWebApi.Models;

namespace FeedBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostReactionsController : ControllerBase
    {
        private readonly FeedbackDBContext _context;

        public PostReactionsController(FeedbackDBContext context)
        {
            _context = context;
        }

        // GET: api/PostReactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostReaction>>> GetPostReactions()
        {
            return await _context.PostReactions.ToListAsync();
        }

        // GET: api/PostReactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostReaction>> GetPostReaction(int id)
        {
            var postReaction = await _context.PostReactions.FindAsync(id);

            if (postReaction == null)
            {
                return NotFound();
            }

            return postReaction;
        }

        // PUT: api/PostReactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostReaction(int id, PostReaction postReaction)
        {
            if (id != postReaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(postReaction).State = EntityState.Modified;

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
        public async Task<ActionResult<PostReaction>> PostPostReaction(PostReaction postReaction)
        {
            _context.PostReactions.Add(postReaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostReaction", new { id = postReaction.Id }, postReaction);
        }

        // DELETE: api/PostReactions/5
        [HttpDelete("{id}")]
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
