using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DB;
namespace FoodCoupons.ReopositoryL
{
    public interface IdSearch 
    {
        Task<List<User>> SearchIdsAsync(int searchValue);
    }
}
