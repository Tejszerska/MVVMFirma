using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
public class AllInterestRatesViewModel : AllViewModel<InterestRates>
    {
        #region  Abstract implemented methods
        public override void Sort()
        {
            if (SortField == "Name")
            {
                List = new ObservableCollection<InterestRates>(List.OrderBy(x => x.name));
            }
            if (SortField == "Minimal interest")
            {
                List = new ObservableCollection<InterestRates>(List.OrderBy(x => x.minimal_interest));
            }
            if (SortField == "Period days")
            {
                List = new ObservableCollection<InterestRates>(List.OrderBy(x => x.period_days));
            }
            if (SortField == "Rate percent")
            {
                List = new ObservableCollection<InterestRates>(List.OrderBy(x => x.rate_percent));
            }
            if (SortField == "Default")
            {
                List = new ObservableCollection<InterestRates>(List.OrderByDescending(x => x.is_default));
            }
        }

        public override void Search()
        {
            if (SearchField == "Name")
            {
                List = new ObservableCollection<InterestRates>(List.Where(x => x.name != null && x.name.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Minimal interest")
            {
                if (decimal.TryParse(SearchTextBox, out decimal search))
                    {
                    List = new ObservableCollection<InterestRates>(List.Where(x => x.minimal_interest == search));
                }

            }
            if (SearchField == "Period days")
            {
                if (int.TryParse(SearchTextBox, out int search))
                    {
                    List = new ObservableCollection<InterestRates>(List.Where(x => x.period_days == search));
                }
            }
            if (SearchField == "Rate percent")
            {
                if (decimal.TryParse(SearchTextBox, out decimal search))
                {
                    List = new ObservableCollection<InterestRates>(List.Where(x => x.rate_percent == search));
                }

            }
            if (SearchField == "Default")
            {
                SearchTextBox = "Default rate";

                List = new ObservableCollection<InterestRates>(List.Where(x => x.is_default == true));
            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Name", "Minimal interest", "Period days", "Rate percent" };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> { "Default", "Name", "Minimal interest", "Period days", "Rate percent" };
        }
        public override void Load()
        {

            List = new ObservableCollection<InterestRates>
                (
                  pawnShopEntities.InterestRates.Where(x => x.is_active == true).ToList()
                );
        }
        #endregion
        #region Constructor
        public AllInterestRatesViewModel()
            : base()
        {
            base.DisplayName = "Interest Rates";

        }

        #endregion
    }
}