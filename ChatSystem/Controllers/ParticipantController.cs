using ChatSystem.DTOs.Participant;
using ChatSystem.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Controllers
{
    [ApiController]
    [Route("api/participant/")]
    public class ParticipantController : Controller
    {
        private readonly IParticipantManager _participantManager;

        public ParticipantController(IParticipantManager participantManager)
        {
            _participantManager = participantManager;
        }

        [HttpGet]
        public ParticipantDTO GetParticipantById([FromQuery] Guid id) => this._participantManager.GetParticipantById(id);
    }
}
