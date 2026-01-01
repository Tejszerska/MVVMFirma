using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Linq;
using MVVMFirma.Models.BussinesLogic;
using System.Windows.Input;
using MVVMFirma.Helper;
using MVVMFirma.Models.BussinessLogic;

namespace MVVMFirma.ViewModels
{
    public class CategoryStatsRaportViewModel : WorkspaceViewModel
    {
        #region Database
        public readonly PawnShopEntities pawnShopEntities;
        #endregion
        #region Contructor
        public CategoryStatsRaportViewModel()
        {
            pawnShopEntities = new PawnShopEntities();
            base.DisplayName = "Category Statistics";
            CategoryId = 0;
            ItemsCount = 0;
            AvgDaysInStock = 0;
            TotalPotentialProfit = 0;
        }
        #endregion
        #region Fields and properties
        private int _CategoryId;
        public int CategoryId
        {
            get { return _CategoryId; }
            set
            {
                if (value != _CategoryId)
                {
                    _CategoryId = value;
                    OnPropertyChanged(() => CategoryId);
                }
            }
        }
        public IQueryable<KeyAndValue> CategoryComboBoxItems
        {
            get
            {
                return new CategoriesB(pawnShopEntities).GetItemCategoriesKeyAndValue();
            }
        }
        private int _ItemsCount;
        public int ItemsCount
        {
            get { return _ItemsCount; }
            set
            {
                if (value != _ItemsCount)
                {
                    _ItemsCount = value;
                    OnPropertyChanged(() => ItemsCount);
                }
            }
        }
        private double _AvgDaysInStock;
        public double AvgDaysInStock
        {
            get { return _AvgDaysInStock; }
            set
            {
                if (value != _AvgDaysInStock)
                {
                    _AvgDaysInStock = value;
                    OnPropertyChanged(() => AvgDaysInStock);
                }
            }
        }
        private decimal _TotalPotentialProfit;
        public decimal TotalPotentialProfit
        {
            get { return _TotalPotentialProfit; }
            set
            {
                if (value != _TotalPotentialProfit)
                {
                    _TotalPotentialProfit = value;
                    OnPropertyChanged(() => TotalPotentialProfit);
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
                    _GenerateRaportCommand = new BaseCommand(generateCategoryStatsClick);
                }
                return _GenerateRaportCommand;
            }
        }
        private void generateCategoryStatsClick()
        {
            ItemsCount =
                new CategoryStatsSummaryB(pawnShopEntities)
                .GetItemsCount(CategoryId);

            AvgDaysInStock =
                new CategoryStatsSummaryB(pawnShopEntities)
                .GetAverageAging(CategoryId);

            TotalPotentialProfit =
                new CategoryStatsSummaryB(pawnShopEntities)
                .GetTotalPotentialProfit(CategoryId);
        }
        #endregion
    }
}