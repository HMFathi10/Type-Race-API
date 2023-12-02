using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TackerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public TackerController(IUnitOfWork unitOfWork)
        {
             this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAllByProgress(Progress progress) 
        {
            var result = unitOfWork.Trackers.FindAsync(t => t.progress == progress);
            return Ok(result);
        }
    }
}
