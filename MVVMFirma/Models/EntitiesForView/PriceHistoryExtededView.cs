using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PriceHistoryExtededView
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public DateTime ChangeDate { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string ChangedByEmployee { get; set; }
    }
}
