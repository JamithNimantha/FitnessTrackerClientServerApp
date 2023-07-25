using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public interface IWorkoutEntryService
    {
        Task<ActionResult<WorkoutEntryDTO>> Add(WorkoutEntryDTO workoutEntryDTO);
        Task<ActionResult<WorkoutEntryDTO>> Update(Guid id, WorkoutEntryDTO workoutEntryDTO);
        Task<ActionResult<WorkoutEntryDTO>> Get(Guid id);
        Task<ActionResult<IEnumerable<WorkoutEntryDTO>>> GetAllByUsername(string UserName);
        Task<ActionResult<WorkoutEntryDTO>> GetLatestByUsername(string UserName);
        Task<ActionResult> Delete(Guid id);
        Task<bool> EntryExists(Guid id);
    }
}
