using FitnessTrackerServerApp.Data;
using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Model;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (cheatMealEntryDTO.WeightEntryId != null)
            {
                cheatMealEntryDTO.WeightEntry = _weightEntryService.Get(cheatMealEntryDTO.WeightEntryId.Value).Result.Value;
            }
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
            if (cheatMealEntryDTO.WeightEntryId != null)
            {
                cheatMealEntryDTO.WeightEntry = _weightEntryService.Get(cheatMealEntryDTO.WeightEntryId.Value).Result.Value;
            }
            return cheatMealEntry;
        }

        public async Task<ActionResult<CheatMealEntryDTO>> Add(CheatMealEntryDTO CheatMealEntryDTO)
        {
            CheatMealEntryDTO.WeightEntry.Date = CheatMealEntryDTO.Date;
            CheatMealEntryDTO.WeightEntry.UserName = CheatMealEntryDTO.UserName;
            var weightEntry = await _weightEntryService.Add(CheatMealEntryDTO.WeightEntry);

            CheatMealEntryDTO.WeightEntryId = weightEntry.Value.WeightEntryId;
            CheatMealEntryDTO.CheatMealEntryId = null;

            var entry = ConvertModel(CheatMealEntryDTO);
            try
            {
                _db.CheatMealEntry.Add(entry);
                await _db.SaveChangesAsync();

            }
            catch (DbUpdateException)
            {

                throw;
            }

            return ConvertDTO(entry);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var entry = await _db.CheatMealEntry.FindAsync(id);
            if (entry == null)
            {
                return new NotFoundResult();
            }
            await _weightEntryService.Delete(entry.WeightEntryId.Value);

            if (await EntryExists(id))
            {
                _db.CheatMealEntry.Remove(entry);
                await _db.SaveChangesAsync();
            }
            return new NoContentResult();
        }

        public async Task<bool> EntryExists(Guid id)
        {
            var record = await _db.CheatMealEntry.AsNoTracking().FirstOrDefaultAsync(e => e.CheatMealEntryId == id);
            return record != null;
        }

        public async Task<ActionResult<CheatMealEntryDTO>> Get(Guid id)
        {
            var record = await _db.CheatMealEntry.FirstOrDefaultAsync(e => e.CheatMealEntryId == id);
            if (record == null)
            {
                return new NotFoundResult();
            }
            return ConvertDTO(record);
        }

        public async Task<ActionResult<IEnumerable<CheatMealEntryDTO>>> GetAllByUsername(string UserName)
        {
            var records = await _db.CheatMealEntry.AsNoTracking().Where(e => e.UserName == UserName).OrderByDescending(e => e.Date).ToListAsync();
            var recordsDTO = new List<CheatMealEntryDTO>();
            foreach (var record in records)
            {
                recordsDTO.Add(ConvertDTO(record));
            }
            return recordsDTO;
        }

        public async Task<ActionResult<CheatMealEntryDTO>> GetLatestByUsername(string UserName)
        {
            var record = await _db.CheatMealEntry.AsNoTracking().Where(e => e.UserName == UserName).OrderByDescending(e => e.Date).FirstOrDefaultAsync();
            if (record == null)
            {
                return new NotFoundResult();
            }
            return ConvertDTO(record);
        }

        public async Task<ActionResult<CheatMealEntryDTO>> Update(Guid id, CheatMealEntryDTO CheatMealEntryDTO)
        {
            var entry = await _db.CheatMealEntry.FindAsync(id);
            if (entry == null)
            {
                return new NotFoundResult();
            }

            entry.MealName = CheatMealEntryDTO.MealName;
            entry.Calories = CheatMealEntryDTO.Calories;
            entry.Date = CheatMealEntryDTO.Date;


            CheatMealEntryDTO.WeightEntry.Date = CheatMealEntryDTO.Date;
            CheatMealEntryDTO.UserName = CheatMealEntryDTO.UserName;

            try
            {
                await _weightEntryService.Update(entry.WeightEntryId.Value, CheatMealEntryDTO.WeightEntry);
                _db.CheatMealEntry.Update(entry);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EntryExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return ConvertDTO(entry);
        }
    }
}
