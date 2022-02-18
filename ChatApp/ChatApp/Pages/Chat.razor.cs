using ChatApp.Messages;
using ChatApp.Models;
using ChatApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace ChatApp.Pages
{
    public class ChatViewModel : ComponentBase, IRecipient<ChatMessageSentMessage>
    {
        [Inject]
        public ChatMessageService ChatMessageService { get; set; }

        [Inject]
        public IMessenger Messenger { get; set; }

        protected string currentUser;

        protected string currentMessage;

        protected override void OnInitialized()
        {
            this.Messenger.Register<ChatMessageSentMessage>(this);
        }

        protected void SendMessage()
        {
            this.ChatMessageService.SendMessage(new ChatMessageModel()
            {
                Username = this.currentUser,
                Message = this.currentMessage
            });

            this.currentMessage = String.Empty;
        }

        public void Receive(ChatMessageSentMessage message)
        {
            this.InvokeAsync(() => this.StateHasChanged());
        }
    }
}
