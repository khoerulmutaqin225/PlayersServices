#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayersService.Data;
using PlayersService.Models;

namespace PlayersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerssController : ControllerBase
    {
        private readonly PlayersServiceContext _context;


        public PlayerssController(PlayersServiceContext context)
        {
            _context = context;
        }

        //[Nomor 1]
        // GET: api/Playerss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Players>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        //[Nomor 2]
        // GET: api/Playerss/search?BirthPlace=Europe
        [HttpGet("{search}")]
        public async Task<ActionResult<Players>> GetPlayers(String BirthPlace)
        {
            var Players = await _context.Players.FindAsync(BirthPlace);

            if (Players == null)
            {
                return NotFound();
            }

            return Players;
        }



        //[Nomor 3]
        // GET: api/Playerss/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Players>> GetPlayers(int id)
        {
            var Players = await _context.Players.FindAsync(id);

            if (Players == null)
            {
                return NotFound();
            }

            return Players;
        }

        //[Nomor 4]
        // POST: api/Playerss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Players>> PostPlayers(Players Players)
        {
            _context.Players.Add(Players);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayers", new { id = Players.Id }, Players);
        }

        private bool PlayersExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }

        
    }
}
