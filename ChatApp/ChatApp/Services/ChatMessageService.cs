using ChatApp.Messages;
using ChatApp.Models;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace ChatApp.Services
{
    public class ChatMessageService
    {
        private readonly IMessenger messenger;
        private readonly DatabaseContext databaseContext;

        public List<ChatMessageModel> Messages { get; private set; } = new();

        public ChatMessageService(IMessenger messenger, DatabaseContext databaseContext)
        {
            this.messenger = messenger;
            this.databaseContext = databaseContext;
        }

        public void LoadMessages()
        {
            this.Messages = this.databaseContext.ChatMessages.ToList();
        }

        public void SendMessage(ChatMessageModel message)
        {
            this.Messages.Add(message);
            this.databaseContext.ChatMessages.Add(message);
            this.databaseContext.SaveChanges();
            this.messenger.Send(new ChatMessageSentMessage());
        }
    }
}
