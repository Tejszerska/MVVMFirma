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
        #region 
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
        #endregion
        #region Constructor
        public AllPriceHistoryViewModel()
            : base()
        {
            base.DisplayName = "Price History";

        }

        #endregion
    }
}