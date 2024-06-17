using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public Server()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);

            // Ternary conditional operator. If value == 0 false. if value == 1 true. - like if else
            IsOnline = randomNumber == 0? false : true;
        }
        public int ServerId { get; set; }
        public bool IsOnline { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string?  City { get; set; }

    }
}
