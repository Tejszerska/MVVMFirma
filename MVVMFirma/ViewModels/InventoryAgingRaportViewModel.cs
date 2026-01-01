using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.BussinessLogic;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class InventoryAgingRaportViewModel : WorkspaceViewModel
    {
        #region Database
        public readonly PawnShopEntities pawnShopEntities;
        #endregion
        #region Contructor
        public InventoryAgingRaportViewModel()
        {
            base.DisplayName = "Inventory Aging Report";
            pawnShopEntities = new PawnShopEntities();
            // Inicjalizacja domyślnych wartości
            CriticalItemsCount = 0;
            TotalCriticalValue = 0;

            // Załaduj dane przy starcie (opcjonalnie)
            generateAgingRaportClick();
        }
        #endregion
        #region Fields and properties
        private ObservableCollection<InventoryAging> _AgingItems;
        public ObservableCollection<InventoryAging> AgingItems
        {
            get { return _AgingItems; }
            set
            {
                if (value != _AgingItems)
                {
                    _AgingItems = value;
                    OnPropertyChanged(() => AgingItems);
                }
            }
        }

        private int _CriticalItemsCount;
        public int CriticalItemsCount
        {
            get { return _CriticalItemsCount; }
            set
            {
                if (value != _CriticalItemsCount)
                {
                    _CriticalItemsCount = value;
                    OnPropertyChanged(() => CriticalItemsCount);
                }
            }
        }

        private decimal _TotalCriticalValue;
        public decimal TotalCriticalValue
        {
            get { return _TotalCriticalValue; }
            set
            {
                if (value != _TotalCriticalValue)
                {
                    _TotalCriticalValue = value;
                    OnPropertyChanged(() => TotalCriticalValue);
                }
            }
        }
        #endregion
        #region Commands 
        private BaseCommand _GenerateRaportCommand;
        public ICommand GenerateRaportCommand
        {
            get
            {
                if (_GenerateRaportCommand == null)
                {
                    _GenerateRaportCommand = new BaseCommand(generateAgingRaportClick);
                }
                return _GenerateRaportCommand;
            }
        }

        private void generateAgingRaportClick()
        {
            var logic = new InventoryAgingB(pawnShopEntities);

            var results = logic.GetAgingReport().ToList();

            AgingItems = new ObservableCollection<InventoryAging>(results);

            CriticalItemsCount = results.Count(x => x.DaysInStock > 90);
            TotalCriticalValue = results.Where(x => x.DaysInStock > 90).Sum(x => x.EstimatedValue);
        }
        #endregion
    }
}
