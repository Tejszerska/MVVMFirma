using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllSalesItemsViewModel : AllViewModel<SalesItems>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<SalesItems>
                (
                  pawnShopEntities.SalesItems.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllSalesItemsViewModel()
            : base()
        {
            base.DisplayName = "SalesItems";
        }

        #endregion
    }
}