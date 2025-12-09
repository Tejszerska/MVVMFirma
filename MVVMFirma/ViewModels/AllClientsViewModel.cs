using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class AllClientsViewModel : AllViewModel<Clients>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<Clients>
                (
                  pawnShopEntities.Clients.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllClientsViewModel()
            : base()
        {
            base.DisplayName = "Clients";

        }

        #endregion
    }
}