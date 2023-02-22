using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DT191G_Moment4_beab2100.Data;
using DT191G_Moment4_beab2100.Models;

namespace DT191G_Moment4_beab2100.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly SongContext _context;

        public RatingController(SongContext context)
        {
            _context = context;
        }

        // GET: api/Rating
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatings()
        {
          if (_context.Ratings == null)
          {
              return NotFound();
          }

            return await _context.Ratings.ToListAsync();

        }

        // GET: api/Rating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
          if (_context.Ratings == null)
          {
              return NotFound();
          }
            var Rating = await _context.Ratings.FindAsync(id);

            if (Rating == null)
            {
                return NotFound();
            }

            return Rating;
        }

        // PUT: api/Rating/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRating(int id, Rating Rating)
        {
            if (id != Rating.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(Rating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/Rating
        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(Rating Rating)
        {
          if (_context.Ratings == null)
          {
              return Problem("Entity set 'RatingContext.Ratings'  is null.");
          }
            _context.Ratings.Add(Rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRating", new { id = Rating.RatingId }, Rating);
        }

        // DELETE: api/Rating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            if (_context.Ratings == null)
            {
                return NotFound();
            }
            var Rating = await _context.Ratings.FindAsync(id);
            if (Rating == null)
            {
                return NotFound();
            }

            _context.Ratings.Remove(Rating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RatingExists(int id)
        {
            return (_context.Ratings?.Any(e => e.RatingId == id)).GetValueOrDefault();
        }
    }
}