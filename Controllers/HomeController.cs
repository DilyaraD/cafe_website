using Cafe_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cafe_website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CafeContext _context;

        public HomeController(ILogger<HomeController> logger, CafeContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Menu() {
            return View();
        }
        public IActionResult PopularDishes()
        {
            return View();
        }

        public bool CheckBookingAvailability(int table, DateTime date,TimeSpan time)
        {
            var existingBooking = _context.Bron.FirstOrDefault(b => b.StolID == table && b.BookingDate == date && b.BookingTime == time);
            if (existingBooking != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult ToReserv(string firstName, string lastName, string phone, DateTime date, TimeSpan time, int guests, int table)
        {
            bool isAvailable = CheckBookingAvailability(table, date, time);
            if (isAvailable)
            {
                return Json(new { success = false, message = "Выбранный стол уже забронирован на это время!" });
            }
            else
            {
                int BronID = _context.Bron.Max(b => b.BronID);
                Bron newReservation = new Bron
                {
                    BronID= BronID +1,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phone,
                    BookingDate = date,
                    BookingTime = time,
                    GuestsCount = guests,
                    StolID = table,
                    Status = "expectation"
                };

                _context.Bron.Add(newReservation);
                _context.SaveChanges();

                return Json(new { success = true, message = $"ЖДЕМ ВАС ПО АДРЕСУ: БОЛЬШАЯ КРАСНАЯ 55 {date} в {time}. Номер стола: {table}." });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
