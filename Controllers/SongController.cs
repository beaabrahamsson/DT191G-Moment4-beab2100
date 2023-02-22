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
    public class SongController : ControllerBase
    {
        private readonly SongContext _context;

        public SongController(SongContext context)
        {
            _context = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
          if (_context.Songs == null)
          {
              return NotFound();
          }

        //include rating
        return await _context.Songs.Include(e => e.RatingNumber).ToListAsync();

        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
          if (_context.Songs == null)
          {
              return NotFound();
          }
            //include rating
            var song = await _context.Songs.Include(s => s.RatingNumber)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Song
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
          if (_context.Songs == null)
          {
              return Problem("Entity set 'SongContext.Songs'  is null.");
          }
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            if (_context.Songs == null)
            {
                return NotFound();
            }
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return (_context.Songs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
