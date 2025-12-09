using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
public class AllOnlineSaleOffersViewModel : AllViewModel<OnlineSaleOffers>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<OnlineSaleOffers>
                (
                  pawnShopEntities.OnlineSaleOffers.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllOnlineSaleOffersViewModel()
            : base()
        {
            base.DisplayName = "OnlineSaleOffers";

        }

        #endregion
    }
}
