using ChatApp.Messages;
using ChatApp.Models;
using ChatApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatApp.Pages
{
    public class ChatViewModel : ComponentBase, IRecipient<ChatMessageSentMessage>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Inject]
        public ChatMessageService ChatMessageService { get; set; }

        [Inject]
        public IMessenger Messenger { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        private string currentUsername;
        public string CurrentUsername
        {
            get => this.currentUsername;
            set
            {
                this.currentUsername = value;
                this.RaisePropertyChanged();
            }
        }

        protected string currentMessage;

        public ChatViewModel()
        {
            this.PropertyChanged += ChatViewModel_PropertyChanged;
        }

        private void ChatViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.CurrentUsername))
            {
                _ = this.SaveUsername();
            }
        }

        private async Task SaveUsername()
        {
            await this.JsRuntime.InvokeVoidAsync("window.ChatApp.SetUsername", this.CurrentUsername);
        }

        protected override async Task OnInitializedAsync()
        {
            this.CurrentUsername = await this.JsRuntime.InvokeAsync<string>("window.ChatApp.GetUsername");
            this.Messenger.Register<ChatMessageSentMessage>(this);
        }

        protected void SendMessage()
        {
            this.ChatMessageService.SendMessage(new ChatMessageModel()
            {
                Username = this.CurrentUsername,
                Message = this.currentMessage
            });

            this.currentMessage = String.Empty;
        }

        public void Receive(ChatMessageSentMessage message)
        {
            this.InvokeAsync(async () =>
            {
                this.StateHasChanged();
                await this.JsRuntime.InvokeVoidAsync("window.ChatApp.ScrollToBottom");
            });
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
