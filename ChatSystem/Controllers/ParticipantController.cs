using ChatSystem.DTOs.Participant;
using ChatSystem.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Controllers
{
    /// <summary>
    /// Participant controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("api/participant/")]
    public class ParticipantController : Controller
    {
        /// <summary>
        /// The participant manager
        /// </summary>
        private readonly IParticipantManager _participantManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipantController"/> class.
        /// </summary>
        /// <param name="participantManager">The participant manager.</param>
        public ParticipantController(IParticipantManager participantManager)
        {
            _participantManager = participantManager;
        }

        /// <summary>
        /// Gets the participant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ParticipantDTO GetParticipantById([FromQuery] Guid id) => this._participantManager.GetParticipantById(id);
    }
}
