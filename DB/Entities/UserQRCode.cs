using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCoupons.core.DL.Entities
{
    public class UserQRCode : BaseEntity
    {
        [Required]
        public int Id { get; set; } //Pk

        public string EmployeeId { get; set; }
        public byte[] QRCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
