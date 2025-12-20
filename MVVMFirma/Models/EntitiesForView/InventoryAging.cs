using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class InventoryAging
    {
        public string ItemName { get; set; }
        public int DaysInStock { get; set; }
        public decimal EstimatedValue { get; set; }
        public string AgeCategory { get; set; }
    }
}
