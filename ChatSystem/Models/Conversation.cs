using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSystem.Models
{
    public class Conversation
    {
        /// <summary>
        /// The ID of the conversation.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the participant1 identifier.
        /// </summary>
        /// <value>
        /// The participant1 identifier.
        /// </value>
        public Guid ParticipantOneId { get; set; }

        /// <summary>
        /// Gets or sets the participant2 identifier.
        /// </summary>
        /// <value>
        /// The participant2 identifier.
        /// </value>
        public Guid ParticipantTwoId { get; set; }

        /// <summary>
        /// The start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public string Messages { get; set; }
    }
}
