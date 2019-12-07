using System.Collections.Generic;
using ApiControllers.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepository  repository;
        public ReservationController(IRepository repo) => repository = repo;
        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;
        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];
        [HttpPost]
        public Reservation Post([FromBody] Reservation res) =>
            repository.AddReservation(res);
        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id,
            [FromBody] JsonPatchDocument<Reservation> patch) {
                Reservation res = Get(id);
                if (res != null) {
                    patch.ApplyTo(res);
                    return Ok();
                }
                return NotFound();
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);
    }
}