using FitnessTrackerServerApp.Data;
using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerServerApp.Service
{
    public class WeightEntryService : IWeightEntryService
    {
        private readonly FitnessTrackerServerAppDBContext _db;
        public WeightEntryService(FitnessTrackerServerAppDBContext fitnessTrackerServerAppDBContext)
        {
            _db = fitnessTrackerServerAppDBContext;
        }

        public static WeightEntryDTO ConvertToDTO(WeightEntry weightEntry)
        {
            var weightEntryDTO = new WeightEntryDTO();
            weightEntryDTO.WeightEntryId = weightEntry.WeightEntryId;
            weightEntryDTO.Weight = weightEntry.Weight;
            weightEntryDTO.Date = weightEntry.Date;
            weightEntryDTO.UserName = weightEntry.UserName;
            return weightEntryDTO;
        }

        public WeightEntry ConvertToModel(WeightEntryDTO weightEntryDTO)
        {
            var weightEntry = new WeightEntry();
            weightEntry.WeightEntryId = weightEntryDTO.WeightEntryId;
            weightEntry.Weight = weightEntryDTO.Weight;
            weightEntry.Date = weightEntryDTO.Date;
            weightEntry.UserName = weightEntryDTO.UserName;
            return weightEntry;
        }

        public async Task<ActionResult<WeightEntryDTO>> Add(WeightEntryDTO weightEntryDTO)
        {
            var entry = new WeightEntry();
            entry.Weight = weightEntryDTO.Weight;
            entry.Date = weightEntryDTO.Date;
            entry.UserName = weightEntryDTO.UserName;
            
            try
            {
                _db.WeightEntry.Add(entry);
                await _db.SaveChangesAsync();
               
            }
            catch (DbUpdateException)
            {

                throw;
            }
            return ConvertToDTO(entry);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var entry = await _db.WeightEntry.FindAsync(id);
            
            if (entry == null)
            {
                return new NotFoundResult();
            }

            _db.WeightEntry.Remove(entry);
            await _db.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<WeightEntryDTO>> Get(Guid id)
        {
            var record = await _db.WeightEntry.FirstOrDefaultAsync(e => e.WeightEntryId == id);
            if (record == null)
            {
                return new NotFoundResult();
            }
            return ConvertToDTO(record);
        }

        public async Task<ActionResult<IEnumerable<WeightEntryDTO>>> GetAllByUsername(string UserName)
        {
            var records = await _db.WeightEntry.AsNoTracking().Where(e => e.UserName == UserName).ToListAsync();
            var recordsDTO = new List<WeightEntryDTO>();
            foreach (var record in records)
            {
                recordsDTO.Add(ConvertToDTO(record));
            }
            return recordsDTO;
        }

        public async Task<ActionResult<WeightEntryDTO>> GetLatestByUsername(string UserName)
        {
            var record = await _db.WeightEntry.AsNoTracking().Where(e => e.UserName == UserName).OrderByDescending(e => e.Date).FirstOrDefaultAsync();
            if (record == null)
            {
                return new NotFoundResult();
            }
            return ConvertToDTO(record);
        }

        public async Task<ActionResult<WeightEntryDTO>> Update(Guid id, WeightEntryDTO weightEntryDTO)
        {
            var entry = await _db.WeightEntry.FindAsync(id);
            if (entry == null)
            {
                return new NotFoundResult();
            }

            entry.Weight = weightEntryDTO.Weight;
            entry.Date = weightEntryDTO.Date;


            try
            {
                _db.WeightEntry.Update(entry);
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

            return ConvertToDTO(entry);
        }

        public async Task<bool> EntryExists(Guid id)
        {
            var record =  await _db.WeightEntry.AsNoTracking().FirstOrDefaultAsync(e => e.WeightEntryId == id);
            return record != null;
        }
    }
}