using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository { get ; set; }
        public HomeController(IRepository repo) => repository = repo;
        public ViewResult Index() => View(repository.Reservations);
        [HttpPost]
        public IActionResult AddReservation(Reservation reservation) {
            if(ModelState.IsValid){
                repository.AddReservation(reservation);
                return RedirectToAction("Index");
            }else{
                return View("Index",repository.Reservations);
            }
        }
    }
}