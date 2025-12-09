using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;
namespace MVVMFirma.ViewModels
{
    public class AllPurchaseContractsViewModel : AllViewModel<PurchaseContracts>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<PurchaseContracts>
                (
                  pawnShopEntities.PurchaseContracts.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllPurchaseContractsViewModel()
            : base()
        {
            base.DisplayName = "BranPurchaseContractsches";

        }

        #endregion
    }
}