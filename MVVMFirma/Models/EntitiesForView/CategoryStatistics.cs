using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class CategoryStatistics
    {
        public string CategoryName { get; set; }
        public int ItemsCount { get; set; }
        public double AvgDaysInStock { get; set; }
        public decimal TotalPotentialProfit { get; set; } // sale_price minus estimated_value
    }
}

