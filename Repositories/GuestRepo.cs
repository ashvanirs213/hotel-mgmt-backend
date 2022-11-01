using Microsoft.EntityFrameworkCore;
using OnlineHotelManagementAPI.Models;

namespace OnlineHotelManagementAPI.Repositories
{
    public class GuestRepo : IGuest
    {
        readonly HotelContext _dbContext;
        public GuestRepo(HotelContext context)
        {
            _dbContext = context;
        }

        #region Get all
        public List<Guest> GetAll()
        {
            try
            {
                return _dbContext.Guests.ToList();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Get by Id
        public string GetById(int id)
        {
            string stcode = string.Empty;
            try
            {
                Guest? guest = _dbContext.Guests.Find(id);
                if (guest != null)
                {

                    _dbContext.SaveChanges();
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

        #region All Guest
        public string AddGuest(Guest guest)
        {
            string stcode = string.Empty;
            try
            {
                _dbContext.Guests.Add(guest);
                _dbContext.SaveChanges();
                stcode = "200";
            }
            catch
            {
                stcode = "400";
            }
            return stcode;
        }
        #endregion

        #region Update Guest
        public string UpdateGuest(Guest guest)
        {
            string stcode = string.Empty;
            try
            {
                _dbContext.Entry(guest).State = EntityState.Modified;
                _dbContext.SaveChanges();
                stcode = "200";
            }
            catch
            {
                stcode = "400";
            }
            return stcode;

        }
        #endregion

        #region Remove Guest
        public string RemoveGuest(int id)
        {
            string stcode = string.Empty;
            try
            {
                var guest = _dbContext.Guests.Find(id);
                if (guest != null)
                {
                    _dbContext.Guests.Remove(guest);
                    _dbContext.SaveChanges();
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
    }
}
