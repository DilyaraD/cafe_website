using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_website.Models
{
    public class Bron
    {
        public int BronID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.TimeSpan BookingTime { get; set; }
        public int GuestsCount { get; set; }
        public int StolID { get; set; }
        public string Status { get; set; }
    }
}
