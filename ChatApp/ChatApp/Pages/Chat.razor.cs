using ChatApp.Models;
using Microsoft.AspNetCore.Components;

namespace ChatApp.Pages
{
    public class ChatViewModel : ComponentBase
    {
        protected List<ChatMessageModel> messages = new();

        protected string currentMessage;

        protected override void OnInitialized()
        {
            this.messages.Add(new ChatMessageModel()
            {
                Username = "Thomas",
                Message = "Hallo"
            });

            this.messages.Add(new ChatMessageModel()
            {
                Username = "Thomas",
                Message = "Grüß Gott"
            });
        }

        protected void SendMessage()
        {
            this.messages.Add(new ChatMessageModel()
            {
                Username = "Thomas",
                Message = this.currentMessage
            });

            this.currentMessage = String.Empty;
        }
    }
}
