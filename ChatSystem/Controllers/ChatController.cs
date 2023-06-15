using ChatSystem.Data;
using ChatSystem.Managers.Interfaces;
using ChatSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace ChatSystem.Controllers
{
    [ApiController]
    [Route("api/chat/")]
    public class ChatController : Controller
    {
        /// <summary>
        /// The chat manager.
        /// </summary>
        private readonly IChatManager _chatManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatController"/> class.
        /// </summary>
        /// <param name="chatManager">The chat manager.</param>
        public ChatController(IChatManager chatManager)
        {
            _chatManager = chatManager;
        }

        /// <summary>
        /// Endpoint that starts the chat.
        /// </summary>
        /// <param name="participant1Name">Name of the participant1.</param>
        /// <param name="participant2Name">Name of the participant2.</param>
        /// <returns></returns>
        [HttpPost("startChat")]
        public async Task<ActionResult<Guid>> StartChat(string participant1Name, string participant2Name)
        {
            return await this._chatManager.StartChatAsync(participant1Name, participant2Name);
        }

        /// <summary>
        /// Endpoint that sends a message by given conversation ID.
        /// </summary>
        /// <param name="conversationId">The conversation identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpPost("sendMessage")]
        public async Task<ActionResult<string>> SendMessage(Guid conversationId, [FromBody] string message)
        {
            return await this._chatManager.SendMessageAsync(conversationId, message);
        }

        /// <summary>
        /// Endpoint that ends the chat by setting the EndTime.
        /// </summary>
        /// <param name="conversationId">The conversation identifier.</param>
        [HttpDelete("{conversationId}")]
        public async Task EndChat([FromRoute] Guid conversationId)
        {
            await this._chatManager.EndChat(conversationId);
        }

        /// <summary>
        /// Endpoint that gets a conversation by given ID.
        /// </summary>
        /// <param name="conversationId">The conversation identifier.</param>
        /// <returns></returns>
        [HttpGet("{conversationId}")]
        public ActionResult<string> GetConversation([FromRoute] Guid conversationId)
        {
            return this._chatManager.GetConversation(conversationId);
        }
    }
}
