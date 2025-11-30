using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
public class AllCategoriesViewModel : WorkspaceViewModel
    
  {
        #region DataBase
        // ten obiekt reprezentuje bd
        private readonly PawnShopEntities pawnShopEntities;
        #endregion
        #region Command
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new BaseCommand(load);
                return _LoadCommand;
            }
        }
        #endregion
        #region Lista
        private ObservableCollection<Categories> _List;
        public ObservableCollection<Categories> List
        {
            get
            {
                if (_List == null) load();
                return _List;

            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List); // odswieza wyswietlanie listy
                }
            }
        }

        private void load()
        {

            List = new ObservableCollection<Categories>
                (
                  pawnShopEntities.Categories.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllCategoriesViewModel()
        {
            base.DisplayName = "Categories";
            pawnShopEntities = new PawnShopEntities();
        }

        #endregion
    }
}