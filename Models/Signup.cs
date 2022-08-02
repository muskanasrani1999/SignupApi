using System.ComponentModel.DataAnnotations;

namespace SignUpAPI.Models
{
    public class Signup
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
