using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TypeRaceAPI.Core;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public PracticeController(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> getAllByUser(string userId)
        {
            var practices = unitOfWork.Practices.GetAll();
            List<PracticeViewModel> practicesViewModel = new List<PracticeViewModel>()/*Enumerable.Empty<PracticeViewModel>()*/;
            foreach (var practice in practices)
            {
                var prog = await unitOfWork.Progresses.FindAsync(t => t.Id == 1);
                var tracker = await unitOfWork.Trackers.FindAsync(t => t.progress.UserId == userId && t.Practice == practice);
                PracticeViewModel temp = new PracticeViewModel
                {
                    Id = practice.Id,
                    level = practice.Level,
                    Sentence = practice.Sentence,
                    Premium = false,
                    ProgressId = null,
                    Score = 0,
                    TrackerId = null
                };
                if (tracker != null)
                {
                    temp.ProgressId = tracker.progress.Id;
                    temp.Score = tracker.Score;
                    temp.TrackerId = tracker.Id;
                }
                practicesViewModel.Add(temp);
            }
            return Ok(new { practicesViewModel, count = practicesViewModel?.Count() });
        }
    }
}
