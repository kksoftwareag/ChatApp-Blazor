using Microsoft.AspNetCore.Components;

namespace ChatApp.Pages
{
    public class ChatViewModel : ComponentBase
    {
        protected List<string> messages = new();

        protected string currentMessage;

        protected override void OnInitialized()
        {
            this.messages.Add("Test");
            this.messages.Add("Test123");
        }

        protected void SendMessage()
        {
            this.messages.Add(this.currentMessage);
            this.currentMessage = String.Empty;
        }
    }
}
