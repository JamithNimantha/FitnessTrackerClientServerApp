using FitnessTrackerServerApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Service
{
    public interface IReportService
    {
        Task<ActionResult<FitnessPredictionDTO>> PredictFitness(string UserName, FitnessPredictionDTO FitnessPredictionDTO);
        Task<ActionResult<List<WeightEntryDTO>>> GetLast20WeightEntries(string UserName);
        Task<ActionResult<ReportDataDTO>> GenerateReport(string UserName, ReportDataDTO ReportData);
    }
}
