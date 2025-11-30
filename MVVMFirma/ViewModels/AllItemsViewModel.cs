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
public class AllItemsViewModel : WorkspaceViewModel
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
        private ObservableCollection<Items> _List;
        public ObservableCollection<Items> List
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

            List = new ObservableCollection<Items>
                (
                  pawnShopEntities.Items.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllItemsViewModel()
        {
            base.DisplayName = "Items";
            pawnShopEntities = new PawnShopEntities();
        }

        #endregion
    }
}
