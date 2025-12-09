using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllSalesViewModel : AllViewModel<Sales>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<Sales>
                (
                  pawnShopEntities.Sales.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllSalesViewModel()
            : base()
        {
            base.DisplayName = "Sales";

        }

        #endregion
    }
}