using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public interface ICheatMealEntry
    {
        Task<ActionResult<CheatMealEntryDTO>> Add(CheatMealEntryDTO CheatMealEntryDTO);
        Task<ActionResult<CheatMealEntryDTO>> Update(Guid id, CheatMealEntryDTO CheatMealEntryDTO);
        Task<ActionResult<CheatMealEntryDTO>> Get(Guid id);
        Task<ActionResult<IEnumerable<CheatMealEntryDTO>>> GetAllByUsername(string UserName);
        Task<ActionResult<CheatMealEntryDTO>> GetLatestByUsername(string UserName);
        Task<ActionResult> Delete(Guid id);
        Task<bool> EntryExists(Guid id);
    }
}
