using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RecordHistoryExtendedView
    {
        public int RecordHistoryID { get; set; }
        public string CreateEmployee { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBranch { get; set; }
        public string ModifyEmployee { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string DeleteEmployee { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
