using MVVMFirma.Helper;
using MVVMFirma.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace MVVMFirma.ViewModels
{
    public class AllPurchaseContractsViewModel : WorkspaceViewModel
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
        private ObservableCollection<PurchaseContracts> _List;
        public ObservableCollection<PurchaseContracts> List
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

            List = new ObservableCollection<PurchaseContracts>
                (
                  pawnShopEntities.PurchaseContracts.ToList()
                );
        }
        #endregion
        #region Constructor
        public AllPurchaseContractsViewModel()
        {
            base.DisplayName = "Purchase Contracts";
            pawnShopEntities = new PawnShopEntities();
        }

        #endregion
    }
}