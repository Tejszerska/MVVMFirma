using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
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
public class AllCategoriesViewModel : AllViewModel<CategoriesExtendedView>

    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<CategoriesExtendedView>
                (

                from category in pawnShopEntities.Categories
                where category.is_active == true
                select new CategoriesExtendedView
                {
                    CategoryId = category.category_id,
                    Name = category.name,
                    ParentCategory = category.parent_id.HasValue ?
                                     pawnShopEntities.Categories
                                     .Where(c => c.category_id == category.parent_id.Value)
                                     .Select(c => c.name)
                                     .FirstOrDefault()
                                     : " - "
                }                  
                );
        }

        public override void Sort()
        {
            
            if (SortField == "name")
            {
                List = new ObservableCollection<CategoriesExtendedView>(List.OrderBy(x => x.Name));
            }
            if (SortField == "parent")
            {
                List = new ObservableCollection<CategoriesExtendedView>(List.OrderBy(x => x.ParentCategory));
            }
        }

        public override void Search()
        {
            if (SearchField == "name")
            {
                List = new ObservableCollection<CategoriesExtendedView>(List.Where(x => x.Name != null && x.Name.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "parent")
            {
                List = new ObservableCollection<CategoriesExtendedView>(List.Where(x => x.ParentCategory != null && x.ParentCategory.ToLower().StartsWith(SearchTextBox)));
            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "name", "parent" };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> { "name", "parent" };
        }
        #endregion  Abstract implemented methods

        #region Constructor
        public AllCategoriesViewModel()
            : base()
        {
            base.DisplayName = "Categories";

        }

        #endregion
    }
}