using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public interface IWeightEntryService
    {
        Task<ActionResult<WeightEntryDTO>> Add(WeightEntryDTO registerUserDTO);
        Task<ActionResult<WeightEntryDTO>> Update(Guid id,WeightEntryDTO weightEntryDTO);
        Task<ActionResult<WeightEntryDTO>> Get(Guid id);
        Task<ActionResult<IEnumerable<WeightEntryDTO>>> GetAllByUsername(string UserName);
        Task<ActionResult<WeightEntryDTO>> GetLatestByUsername(string UserName);
        Task<ActionResult> Delete(Guid id);
    }
}
