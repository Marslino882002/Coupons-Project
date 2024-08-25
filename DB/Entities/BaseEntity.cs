using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCoupons.core.DL.Entities
{
    public class BaseEntity
    {
        

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string?UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


    }
}
