using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class SaleItemForAllView
    {   public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal SellingPrice { get; set; }
        public string Condition { get; set; }
    }
}
