using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
public class AllItemsViewModel : AllViewModel<Items>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<Items>
                (
                  pawnShopEntities.Items.ToList()
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