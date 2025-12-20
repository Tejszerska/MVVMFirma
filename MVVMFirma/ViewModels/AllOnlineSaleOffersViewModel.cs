using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
public class AllOnlineSaleOffersViewModel : AllViewModel<OnlineSaleOffersExtendedView>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<OnlineSaleOffersExtendedView>
                (
                from sale in pawnShopEntities.OnlineSaleOffers
                where sale.is_active == true
                select new OnlineSaleOffersExtendedView
                {
                    OnlineSaleOfferId = sale.online_offer_id,
                    ItemName = sale.Items.name,
                    Platform = sale.OnlinePlatforms.name,
                    Price = sale.listing_price,
                    ExpirationDate = sale.expiration_date,
                    OfferTitle = sale.offer_title,
                    Link  = sale.url
                }
                );
        }
        #endregion
        #region Constructor
        public AllOnlineSaleOffersViewModel()
            : base()
        {
            base.DisplayName = "Online Sale Offers";

        }

        #endregion
    }
}
