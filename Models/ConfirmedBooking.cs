using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_website.Models
{
    public class ConfirmedBooking
    {
        public int ConfirmedBookingID { get; set; }
        public int AdminID { get; set; }
        public int WaiterID { get; set; }
        public int BronID { get; set; }
        public DateTime ConfirmationDate { get; set; }
    }
}
