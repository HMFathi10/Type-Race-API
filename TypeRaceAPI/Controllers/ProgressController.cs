using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TypeRaceAPI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        //private readonly IUnitOfWork unitOfWork;
        private readonly IUnitOfService unitOfService;
        public ProgressController(IUnitOfService unitOfService)
        {
            this.unitOfService = unitOfService;
        }

        [HttpGet]
        public  IActionResult getByUserId(string userId)
        {
            string[] strings = { "trackers" };
            var progress = unitOfService.progressService.GetProgresses(p => p.UserId == userId, strings);
            return Ok(new {progress, level = progress.Select(p => p.trackers.Max(t => t.practiceId))});
        }
    }
}
