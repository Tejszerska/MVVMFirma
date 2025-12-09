using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class SinglePriceHistoryViewModel : AllViewModel<PriceHistory>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<PriceHistory>
                (
                  pawnShopEntities.PriceHistory.ToList()
                );
        }
        #endregion
        #region Constructor
        public SinglePriceHistoryViewModel()
            : base()
        {
            base.DisplayName = "Branches";

        }

        #endregion
    }
}