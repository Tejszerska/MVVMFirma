using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllBranchesViewModel : AllViewModel<Branches>
    {
       #region 
        public override void Load()
        {

            List = new ObservableCollection<Branches>
                (
                  pawnShopEntities.Branches.ToList()
                );
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