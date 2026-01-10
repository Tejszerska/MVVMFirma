using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllBranchesViewModel : AllViewModel<Branches>
    {
        #region Abstract implemented methods
        public override void Load()
        {

            List = new ObservableCollection<Branches>
                (
                pawnShopEntities.Branches.Where(x => x.is_active == true).ToList()
                
                );
        }

        public override void Sort()
        {
            if(SortField == "address")
            {
                List = new ObservableCollection<Branches>(List.OrderBy(x => x.address));
            }
            if (SortField == "name")
            {
                List = new ObservableCollection<Branches>(List.OrderBy(x => x.name));
            }
        }

        public override void Search()
        {
            if (SearchField == "name")
            {
                List = new ObservableCollection<Branches>(List.Where(x => x.name != null && x.name.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "address")
            {
                List = new ObservableCollection<Branches>(List.Where(x => x.address != null && x.address.ToLower().StartsWith(SearchTextBox)));
            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> {"address" };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> {"name", "address"};
        
        }
        #endregion
        #region Constructor
        public AllBranchesViewModel()
            :base()
        {
            base.DisplayName = "Branches";            
        }
        #endregion
    }
}