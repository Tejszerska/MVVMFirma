using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace MVVMFirma.ViewModels
{
    public class AllPurchaseContractsViewModel : AllViewModel<PurchaseContracts>
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