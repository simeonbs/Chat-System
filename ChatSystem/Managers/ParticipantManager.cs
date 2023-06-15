using ChatSystem.Data;
using ChatSystem.DTOs.Participant;
using ChatSystem.Managers.Interfaces;
using Mapster;

namespace ChatSystem.Managers
{
    /// <summary>
    /// The participant manager.
    /// </summary>
    /// <seealso cref="ChatSystem.Managers.Interfaces.IParticipantManager" />
    public class ParticipantManager : IParticipantManager
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ChatSystemDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipantManager"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ParticipantManager(ChatSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a participant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Participant not found</exception>
        public ParticipantDTO GetParticipantById(Guid id) => this._dbContext.Participants.FirstOrDefault(p => p.Id == id).Adapt<ParticipantDTO>() ?? throw new Exception("Participant not found");
    }
}
