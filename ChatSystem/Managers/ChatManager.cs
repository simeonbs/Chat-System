using ChatSystem.Data;
using ChatSystem.Managers.Interfaces;
using ChatSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace ChatSystem.Managers
{
    public class ChatManager : IChatManager
    {
        private readonly ChatSystemDbContext _dbContext;
        private readonly IMemoryCache _cache;
        public ChatManager(ChatSystemDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        /// <summary>
        /// Starts the chat asynchronous.
        /// </summary>
        /// <param name="participant1Name">Name of the first participant.</param>
        /// <param name="participant2Name">Name of the second participant.</param>
        /// <returns></returns>
        public async Task<Guid> StartChatAsync(string participant1Name, string participant2Name)
        {
            var participant1 = await this.CreateParticipantAsync(participant1Name);
            var participant2 = await this.CreateParticipantAsync(participant2Name);

            var conversation = new Conversation
            {
                ParticipantOneId = participant1.Id,
                ParticipantTwoId = participant2.Id,
                Messages = string.Empty,
                StartTime = DateTime.Now
            };

            await _dbContext.Conversations.AddAsync(conversation);
            await _dbContext.SaveChangesAsync();

            // Store conversation in cache
            _cache.Set($"Conversation:{conversation.Id}", conversation);

            return conversation.Id;
        }

        /// <summary>
        /// Sending a message asynchronous.
        /// </summary>
        /// <param name="conversationId">The conversation identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<string> SendMessageAsync(Guid conversationId, string message)
        {
            var conversation = _dbContext.Conversations.Find(conversationId);
            if (conversation == null)
                return "Conversation not found.";

            conversation.Messages += message + "\n";
            await _dbContext.SaveChangesAsync();

            // Update conversation in cache
            _cache.Set($"Conversation:{conversation.Id}", conversation);

            return string.Empty;
        }

        public async Task EndChat(Guid conversationId)
        {
            var conversation = _dbContext.Conversations.Find(conversationId);

            if (conversation == null)
                throw new Exception("Conversation not found.");

            conversation.EndTime = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            // Remove conversation from cache
            _cache.Remove($"Conversation:{conversation.Id}");
        }

        /// <summary>
        /// Finds the conversation by id.
        /// </summary>
        /// <param name="conversationId">The conversation identifier.</param>
        /// <returns></returns>
        public bool FindConversation(Guid conversationId) => _dbContext.Conversations.Any(c => c.Id == conversationId 
                                                                                            && c.EndTime == null);

        public string GetConversation([FromQuery] Guid conversationId)
        {
            if (!_cache.TryGetValue($"Conversation:{conversationId}", out Conversation conversation))
                conversation = _dbContext.Conversations.FirstOrDefault(c => c.Id == conversationId && c.EndTime == null);

            if (conversation == null)
                throw new Exception("Conversation not found.");

            var json = JsonSerializer.Serialize(conversation);
            return json;
        }

        /// <summary>
        /// Creates the participant by given name async.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private async Task<Participant> CreateParticipantAsync(string name)
        {
            var participant = new Participant { Name = name };

            await _dbContext.Participants.AddAsync(participant);
            await _dbContext.SaveChangesAsync();

            return participant;
        }
    }
}
