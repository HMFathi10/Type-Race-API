using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        //private readonly IUnitOfWork unitOfWork;
        private readonly IUnitOfService unitOfService;
        private readonly UserManager<IdentityUser> userManager;
        public TrackerController(IUnitOfService unitOfService, UserManager<IdentityUser> userManager)
        {
            this.unitOfService = unitOfService;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult GetAllByProgress(int progressId)
        {
            //var result = unitOfWork.Trackers.FindAsync(t => t.progress == progress);
            string[] strings = { "practice" };
            var result = unitOfService.trackerService.GetTrackers(t => t.progressId == progressId, strings);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest();
            }
            var userId = user.Id;
            string[] strings = { "trackers" };
            var progress = unitOfService.progressService.GetProgresses(p => p.UserId == userId, strings).FirstOrDefault();
            var practice = unitOfService.practiceService.GetPractice(progress.Level + 1);
            Tracker tracker = new Tracker { practice = practice, practiceId = practice.Id, progress = progress, Score = 98, progressId = progress.Id };
            unitOfService.trackerService.InsertTracker(tracker);
            return Ok(new { tracker });
        }
    }
}
