using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllPurchaseContractItemsViewModel : AllViewModel<PurchaseContractItems>
    {
        #region  Abstract implemented methods
        public override void Sort()
        {

        }

        public override void Search()
        {

        }

        public override List<string> getComboboxSortList()
        {
            return null;
        }

        public override List<string> getComboboxSearchList()
        {
            return null;
        }
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
