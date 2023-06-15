using ChatSystem.DTOs.Participant;

namespace ChatSystem.Managers.Interfaces
{
    public interface IParticipantManager
    {
        public ParticipantDTO GetParticipantById(Guid id);
    }
}
