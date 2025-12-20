using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PawnLoanForAllView
    {
        public String AgreementNumber { get; set; }
        public String Status { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalLoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public String PreviousAgreementNumber { get; set; }
        public String Items { get; set; }

    }
}
