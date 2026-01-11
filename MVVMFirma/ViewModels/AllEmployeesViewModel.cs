using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
public class AllEmployeesViewModel : AllViewModel<Employees>
    {
        #region  Abstract implemented methods
        public override void Sort()
        {
            if(SortField == "Last name")
            {
                List = new ObservableCollection<Employees>(List.OrderBy(x => x.last_name));
            }
            if (SortField == "Login")
            {
                List = new ObservableCollection<Employees>(List.OrderBy(x => x.login));
            }
            if (SortField == "ID")
            {
                List = new ObservableCollection<Employees>(List.OrderBy(x => x.employee_id));
            }
        }

        public override void Search()
        {
            if (SearchField == "Last name")
            {
                List = new ObservableCollection<Employees>(List.Where(x => x.last_name != null && x.last_name.ToLower().StartsWith(SearchTextBox)));
            }
            if(SearchField == "Login")
            {
                List = new ObservableCollection<Employees>(List.Where(x => x.login != null && x.login.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "ID")
            {
                if (int.TryParse(SearchTextBox, out int search))
                {
                    List = new ObservableCollection<Employees>(List.Where(x => x.employee_id == search));
                }

            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Last name", "Login", "ID"};
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> { "Last name", "Login", "ID" };
        }
        public override void Load()
        {

            List = new ObservableCollection<Employees>
                (
                  pawnShopEntities.Employees.Where(x => x.is_active == true).ToList()
                );
        }
        #endregion
        #region Constructor
        public AllEmployeesViewModel()
            : base()
        {
            base.DisplayName = "Employees";

        }

        #endregion
    }
}