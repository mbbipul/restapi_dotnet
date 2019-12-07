using System.ComponentModel.DataAnnotations;

namespace ApiControllers.Models {
    public class Reservation {
        public int ReservationId { get; set; }
        [Required(ErrorMessage = "Please enter  your name")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string Location { get; set; }
    }
}