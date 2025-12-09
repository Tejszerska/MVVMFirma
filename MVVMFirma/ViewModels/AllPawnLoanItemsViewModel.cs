using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;
namespace MVVMFirma.ViewModels
{
    public class AllPawnLoanItemsViewModel : AllViewModel<PawnLoanItems>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<PawnLoanItems>
                (
                  pawnShopEntities.PawnLoanItems.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllPawnLoanItemsViewModel()
            : base()
        {
            base.DisplayName = "PawnLoanItems";

        }

        #endregion
    }
}