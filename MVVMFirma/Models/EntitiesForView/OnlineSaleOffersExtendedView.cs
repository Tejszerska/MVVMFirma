using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class OnlineSaleOffersExtendedView
    {
        public int OnlineSaleOfferId { get; set; }
        public string ItemName { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string  OfferTitle { get; set; }

        public string Link { get; set; }


    }
}
