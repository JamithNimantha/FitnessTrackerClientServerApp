using FitnessTrackerServerApp.Data;
using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerServerApp.Service
{
    public class WorkoutEntryService : IWorkoutEntryService
    {
        private readonly IWeightEntryService _weightEntryService;
        private readonly FitnessTrackerServerAppDBContext _db;
        public WorkoutEntryService(IWeightEntryService weightEntryService, FitnessTrackerServerAppDBContext fitnessTrackerServerAppDBContext) 
        {
            _weightEntryService = weightEntryService;
            _db = fitnessTrackerServerAppDBContext;
        }

        public WorkoutEntryDTO ConvertDTO(WorkoutEntry workoutEntry)
        {
            var workoutEntryDTO = new WorkoutEntryDTO();
            workoutEntryDTO.Date = workoutEntry.Date;
            workoutEntryDTO.UserName = workoutEntry.UserName;
            workoutEntryDTO.WeightEntryId = workoutEntry.WeightEntryId;
            workoutEntryDTO.CaloriesBurned = workoutEntry.CaloriesBurned;
            workoutEntryDTO.WorkoutName = workoutEntry.WorkoutName;
            workoutEntryDTO.Intensity = workoutEntry.Intensity;
            workoutEntryDTO.WorkoutEntryId = workoutEntry.WorkoutEntryId;
            return workoutEntryDTO;
        }

        public WorkoutEntry ConvertModel(WorkoutEntryDTO dto)
        {
            var workoutEntry = new WorkoutEntry();
            workoutEntry.Date = dto.Date;
            workoutEntry.UserName = dto.UserName;
            workoutEntry.WeightEntryId = dto.WeightEntryId;
            workoutEntry.CaloriesBurned = dto.CaloriesBurned;
            workoutEntry.WorkoutName = dto.WorkoutName;
            workoutEntry.Intensity = dto.Intensity;
            workoutEntry.WorkoutEntryId = dto.WorkoutEntryId;

            return workoutEntry;
        }


        public async Task<ActionResult<WorkoutEntryDTO>> Add(WorkoutEntryDTO workoutEntryDTO)
        {
            workoutEntryDTO.WeightEntry.Date = workoutEntryDTO.Date;
            workoutEntryDTO.WeightEntry.UserName = workoutEntryDTO.UserName;
            var weightEntry = await _weightEntryService.Add(workoutEntryDTO.WeightEntry);

            workoutEntryDTO.WeightEntryId = weightEntry.Value.WeightEntryId;
            
            var workoutEntry = new WorkoutEntry();
            var entry = ConvertModel(workoutEntryDTO);

            try
            {
                _db.WorkoutEntry.Add(entry);
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
            var entry = await _db.WorkoutEntry.FindAsync(id);
            if (entry == null)
            {
                return new NotFoundResult();
            }
            await _weightEntryService.Delete(entry.WeightEntryId.Value);
            _db.WorkoutEntry.Remove(entry);
            await _db.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<bool> EntryExists(Guid id)
        {
            var record = await _db.WorkoutEntry.AsNoTracking().FirstOrDefaultAsync(e => e.WorkoutEntryId == id);
            return record != null;
        }

        public async Task<ActionResult<WorkoutEntryDTO>> Get(Guid id)
        {
            var record = await _db.WorkoutEntry.FirstOrDefaultAsync(e => e.WorkoutEntryId == id);
            if (record == null)
            {
                return new NotFoundResult();
            }
            return ConvertDTO(record);
        }

        public async Task<ActionResult<IEnumerable<WorkoutEntryDTO>>> GetAllByUsername(string UserName)
        {
            var records = await _db.WorkoutEntry.AsNoTracking().Where(e => e.UserName == UserName).ToListAsync();
            var recordsDTO = new List<WorkoutEntryDTO>();
            foreach (var record in records)
            {
                recordsDTO.Add(ConvertDTO(record));
            }
            return recordsDTO;
        }

        public async Task<ActionResult<WorkoutEntryDTO>> GetLatestByUsername(string UserName)
        {
            var record = await _db.WorkoutEntry.AsNoTracking().Where(e => e.UserName == UserName).OrderByDescending(e => e.Date).FirstOrDefaultAsync();
            if (record == null)
            {
                return new NotFoundResult();
            }
            return ConvertDTO(record);
        }

        public async Task<ActionResult<WorkoutEntryDTO>> Update(Guid id, WorkoutEntryDTO workoutEntryDTO)
        {
            var entry = await _db.WorkoutEntry.FindAsync(id);
            if (entry == null)
            {
                return new NotFoundResult();
            }

            entry.WorkoutName = workoutEntryDTO.WorkoutName;
            entry.Intensity = workoutEntryDTO.Intensity;
            entry.CaloriesBurned = workoutEntryDTO.CaloriesBurned;
            entry.Date = workoutEntryDTO.Date;


            workoutEntryDTO.WeightEntry.Date = workoutEntryDTO.Date;
            workoutEntryDTO.UserName = workoutEntryDTO.UserName;

            try
            {
                await _weightEntryService.Update(entry.WeightEntryId.Value, workoutEntryDTO.WeightEntry);
                _db.WorkoutEntry.Update(entry);
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
