using MVVMFirma.Helper;
using MVVMFirma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    // klasa z której beda dziedziczyc wszystkie ViewModele wyswieltajace wszystki obiekty biznesowe
    public abstract class AllViewModel<T> : WorkspaceViewModel
    {
        #region DataBase
        // ten obiekt reprezentuje bd
        protected readonly PawnShopEntities1 pawnShopEntities;
        #endregion
        #region Command
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) _LoadCommand = new BaseCommand(Load);
                return _LoadCommand;
            }
        }
        #endregion
        #region Lista
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) Load();
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

        public abstract void Load();

        #endregion
        #region Constructor
        public AllViewModel()
        {
            pawnShopEntities = new PawnShopEntities1();
        }

        #endregion
    }
}
