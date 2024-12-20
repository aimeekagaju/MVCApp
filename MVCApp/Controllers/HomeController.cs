using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using System.Runtime.CompilerServices;


namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Titre { get; set; } = null!;
        public IActionResult Index()
        {
            Titre = "Technofutur Tic";
             
            return View();
        }
        
        public IActionResult Contact()
        {
            Titre = "Technofutur Tic";
            AddressPhoneList model = new AddressPhoneList()
            {
                Address = new Address()
                {
                    Street = "Av. Jean Mermoz",
                    Number = "18",
                    ZipCode = 6100,
                    City = "Gosselies",
                    Country = "Belgique"
                },
                Phone = new PhoneNumber()
                {
                    Number = "071 25 49 60",
                    International = "+32"
                }
            };
            return View(model);
        }
        
    }
}
