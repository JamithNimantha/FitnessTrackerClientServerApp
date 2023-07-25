using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public interface WeightEntryService
    {
        Task<UserDTO> Add(WeightEntryDTO registerUserDTO);
        Task<ActionResult> Delete(Guid id);
        Task<ActionResult<WeightEntryDTO>> Get(Guid id);
        Task<ActionResult<IEnumerable<WeightEntryDTO>>> GetAllByUsername(string UserName);
        Task<ActionResult<WeightEntryDTO>> GetLatestByUsername(string UserName);
        Task<ActionResult> Update(Guid id, WeightEntryDTO weightEntryDTO);
    }
}