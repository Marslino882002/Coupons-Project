using FoodCoupons.core.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class acc_monitor_log
    {


        public int Id { get; set; }
        public DateTime time { get; set; }
        public int device_id { get; set; }
        public string device_name { get; set; }

        public string pin { get; set; } 
        public bool status { get; set; }
        public int event_point_id { get; set; }

    }
}
