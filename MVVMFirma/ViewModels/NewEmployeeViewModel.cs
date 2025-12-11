using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewEmployeeViewModel : OneViewModel<Employees>
    {
        #region Constructor
        public NewEmployeeViewModel()
            : base()
        {
            base.DisplayName = "New Employee";
            item = new Employees();
        }
        #endregion
        #region Properties
        // tylko dla pol towarow ktore bedziemy dodawac - dodajemu properties
        public string First_name
        {
            get
            {
                return item.first_name;
            }
            set
            {
                if (value != item.first_name)
                {
                    item.first_name = value;
                    OnPropertyChanged(() => First_name);
                }
            }
        }

        public string Last_name
        {
            get
            {
                return item.last_name;
            }
            set
            {
                if (value != item.last_name)
                {
                    item.last_name = value;
                    OnPropertyChanged(() => Last_name);
                }
            }
        }
        public string Login
        {
            get
            {
                return item.login;
            }
            set
            {
                if (value != item.login)
                {
                    item.login = value;
                    OnPropertyChanged(() => Login);
                }
            }
        }

        public int Role_id
        {
            get
            {
                return item.employee_role_id;
            }
            set
            {
                if (value != item.employee_role_id)
                {
                    item.employee_role_id = value;
                    OnPropertyChanged(() => Role_id);
                }
            }
        }

        #endregion
        #region Commends
        // komendy przyciskow zapisz i zamknij
        public override void Save()
        {
            item.is_active = true;
            item.history_id = createRecordHistory();
            pawnShopEntities.Employees.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}