using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
namespace MVVMFirma.ViewModels
{
    public class AllPriceHistoryViewModel : AllViewModel<PriceHistoryExtededView>
    {
        #region  Abstract implemented methods
        public override void Sort()
        {
            if (SortField == "ID")
            {
                List = new ObservableCollection<PriceHistoryExtededView>(List.OrderBy(x => x.ItemID));
            }
            if (SortField == "Date of change")
            {
                List = new ObservableCollection<PriceHistoryExtededView>(List.OrderBy(x => x.ChangeDate));
            }
            if (SortField == "New price")
            {
                List = new ObservableCollection<PriceHistoryExtededView>(List.OrderBy(x => x.NewPrice));
            }
            if (SortField == "Old price")
            {
                List = new ObservableCollection<PriceHistoryExtededView>(List.OrderBy(x => x.OldPrice));
            }
        }

        public override void Search()
        {
            if (SearchField == "Name")
            {
                List = new ObservableCollection<PriceHistoryExtededView>(List.Where(x => x.ItemName != null && x.ItemName.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "ID")
            {
                if (int.TryParse(SearchTextBox, out int search))
                {
                    List = new ObservableCollection<PriceHistoryExtededView>(List.Where(x => x.ItemID == search));
                }

            }
            if (SearchField == "Date of change")
            {
                if (DateTime.TryParse(SearchTextBox, out DateTime searchDate))
                {
                     List = new ObservableCollection<PriceHistoryExtededView>(List.Where(x => x.ChangeDate.Date == searchDate.Date));
                }
            }
            if (SearchField == "Employee")
            {
                List = new ObservableCollection<PriceHistoryExtededView>(List.Where(x => x.ChangedByEmployee != null && x.ChangedByEmployee.ToLower().Contains(SearchTextBox)));
            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> {"ID", "Date of change", "New price", "Old price"  };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> {"Name", "ID", "Date of change", "Employee"};
        }
        public override void Load()
        {

            List = new ObservableCollection<PriceHistoryExtededView>
                (
                from pricehistory in pawnShopEntities.PriceHistory
                select new PriceHistoryExtededView
                {
                    ItemID = pricehistory.item_id,
                    ItemName = pricehistory.Items.name,
                    ChangeDate = pricehistory.changed_at,
                    OldPrice = pricehistory.previous_value,
                    NewPrice = pricehistory.new_value,
                    ChangedByEmployee = pricehistory.Employees.first_name + " " + pricehistory.Employees.last_name
                }
                );
        }
        #endregion Abstract implemented methods
     
        #region Constructor
        public AllPriceHistoryViewModel()
            : base()
        {
            base.DisplayName = "Price History";

        }

        #endregion
    }
}