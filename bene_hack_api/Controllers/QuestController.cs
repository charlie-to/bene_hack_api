using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bene_hack_api.Data;
using bene_hack_api.Models;

namespace bene_hack_api.Controllers
{
    [Route("/quest")]
    [ApiController]
    public class QuestController : Controller
    {
        private readonly QuestContext _context;

        public QuestController(QuestContext context)
        {
            _context = context;
        }

        // GET: api/Quest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quest>>> GetQuests()
        {
          if (_context.Quests == null)
          {
              return NotFound();
          }
            return await _context.Quests.ToListAsync();
        }

        // GET: api/Quest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quest>> GetQuest(int id)
        {
          if (_context.Quests == null)
          {
              return NotFound();
          }
            var quest = await _context.Quests.FindAsync(id);

            if (quest == null)
            {
                return NotFound();
            }

            return quest;
        }

        // PUT: api/Quest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuest(int id, Quest quest)
        {
            if (id != quest.id)
            {
                return BadRequest();
            }

            _context.Entry(quest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestExists(id))
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

        // POST: api/Quest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quest>> PostQuest(Quest quest)
        {
          if (_context.Quests == null)
          {
              return Problem("Entity set 'QuestContext.Quests'  is null.");
          }
            _context.Quests.Add(quest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuest", new { id = quest.id }, quest);
        }

        // DELETE: api/Quest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuest(int id)
        {
            if (_context.Quests == null)
            {
                return NotFound();
            }
            var quest = await _context.Quests.FindAsync(id);
            if (quest == null)
            {
                return NotFound();
            }

            _context.Quests.Remove(quest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestExists(int id)
        {
            return (_context.Quests?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
