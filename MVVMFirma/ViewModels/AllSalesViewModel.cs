using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllSalesViewModel : AllViewModel<Sales>
    {
        #region Abstract implemented methods
        public override void Sort()
        {

        }

        public override void Search()
        {

        }

        public override List<string> getComboboxSortList()
        {
            return null;
        }

        public override List<string> getComboboxSearchList()
        {
            return null;
        }
        public override void Load()
        {

            List = new ObservableCollection<Sales>
                (
                  pawnShopEntities.Sales.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllSalesViewModel()
            : base()
        {
            base.DisplayName = "Sales";

        }

        #endregion
    }
}