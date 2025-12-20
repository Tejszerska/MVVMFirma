using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
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
public class AllEmployeeShiftsViewModel : AllViewModel<EmpoloyeeShiftExtendedView>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<EmpoloyeeShiftExtendedView>
                (
                 from employeeShift in pawnShopEntities.EmployeeShifts
                 // where employeeShift.is_active == true zaciagnac od nowa baze
                 select new EmpoloyeeShiftExtendedView
                 {
                     EmployeeShiftId = employeeShift.shift_id,
                     EmployeeFirstName = employeeShift.Employees.first_name,
                     EmployeeLastName = employeeShift.Employees.last_name,
                     BranchName = employeeShift.Branches.name,
                     ShiftStart = employeeShift.shift_start,
                     ShiftEnd = employeeShift.shift_end,
                     Notes = employeeShift.notes
                 }
                );
        }
        #endregion
        #region Constructor
        public AllEmployeeShiftsViewModel()
            : base()
        {
            base.DisplayName = "Employee Shifts";

        }
        #endregion
    }
}