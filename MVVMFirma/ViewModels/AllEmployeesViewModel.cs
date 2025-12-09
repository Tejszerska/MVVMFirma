using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
public class AllEmployeesViewModel : AllViewModel<Employees>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<Employees>
                (
                  pawnShopEntities.Employees.ToList()
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