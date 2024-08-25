using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace FoodCoupons.core.DL.Entities
{
    public class User: BaseEntity
    {

        
        public int Id { get; set; } //Pk
        public string Ar_Full_Name { get; set; }

        public string UserName { get; set; }
        public int EmployeeId { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }


    }
}
