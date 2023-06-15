using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ChatSystem.Models
{
    /// <summary>
    /// Participant model.
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// The ID of the participant.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the participant.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
