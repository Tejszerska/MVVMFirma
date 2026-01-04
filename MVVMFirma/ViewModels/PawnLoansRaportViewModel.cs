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
    public class PawnLoansRaportViewModel : WorkspaceViewModel
    {
        #region Database
        public readonly PawnShopEntities pawnShopEntities;
        #endregion
        #region Contructor
        public PawnLoansRaportViewModel()
            
        {
            pawnShopEntities = new PawnShopEntities();
            base.DisplayName = "Pawn Agreements Overview";
            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;
            //StartDate= new DateTime(2025,09,01);
            //EndDate = new DateTime(2025,09,30);
            StatusId = 1;
            TotalLoanAmount = 0;
        }
        #endregion
        #region Fields and properties
        private DateTime _StaryDate;
        public DateTime StartDate
        {
            get { return _StaryDate; }
            set
            {
                if (value != _StaryDate)
                {
                    _StaryDate = value;
                    OnPropertyChanged(() => StartDate);
                }
            }
        }
        private DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                if (value != _EndDate)
                {
                    _EndDate = value;
                    OnPropertyChanged(() => EndDate);
                }
            }
        }
        private int _StatusId;
        public int StatusId
        {
            get { return _StatusId; }
            set
            {
                if (value != _StatusId)
                {
                    _StatusId = value;
                    OnPropertyChanged(() => StatusId);
                }
            }
        }
        public IQueryable<KeyAndValue> StatusComboBoxItems
        {
            get
            {
                return
                    new ContractStatusesB(pawnShopEntities).GetPawnLoansStatusesKeyAndValue();
            }
        }
        private decimal? _TotalLoanAmount;
        public decimal? TotalLoanAmount
        {
            get { return _TotalLoanAmount; }
            set
            {
                if (value != _TotalLoanAmount)
                {
                    _TotalLoanAmount = value;
                    OnPropertyChanged(() => TotalLoanAmount);
                }
            }
        }
        private int? _AgreementCount;
        public int? AgreementCount
        {
            get { return _AgreementCount; }
            set
            {
                if (value != _AgreementCount)
                {
                    _AgreementCount = value;
                    OnPropertyChanged(() => AgreementCount);
                }
            }
        }

        private decimal? _TotalInterest;
        public decimal? TotalInterest
        {
            get { return _TotalInterest; }
            set
            {
                if (value != _TotalInterest)
                {
                    _TotalInterest = value;
                    OnPropertyChanged(() => TotalInterest);
                }
            }
        }

        private decimal _EstimatedCollateral;
        public decimal EstimatedCollateral
        {
            get { return _EstimatedCollateral; }
            set
            {
                if (value != _EstimatedCollateral)
                {
                    _EstimatedCollateral = value;
                    OnPropertyChanged(() => EstimatedCollateral);
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
                    _GenerateRaportCommand = new BaseCommand(generatePawnLoanRaportClick);
                }
                return _GenerateRaportCommand;
            }
        }
        private void generatePawnLoanRaportClick()
        {
            EstimatedCollateral =
                new PawnLoanSummaryB(pawnShopEntities)
                .GetEstimatedCollateral(
                    StatusId,
                    StartDate,
                    EndDate);
            TotalInterest =
                new PawnLoanSummaryB(pawnShopEntities)
                .GetTotalInterest(
                    StatusId,
                    StartDate,
                    EndDate);
            AgreementCount =
                new PawnLoanSummaryB(pawnShopEntities)
                .GetPawnLoanAgreementCount(
                    StatusId,
                    StartDate,
                    EndDate);
            TotalLoanAmount =
                new PawnLoanSummaryB(pawnShopEntities)
                .GetTotalLoanAmount(
                    StatusId,
                    StartDate,
                    EndDate);
        }
        #endregion
    }
}
