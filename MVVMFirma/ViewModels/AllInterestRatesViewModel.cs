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
public class AllInterestRatesViewModel : AllViewModel<InterestRates>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<InterestRates>
                (
                  pawnShopEntities.InterestRates.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllInterestRatesViewModel()
            : base()
        {
            base.DisplayName = "Interest Rates";

        }

        #endregion
    }
}