using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class RecordsHistoryViewModel : AllViewModel<RecordHistoryExtendedView>
    {
        #region 
        public override void Load()
        {
            List = new ObservableCollection<RecordHistoryExtendedView>
                (
                from recordhistory in pawnShopEntities.RecordHistory
                select new RecordHistoryExtendedView
                {
                    RecordHistoryID = recordhistory.history_id,
                    CreateEmployee = pawnShopEntities.Employees
                                     .Where(e => e.employee_id == recordhistory.created_by)
                                     .Select(e => e.first_name + " " + e.last_name)
                                     .FirstOrDefault(),
                    CreateDate = recordhistory.created_at,
                    CreateBranch = pawnShopEntities.Branches
                                   .Where(b => b.branch_id == recordhistory.created_in)
                                   .Select(b => b.name)
                                   .FirstOrDefault(),
                    ModifyEmployee = pawnShopEntities.Employees
                                     .Where(e => e.employee_id == recordhistory.modified_by)
                                     .Select(e => e.first_name + " " + e.last_name)
                                     .FirstOrDefault(),
                    ModifyDate = recordhistory.modified_at,
                    DeleteEmployee = pawnShopEntities.Employees
                                     .Where(e => e.employee_id == recordhistory.deleted_by)
                                     .Select(e => e.first_name + " " + e.last_name)
                                     .FirstOrDefault(),
                    DeleteDate = recordhistory.deleted_at
                }
                );
        }
        #endregion
        #region Constructor
        public RecordsHistoryViewModel()
            : base()
        {
            base.DisplayName = "Record History";
        }
        #endregion
    }
}
