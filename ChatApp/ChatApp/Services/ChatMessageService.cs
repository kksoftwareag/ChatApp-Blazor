using ChatApp.Messages;
using ChatApp.Models;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace ChatApp.Services
{
    public class ChatMessageService
    {
        private readonly IMessenger messenger;

        public List<ChatMessageModel> Messages { get; } = new();

        public ChatMessageService(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void SendMessage(ChatMessageModel message)
        {
            this.Messages.Add(message);
            this.messenger.Send(new ChatMessageSentMessage());
        }
    }
}
