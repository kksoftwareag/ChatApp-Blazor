using ChatApp.Models;

namespace ChatApp.Services
{
    public class ChatMessageService
    {
        public List<ChatMessageModel> Messages { get; } = new();
    }
}
