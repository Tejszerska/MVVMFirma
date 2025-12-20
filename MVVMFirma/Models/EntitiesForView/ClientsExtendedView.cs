using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ClientsExtendedView
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber{ get; set; }
        public string PESEL{ get; set; }
        public string Address{ get; set; }
        public string AddressSource{ get; set; }
        public string Phone{ get; set; }
        public string Email{ get; set; }
    }
}
