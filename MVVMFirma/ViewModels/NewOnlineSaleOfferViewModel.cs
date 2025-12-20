using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewOnlineSaleOfferViewModel : OneViewModel<OnlineSaleOffers>
    {
        #region Constructor
        public NewOnlineSaleOfferViewModel()
            : base()
        {
            base.DisplayName = "New Online Offer";
            item = new OnlineSaleOffers();
        }
        #endregion
        #region Properties
        public int Item_Id
        {
            get
            {
                return item.item_id;
            }
            set
            {
                if (value != item.item_id)
                {
                    item.item_id = value;
                    OnPropertyChanged(() => Item_Id);
                }
            }
        }

        public int Platform_Id
        {
            get
            {
                return item.platform_id;
            }
            set
            {
                if (value != item.platform_id)
                {
                    item.platform_id = value;
                    OnPropertyChanged(() => Platform_Id);
                }
            }
        }

        public string Offer_Title
        {
            get
            {
                return item.offer_title;
            }
            set
            {
                if (value != item.offer_title)
                {
                    item.offer_title = value;
                    OnPropertyChanged(() => Offer_Title);
                }
            }
        }

        public decimal Listing_Price
        {
            get
            {
                return item.listing_price;
            }
            set
            {
                if (value != item.listing_price)
                {
                    item.listing_price = value;
                    OnPropertyChanged(() => Listing_Price);
                }
            }
        }

        public DateTime Listing_Date
        {
            get
            {
                return item.listing_date;
            }
            set
            {
                if (value != item.listing_date)
                {
                    item.listing_date = value;
                    OnPropertyChanged(() => Listing_Date);
                }
            }
        }

        public DateTime Expiration_Date
        {
            get
            {
                return item.expiration_date;
            }
            set
            {
                if (value != item.expiration_date)
                {
                    item.expiration_date = value;
                    OnPropertyChanged(() => Expiration_Date);
                }
            }
        }

        public string Url
        {
            get
            {
                return item.url;
            }
            set
            {
                if (value != item.url)
                {
                    item.url = value;
                    OnPropertyChanged(() => Url);
                }
            }
        }

        public int Status_Id
        {
            get
            {
                return item.status_id;
            }
            set
            {
                if (value != item.status_id)
                {
                    item.status_id = value;
                    OnPropertyChanged(() => Status_Id);
                }
            }
        }

        public int? Views_Count
        {
            get
            {
                return item.views_count;
            }
            set
            {
                if (value != item.views_count)
                {
                    item.views_count = value;
                    OnPropertyChanged(() => Views_Count);
                }
            }
        }

        public int? Messages_Count
        {
            get
            {
                return item.messages_count;
            }
            set
            {
                if (value != item.messages_count)
                {
                    item.messages_count = value;
                    OnPropertyChanged(() => Messages_Count);
                }
            }
        }

        public string Notes
        {
            get
            {
                return item.notes;
            }
            set
            {
                if (value != item.notes)
                {
                    item.notes = value;
                    OnPropertyChanged(() => Notes);
                }
            }
        }
        #endregion
        #region Commends
        // komendy przyciskow zapisz i zamknij
        public override void Save()
        {
            item.is_active = true;
            item.history_id = createRecordHistory();
            pawnShopEntities.OnlineSaleOffers.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}
