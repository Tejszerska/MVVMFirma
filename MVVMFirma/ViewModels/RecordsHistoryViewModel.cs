using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class RecordsHistoryViewModel : AllViewModel<RecordHistory>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<RecordHistory>
                (
                  pawnShopEntities.RecordHistory.ToList()
                );
        }
        #endregion
        #region Constructor
        public RecordsHistoryViewModel()
            : base()
        {
            base.DisplayName = "RecordHistory";
        }
        #endregion
    }
}
