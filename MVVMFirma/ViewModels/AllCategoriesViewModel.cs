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
public class AllCategoriesViewModel : AllViewModel<Categories>

    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<Categories>
                (
                  pawnShopEntities.Categories.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllCategoriesViewModel()
            : base()
        {
            base.DisplayName = "Categories";

        }

        #endregion
    }
}