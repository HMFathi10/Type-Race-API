using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TypeRaceAPI.Core.Interfaces;

namespace TypeRaceAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ProgressController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult getByUserId(string userId)
        {
            var progress = unitOfWork.Progresses.FindAsync(p => p.UserId == userId);
            return Ok(progress);
        }
    }
}
