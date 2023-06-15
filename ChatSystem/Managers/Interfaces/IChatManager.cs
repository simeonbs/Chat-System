using Microsoft.AspNetCore.Mvc;

namespace ChatSystem.Managers.Interfaces
{
    public interface IChatManager
    {
        Task<Guid> StartChatAsync(string participant1Name, string participant2Name);

        Task<string> SendMessageAsync(Guid conversationId, string message);

        Task EndChat(Guid conversationId);

        bool FindConversation(Guid conversationId);

        string GetConversation([FromQuery] Guid conversationId);
    }
}
