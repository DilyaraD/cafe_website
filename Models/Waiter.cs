using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_website.Models
{
    public class Waiter
    {
        public int WaiterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
