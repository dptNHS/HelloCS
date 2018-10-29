using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCS
{
    public class TimesheetDay
    {
        public string Name{ get; set;}
        public double Hours { get; set; }
        public decimal NormalPay { get; set; }
        public decimal Overtime { get; set; }
    }
}
