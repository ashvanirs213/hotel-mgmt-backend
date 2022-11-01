using OnlineHotelManagementAPI.Models;

namespace OnlineHotelManagementAPI.Repositories
{
    public class RateRepo : IRate
    {
        private HotelContext _context;

        public RateRepo(HotelContext context)
        {
            _context = context;
        }

        #region Get all Rate
        public List<Rate> GetAllRate()
        {
            try
            {
                List<Rate> rate = _context.Rates.ToList();
                return rate;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Insert Rate
        public string InsertRate(Rate rate)
        {
            string stcode = string.Empty;
            try
            {
                _context.Rates.Add(rate);
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

        #region Update Rate
        public string UpdateRate(Rate rate)
        {
            string stcode = string.Empty;
            try
            {
                _context.Rates.Update(rate);
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

        #region Get Rate by Id
        public string GetRateById(int Id)
        {
            Rate rate;
            string stcode = string.Empty;
            try
            {
                rate = _context.Rates.Find(Id);
                if (rate != null)
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

        #region Delete Rate
        public string DeleteRate(int id)
        {
            string stcode = string.Empty;
            try
            {
                var rate = _context.Rates.Find(id);
                if (rate != null)
                {
                    _context.Rates.Remove(rate);
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

    }
}
