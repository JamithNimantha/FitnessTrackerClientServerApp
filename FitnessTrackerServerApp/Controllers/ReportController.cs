using FitnessTrackerServerApp.DTO;
using FitnessTrackerServerApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }

      
        [HttpGet("GetLatestWeightEntries"), Authorize]
        public async Task<ActionResult<List<WeightEntryDTO>>> GetLatestWeightEntries()
        {
            if(!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = this.User.Identity.Name;
            return await _service.GetLast20WeightEntries(username);
        }


        [HttpPost("PredictFitness"), Authorize]
        public async Task<ActionResult<FitnessPredictionDTO>> PredictFitness(FitnessPredictionDTO fitnessPredictionDTO)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = this.User.Identity.Name;
            return await _service.PredictFitness(username, fitnessPredictionDTO);
        }

        [HttpPost("GetReport"), Authorize]
        public async Task<ActionResult<ReportDataDTO>> GetReport(ReportDataDTO ReportData)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            string username = this.User.Identity.Name;
            return await _service.GenerateReport(username, ReportData);
        }


    }
}
