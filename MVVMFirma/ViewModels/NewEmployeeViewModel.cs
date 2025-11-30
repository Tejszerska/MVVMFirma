using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewEmployeeViewModel : WorkspaceViewModel
    {
        public NewEmployeeViewModel()
        {
            base.DisplayName = "New Employee";
        }
    }
}

