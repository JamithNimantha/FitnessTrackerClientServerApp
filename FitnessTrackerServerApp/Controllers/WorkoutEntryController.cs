using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerServerApp.Model;
using FitnessTrackerServerApp.Service;
using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Authorization;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutEntryController : ControllerBase
    {
        private readonly IWorkoutEntryService _service;

        public WorkoutEntryController(IWorkoutEntryService workoutEntryService)
        {
            _service = workoutEntryService;
        }

        // GET: api/WorkoutEntry
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<WorkoutEntryDTO>>> GetWorkoutEntry()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = this.User.Identity.Name;
            return await _service.GetAllByUsername(username);
        }

        // GET: api/WorkoutEntry/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<WorkoutEntryDTO>> GetWorkoutEntry(string id)
        {
            var workoutEntry = await _service.Get(new Guid(id));

            if (workoutEntry == null)
            {
                return NotFound();
            }

            return workoutEntry;
        }

        // PUT: api/WorkoutEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutWorkoutEntry(string id, WorkoutEntryDTO workoutEntry)
        {
            var guid = new Guid(id);
            var record = await _service.Get(guid);

            if (record == null)
            {
                return NotFound();
            }

            try
            {
                await _service.Update(guid, workoutEntry);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/WorkoutEntry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<WorkoutEntryDTO>> PostWorkoutEntry(WorkoutEntryDTO workoutEntry)
        {
            workoutEntry.UserName = this.User.Identity.Name;

            return await _service.Add(workoutEntry);
        }

        // DELETE: api/WorkoutEntry/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteWorkoutEntry(string id)
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
