using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllPawnLoansViewModel : AllViewModel<PawnLoans>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<PawnLoans>
                (
                  pawnShopEntities.PawnLoans.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllPawnLoansViewModel()
            : base()
        {
            base.DisplayName = "Pawn Loans";

        }

        #endregion
    }
}