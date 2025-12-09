using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
    public class AllPaymentsViewModel : AllViewModel<Payments>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<Payments>
                (
                  pawnShopEntities.Payments.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllPaymentsViewModel()
            : base()
        {
            base.DisplayName = "Payments";

        }
        #endregion
    }
}