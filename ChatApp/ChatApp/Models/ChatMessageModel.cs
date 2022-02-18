using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class ChatMessageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
