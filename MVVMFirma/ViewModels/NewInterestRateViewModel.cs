using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
namespace MVVMFirma.ViewModels
{
    public class NewInterestRateViewModel : OneViewModel<InterestRates>
    {
        #region Constructor
        public NewInterestRateViewModel()
            : base()
        {
            base.DisplayName = "New Interest Rate";
            item = new InterestRates();
        }
        #endregion
        #region Properties
        // tylko dla pol towarow ktore bedziemy dodawac - dodajemu properties

        public string Name
        {
            get
            {
                return item.name;
            }
            set
            {
                if (value != item.name)
                {
                    item.name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }
       public decimal Rate_percent
        {
            get
            {
                return item.rate_percent;
            }
            set
            {
                if (value != item.rate_percent)
                {
                    item.rate_percent = value;
                    OnPropertyChanged(() => Rate_percent);
                }
            }
        }

        public int Period_days
        {
            get
            {
                return item.period_days;
            }
            set
            {
                if (value != item.period_days)
                {
                    item.period_days = value;
                    OnPropertyChanged(() => Period_days);
                }
            }
        }

        public decimal Minimal_interest
        {
            get
            {
                return item.minimal_interest;
            }
            set
            {
                if (value != item.minimal_interest)
                {
                    item.minimal_interest = value;
                    OnPropertyChanged(() => Minimal_interest);
                }
            }
        }

        public bool Is_default
        {
            get
            {
                return item.is_default;
            }
            set
            {
                if (value != item.is_default)
                {
                    item.is_default = value;
                    OnPropertyChanged(() => Is_default);
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
            pawnShopEntities.InterestRates.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}