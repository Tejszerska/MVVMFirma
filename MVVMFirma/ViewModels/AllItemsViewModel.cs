using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
public class AllItemsViewModel : AllViewModel<ItemsExtendedView>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<ItemsExtendedView>
                (

                   from item in pawnShopEntities.Items
                    where item.is_active == true
                    select new ItemsExtendedView
                    {
                        ItemId = item.item_id,
                        ItemName = item.name,
                        ItemStatus = item.ItemStatuses.name,
                        CategoryName = item.Categories.name,
                        Description = item.description,
                        EstimatedValue = item.estimated_value,
                        SalePrice = item.sale_price,
                        Condition = item.ItemConditions.name,
                        AcquisitionSource = item.AcquisitionSourceTypes.name,
                        BranchName = item.Branches.name

                    }
                );
        }
        #endregion
        #region Constructor
        public AllItemsViewModel()
            : base()
        {
            base.DisplayName = "Items";

        }

        #endregion
    }
}