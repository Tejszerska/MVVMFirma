using MVVMFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public abstract class BaseDBViewModel : WorkspaceViewModel
    {
        #region Database
        public readonly PawnShopEntities pawnShopEntities;
        #endregion
        #region Contructor
        public BaseDBViewModel(PawnShopEntities pawnShopEntities)
        {
            this.pawnShopEntities = new PawnShopEntities();
        }
        #endregion

    }
}
