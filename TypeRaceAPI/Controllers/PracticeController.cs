using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TypeRaceAPI.Core;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        //private readonly IUnitOfWork unitOfWork;
        private readonly IUnitOfService unitOfService;
        public PracticeController(IUnitOfService unitOfService) 
        {
           this.unitOfService = unitOfService;
        }
        [HttpGet]
        public IActionResult getAllByUser(string userId)
        {
            var practices = unitOfService.practiceService.GetPractices();
            List<PracticeViewModel> practicesViewModel = new List<PracticeViewModel>();
            foreach (var practice in practices)
            {
                var prog = unitOfService.progressService.GetProgress(1);
                var tracker = unitOfService.trackerService.GetTrackers(t => t.progress.UserId == userId && t.practice == practice).FirstOrDefault();
                PracticeViewModel temp = new PracticeViewModel(practice.Id, practice.Sentence, practice.Level, false, tracker?.Id,
                                                                tracker != null ? tracker.Score : 0, tracker?.progressId);
                practicesViewModel.Add(temp);
            }
            return Ok(new { practices = practicesViewModel, count = practicesViewModel?.Count() });
        }
    }
}
