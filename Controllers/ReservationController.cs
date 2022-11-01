using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineHotelManagementAPI.Models;
using OnlineHotelManagementAPI.Service;

namespace OnlineHotelManagementAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService S_reservation;
        private HotelContext _context;

        public ReservationController(ReservationService reservation, HotelContext context)
        {
            S_reservation = reservation;
            _context = context;
        }

        #region Insert Reservation
        [HttpPost("InsertReservation")]
        public IActionResult InsertReservation(Reservation reservation)
        {
            return Ok(S_reservation.InsertReservation(reservation));
        }
        #endregion

        #region Update Reservation
        [HttpPut("UpdateReservation")]
        public IActionResult UpdateReservation(Reservation reservation)
        {
            return Ok(S_reservation.UpdateReservation(reservation));
        }
        #endregion

        #region Delete Reservation
        [HttpDelete("DeleteReservation")]
        public IActionResult DeleteReservation(int Id)
        {
            return Ok(S_reservation.DeleteReservation(Id));
        }
        #endregion

        #region Get Reservation by Id
        [HttpGet("GetReservationById")]
        public IActionResult GetReservationById(int Id)
        {
            if (S_reservation.GetReservationById(Id) == "200")
            {
                return Ok(_context.Reservations.Find(Id));
            }
            else
            {
                return Ok(new { message = "Not Found" });
            }
        }
        #endregion

        #region Get all Reservation
        [HttpGet("GetAllReservations")]
        public IActionResult GetAllReservation()
        {
            return Ok(S_reservation.GetAllReservation());
        }
        #endregion
    }
}
