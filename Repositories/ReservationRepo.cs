using OnlineHotelManagementAPI.Models;

namespace OnlineHotelManagementAPI.Repositories
{
    public class ReservationRepo : IReservation
    {
        private HotelContext _context;

        public ReservationRepo(HotelContext context)
        {
            _context = context;
        }

        #region Delete Reservation
        public string DeleteReservation(int id)
        {
            string stcode = string.Empty;
            try
            {
                var reservation = _context.Reservations.Find(id);
                if (reservation != null)
                {
                    _context.Reservations.Remove(reservation);
                    _context.SaveChanges();
                    stcode = "200";
                }
                else
                {
                    stcode = "400";
                }
            }
            catch
            {
                stcode = "400";
            }
            return stcode;
        }
        #endregion

        #region Get all Reservation
        public List<Reservation> GetAllReservation()
        {
            try
            {
                List<Reservation> reservation = _context.Reservations.ToList();
                return reservation;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Get Reservation by Id
        public string GetReservationById(int Id)
        {
            Reservation reservation;
            string stcode = string.Empty;
            try
            {
                reservation = _context.Reservations.Find(Id);
                if (reservation != null)
                {
                    _context.SaveChanges();
                    stcode = "200";
                }
                else
                {
                    stcode = "400";
                }
            }
            catch (Exception e)
            {
                stcode = e.Message;
            }
            return stcode;

        }
        #endregion

        #region Insert Reservation
        public string InsertReservation(Reservation reservation)
        {
            string stcode = string.Empty;
            try
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                stcode = "200";

            }
            catch (Exception e)
            {
                stcode = "400";
            }
            return stcode;
        }
        #endregion

        #region Update Reservation
        public string UpdateReservation(Reservation reservation)
        {
            string stcode = string.Empty;
            try
            {
                _context.Reservations.Update(reservation);
                _context.SaveChanges();
                stcode = "200";

            }
            catch (Exception e)
            {
                stcode = "400";
            }
            return stcode;
        }
        #endregion
    }
}
