using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineHotelManagementAPI.Models;
using OnlineHotelManagementAPI.Service;

namespace OnlineHotelManagementAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly StaffService S_staff;
        private HotelContext _context;

        public StaffsController(StaffService staff, HotelContext context)
        {
            S_staff = staff;
            _context = context;
        }

        #region Insert Staff
        [HttpPost("InsertStaff")]
        public IActionResult InsertStaff(Staff staff)
        {
            return Ok(S_staff.InsertStaff(staff));
        }
        #endregion

        #region Update Staff
        [HttpPut("UpdateStaff")]
        public IActionResult UpdateStaff(Staff customer)
        {
            return Ok(S_staff.UpdateStaff(customer));
        }
        #endregion

        #region Delete Staff
        [HttpDelete("DeleteStaff")]
        public IActionResult DeleteStaff(int Id)
        {
            return Ok(S_staff.DeleteStaff(Id));
        }
        #endregion

        #region Get Staff by Id
        [HttpGet("GetStaffById")]
        public IActionResult GetStaffById(int Id)
        {
            if (S_staff.GetStaffById(Id) == "200")
            {
                return Ok(_context.Staffs.Find(Id));
            }
            else
            {
                return Ok(new { message = "Not Found" });
            }
        }
        #endregion

        #region Get all Staffs
        [HttpGet("GetAllStaff")]
        public IActionResult GetAllStaff()
        {
            return Ok(S_staff.GetAllStaff());
        }
        #endregion
    }
}
