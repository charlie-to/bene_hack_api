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
    [Route("/quest/status")]
    [ApiController]
    public class QuestStatusController : ControllerBase
    {
        private readonly QuestStatusContext _context;

        public QuestStatusController(QuestStatusContext context)
        {
            _context = context;
        }

        // GET: api/QuestStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestStatus>>> GetQuestStatus()
        {
          if (_context.QuestStatus == null)
          {
              return NotFound();
          }
            return await _context.QuestStatus.ToListAsync();
        }

        // GET: api/QuestStatus/5
        [HttpGet("{user_id}")]
        public async Task<ActionResult<IEnumerable<QuestStatus>>> GetQuestStatus([FromRoute]int user_id)
        {
          if (_context.QuestStatus == null)
          {
              return NotFound();
          }
            var questStatus = _context.QuestStatus.Where(status => status.user_id == user_id);

            if (questStatus == null)
            {
                return NotFound();
            }

            return await questStatus.ToListAsync<QuestStatus>();
        }
        // GET: api/QuestStatus/5
        [HttpGet("hp/{quest_id}")]
        public async Task<ActionResult<float>> GetHpByQuest([FromRoute] int quest_id)
        {
            if (_context.QuestStatus == null)
            {
                return NotFound();
            }
            var questStatus = await _context.QuestStatus.Where(status => status.quest_id == quest_id).ToListAsync();

            if (questStatus == null)
            {
                return NotFound();
            }
            if(questStatus.Count == 0)
            {
                return NotFound();
            }

            int count_finish = 0;
            foreach(QuestStatus s in questStatus)
            {
                if(s.status == true)
                {
                    count_finish++;
                }
            }

            return (float) count_finish/questStatus.Count ;
        }


        // PUT: api/QuestStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutQuestStatus(QuestStatus questStatus)
        {
            var questStatus_db = await _context.QuestStatus.FirstOrDefaultAsync(status => questStatus.user_id == status.user_id && questStatus.quest_id == status.quest_id);

            if (questStatus_db == null)
            {
                return BadRequest();
            }

            questStatus_db.status = questStatus.status;

            _context.Entry(questStatus_db).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestStatusExists(questStatus_db.id))
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

        // POST: api/QuestStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestStatus>> PostQuestStatus(QuestStatus questStatus)
        {
          if (_context.QuestStatus == null)
          {
              return Problem("Entity set 'QuestStatusContext.QuestStatus'  is null.");
          }

            var queststatus_Db = _context.QuestStatus.FirstOrDefault(status => status.quest_id == questStatus.quest_id && status.user_id == questStatus.user_id);
            if(queststatus_Db != null) { return Ok("This is already Created..."); }

            _context.QuestStatus.Add(questStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestStatus", new { id = questStatus.id }, questStatus);
        }

        // DELETE: api/QuestStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestStatus(int id)
        {
            if (_context.QuestStatus == null)
            {
                return NotFound();
            }
            var questStatus = await _context.QuestStatus.FindAsync(id);
            if (questStatus == null)
            {
                return NotFound();
            }

            _context.QuestStatus.Remove(questStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestStatusExists(int id)
        {
            return (_context.QuestStatus?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
