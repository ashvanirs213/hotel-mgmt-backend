using OnlineHotelManagementAPI.Models;

namespace OnlineHotelManagementAPI.Repositories
{
    public class AdminRepo : IAdmin
    {
        readonly HotelContext _dbContext;
        public AdminRepo(HotelContext context)
        {
            _dbContext = context;
        }


        #region Add Admin
        public string AddAdmin(Admin admin)
        {
            string stcode = string.Empty;
            try
            {
                _dbContext.Admins.Add(admin);
                _dbContext.SaveChanges();
                stcode = "200";
                return stcode;
            }
            catch (Exception ex)
            {
                stcode = "400";
                throw ex;
            }
        }
        #endregion
    }
}
