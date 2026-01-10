using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
public class AllOnlineSaleOffersViewModel : AllViewModel<OnlineSaleOffersExtendedView>
    {
        #region  Abstract implemented methods
        public override void Sort()
        {
            if (SortField == "Expiration Date")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.OrderBy(x => x.ExpirationDate));
            }
            if (SortField == "Price")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.OrderBy(x => x.Price));
            }
            if (SortField == "Offer ID")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.OrderBy(x => x.OnlineSaleOfferId));
            }
        }

        public override void Search()
        {
            if (SearchField == "Name")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.Where(x => x.ItemName != null && x.ItemName.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Platform")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.Where(x => x.Platform != null && x.Platform.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Expiration Date")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.Where(x => x.ExpirationDate.ToString().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Price")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.Where(x => x.Price.ToString().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Offer ID")
            {
                List = new ObservableCollection<OnlineSaleOffersExtendedView>(List.Where(x => x.OnlineSaleOfferId.ToString().StartsWith(SearchTextBox)));
            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Expiration Date", "Price", "Offer ID" };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> { "Name", "Platform", "Expiration Date", "Price", "Offer ID" };
        }
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
