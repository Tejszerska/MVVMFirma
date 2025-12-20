using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ItemsExtendedView
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemStatus { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public decimal SalePrice{ get; set; }
        public string Condition { get; set; }
        public string AcquisitionSource { get; set; }
        public string BranchName { get; set; }

    }
}
