using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PurchaseContractForAllView
    {
        public String AgreementNumber { get; set; }
        public String Status { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PawnItemForAllView> Items { get; set; }
    }
}
