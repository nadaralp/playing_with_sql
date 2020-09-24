using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithSql.LoadCsv.Models
{
    public class SampleData
    {
        public string Region { get; set; }
        public string Country { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public double TotalRevenue { get; set; }
        public double TotalProfit { get; set; }
    }
}
