using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetriggerMail.Repository;
using System.Net.Mail;

namespace RetriggerMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService _service;

        public CommunicationController(ICommunicationService service)
        {
            _service = service;
        }

        [HttpGet("{claimNumber}")]
        public async Task<IActionResult> GetLogs(string claimNumber)
        {
            var logs = await _service.GetLogsByClaimAsync(claimNumber);
            return Ok(logs);
        }

        [HttpPost("retrigger/{logId}")]
        public async Task<IActionResult> Retrigger(int logId)
        {
            var success = await _service.RetriggerAsync(logId);
            if (!success) return NotFound();           

            return Ok(new { message = "Retriggered successfully" });
        }
    }
}
