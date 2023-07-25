using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerServerApp.Service;
using Microsoft.AspNetCore.Authorization;
using FitnessTrackerServerApp.DTO;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightEntryController : ControllerBase
    {
        private readonly IWeightEntryService _service;

        public WeightEntryController(IWeightEntryService service)
        {
            _service = service;
        }

        // GET: api/WeightEntry
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<WeightEntryDTO>>> GetWeightEntry()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = this.User.Identity.Name;
            return await _service.GetAllByUsername(username);
        }

        // GET: api/WeightEntry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeightEntryDTO>> GetWeightEntry(string id)
        {
            
            var weightEntry = await _service.Get(new Guid(id));

            if (weightEntry == null)
            {
                return NotFound();
            }

            return weightEntry;
        }

        // PUT: api/WeightEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeightEntry(string id, WeightEntryDTO weightEntry)
        {
            var guid = new Guid(id);
            var record = await _service.Get(guid);

            if (record == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Update(guid, weightEntry);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

           

            return NoContent();
        }

        // POST: api/WeightEntry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeightEntryDTO>> PostWeightEntry(WeightEntryDTO weightEntry)
        {
            weightEntry.UserName = this.User.Identity.Name;
            return await _service.Add(weightEntry);

        }

        // DELETE: api/WeightEntry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightEntry(string id)
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
