using ChatApp.Models;
using ChatApp.Services;
using Microsoft.AspNetCore.Components;

namespace ChatApp.Pages
{
    public class ChatViewModel : ComponentBase
    {
        [Inject]
        public ChatMessageService ChatMessageService { get; set; }

        protected string currentUser;

        protected string currentMessage;

        protected override void OnInitialized()
        {
            this.ChatMessageService.Messages.Add(new ChatMessageModel()
            {
                Username = "Thomas",
                Message = "Hallo"
            });

            this.ChatMessageService.Messages.Add(new ChatMessageModel()
            {
                Username = "Thomas",
                Message = "Grüß Gott"
            });
        }

        protected void SendMessage()
        {
            this.ChatMessageService.Messages.Add(new ChatMessageModel()
            {
                Username = this.currentUser,
                Message = this.currentMessage
            });

            this.currentMessage = String.Empty;
        }
    }
}
