using DB;
using FoodCoupons.core.DL.Entities;
using FoodCoupons.ReopositoryL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OfficeOpenXml;


namespace Services.SearchService
{
    public class UserService : IUserService

    {

        private readonly DBContext _context;




        public UserService(DBContext context)
        {
            _context = context;
        }
        public async Task<List<User>> SearchIdsAsync()
        {

            var employees = _context.Users.ToList();
            return employees;


        }
        public async Task<string> GetEmployeeQRCode(string userId)
        {
            var id = Convert.ToInt32(userId);
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            var qrCode = _context.UserQRCodes.FirstOrDefault(x => x.EmployeeId == user.EmployeeId.ToString());
            var result = qrCode == null ?"QR code not found":Convert.ToBase64String(qrCode.QRCode);
            return result;
        }


        //overloading
        public async Task<List<User>> SearchIdsAsync(int searchValue)
        {

            var filteredUsers = new List<User>();
            var searchTerm = searchValue.ToString();
            var employees = _context.Users.ToList();
            filteredUsers = employees.Where(x => x.EmployeeId.ToString().StartsWith(searchTerm)).ToList();
            return filteredUsers;


        }








    }
}




/*
 
 
  var filteredIds = await _context.Users
                .Where(item => item.EmployeeId == search_ITerm)
                .Select(item => item.EmployeeId)
                .ToListAsync();

            return filteredIds;
 
 
 */
















/*private readonly string _filePath;

    public ServiceOfSearch(string filePath)
    {
        _filePath = filePath;
    }

    public ICollection<string> SearchIds(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> SearchIdsAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public ICollection<string> SearchIdsAsync(int id)
    {
        throw new NotImplementedException();
    }
}*/