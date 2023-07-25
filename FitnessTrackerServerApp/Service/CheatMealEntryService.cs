using FitnessTrackerServerApp.Data;
using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public class CheatMealEntryService: ICheatMealEntryService
    {
        private readonly FitnessTrackerServerAppDBContext _db;
        private readonly IWeightEntryService _weightEntryService;

        public CheatMealEntryService(IWeightEntryService weightEntryService, FitnessTrackerServerAppDBContext fitnessTrackerServerAppDBContext)
        {
            this._weightEntryService = weightEntryService;
            this._db = fitnessTrackerServerAppDBContext;
        }

        public CheatMealEntryDTO ConvertDTO(CheatMealEntry cheatMealEntry)
        { 
            var cheatMealEntryDTO = new CheatMealEntryDTO();
            cheatMealEntryDTO.CheatMealEntryId = cheatMealEntry.CheatMealEntryId;
            cheatMealEntryDTO.UserName = cheatMealEntry.UserName;
            cheatMealEntryDTO.Date = cheatMealEntry.Date;
            cheatMealEntryDTO.Calories = cheatMealEntry.Calories;
            cheatMealEntryDTO.WeightEntryId = cheatMealEntry.WeightEntryId;
            cheatMealEntryDTO.MealName = cheatMealEntry.MealName;
            return cheatMealEntryDTO;
        }

        public CheatMealEntry ConvertModel(CheatMealEntryDTO cheatMealEntryDTO) 
        {
            var cheatMealEntry = new CheatMealEntry();
            cheatMealEntry.CheatMealEntryId = cheatMealEntryDTO.CheatMealEntryId;
            cheatMealEntry.UserName = cheatMealEntryDTO.UserName;
            cheatMealEntry.Date = cheatMealEntryDTO.Date;
            cheatMealEntry.Calories = cheatMealEntryDTO.Calories;
            cheatMealEntry.WeightEntryId = cheatMealEntryDTO.WeightEntryId;
            cheatMealEntry.MealName = cheatMealEntryDTO.MealName;
            return cheatMealEntry;
        }

        public Task<ActionResult<CheatMealEntryDTO>> Add(CheatMealEntryDTO CheatMealEntryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EntryExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<CheatMealEntryDTO>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<CheatMealEntryDTO>>> GetAllByUsername(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<CheatMealEntryDTO>> GetLatestByUsername(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<CheatMealEntryDTO>> Update(Guid id, CheatMealEntryDTO CheatMealEntryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
