using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class CategoriesExtendedView
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ParentCategory { get; set; }
    }
}
