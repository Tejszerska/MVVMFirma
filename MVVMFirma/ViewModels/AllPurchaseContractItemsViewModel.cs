using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllPurchaseContractItemsViewModel : AllViewModel<PurchaseContractItems>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<PurchaseContractItems>
                (
                  pawnShopEntities.PurchaseContractItems.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllPurchaseContractItemsViewModel()
            : base()
        {
            base.DisplayName = "Purchase Contract Items";

        }
        #endregion
    }
}
