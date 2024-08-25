using FoodCoupons.core.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCoupons.ReopositoryL
{
    public interface IUserService 
    {
        Task<List<User>> SearchIdsAsync();
        Task<string>GetEmployeeQRCode(string userId);
        Task<List<User>> SearchIdsAsync(int searchValue);

    }
}
