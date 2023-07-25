using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerServerApp.Service;
using Microsoft.AspNetCore.Authorization;
using FitnessTrackerServerApp.DTO;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheatMealEntryController : ControllerBase
    {
        private readonly ICheatMealEntryService _service;

        public CheatMealEntryController(ICheatMealEntryService service)
        {
            _service = service;
        }

        // GET: api/CheatMealEntry
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<CheatMealEntryDTO>>> GetCheatMealEntry()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = this.User.Identity.Name;
            return await _service.GetAllByUsername(username);
        }

        // GET: api/CheatMealEntry/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<CheatMealEntryDTO>> GetCheatMealEntry(string id)
        {
            
            var entry = await _service.Get(new Guid(id));

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }

        // PUT: api/CheatMealEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutEntry(string id, CheatMealEntryDTO cheatMealEntryDTO)
        {
            var guid = new Guid(id);
            var record = await _service.Get(guid);

            if (record == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Update(guid, cheatMealEntryDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

           

            return NoContent();
        }

        // POST: api/CheatMealEntry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<CheatMealEntryDTO>> PostEntry(CheatMealEntryDTO entry)
        {
            entry.UserName = this.User.Identity.Name;
            return await _service.Add(entry);

        }

        // DELETE: api/CheatMealEntry/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteEntry(string id)
        {
            var guid = new Guid(id);
            var record = await _service.Get(guid);

            if (record == null)
            {
                return NotFound();
            }


            await _service.Delete(guid);

            return NoContent();
        }

    }
}
