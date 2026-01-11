using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace MVVMFirma.ViewModels
{
    public class AllPawnLoansViewModel : AllViewModel<PawnLoanForAllView>
    {       
        #region Constructor
        public AllPawnLoansViewModel()
            : base()
        {
            base.DisplayName = "Pawn Loans";

        }
        #endregion

        #region Abstract implemented methods
        public override void Sort()
        {
           if (SortField == "Start Date")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.OrderBy(x => x.StartDate));
            }
            if (SortField == "Due Date")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.OrderBy(x => x.DueDate));
            }
            if (SortField == "Total Loan Amount")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.OrderBy(x => x.TotalLoanAmount));
            }
            if (SortField == "Interest Rate")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.OrderBy(x => x.InterestRate));
            }
        }

        public override void Search()
        {
            if (SearchField == "Last name")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.LastName != null && x.LastName.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Agreement Number")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.AgreementNumber != null && x.AgreementNumber.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Start Date")
            {
                if (DateTime.TryParse(SearchTextBox, out DateTime searchDate))
                {
                     List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.StartDate.Date == searchDate.Date));
                }
            }
            if (SearchField == "Due Date")
            {
                if (DateTime.TryParse(SearchTextBox, out DateTime searchDate))
                {
                List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.DueDate.Date == searchDate.Date));
                }

            }
            if (SearchField == "Total Loan Amount")
            {
                if (decimal.TryParse(SearchTextBox, out decimal search))
                    {
                    List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.TotalLoanAmount == search));
                }

            }
            if (SearchField == "Interest Rate")
            {
                if (decimal.TryParse(SearchTextBox, out decimal search))
                {
                     List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.InterestRate == search));
                }
            }
            if (SearchField == "Item")
            {
                List = new ObservableCollection<PawnLoanForAllView>(List.Where(x => x.Items.Any(item => item.ItemName != null && item.ItemName.ToLower().Contains(SearchTextBox))));
            }
        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Start Date", "Due Date", "Total Loan Amount", "Interest Rate" };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> { "Last name", "Agreement Number", "Start Date", "Due Date", "Total Loan Amount", "Interest Rate", "Item" };
        }

        public override void Load()
        {
            List = new ObservableCollection<PawnLoanForAllView>
                (


                from pawnloan in pawnShopEntities.PawnLoans
                where pawnloan.is_active == true
                select new PawnLoanForAllView
                {
                    AgreementNumber = pawnloan.agreement_number,
                    Status = pawnloan.ContractStatuses.name,
                    FirstName = pawnloan.Clients.first_name,
                    LastName = pawnloan.Clients.last_name,
                    StartDate = pawnloan.start_date,
                    DueDate = pawnloan.due_date,
                    TotalLoanAmount = pawnloan.total_loan_amount,
                    InterestRate = pawnloan.InterestRates.rate_percent,
                    Items = pawnloan.PawnLoanItems.Select(item => new PawnItemForAllView
                    {
                        ItemID = item.item_id,
                        ItemName = item.Items.name,
                        EstimatedValue = item.Items.estimated_value,
                        SellingPrice = item.Items.sale_price,
                        Condition = item.Items.ItemConditions.name
                    }).ToList(),
                    PreviousAgreementNumber = pawnloan.previous_loan_id.HasValue ?
                                            pawnShopEntities.PawnLoans
                                            .Where(pl => pl.pawn_loan_id == pawnloan.previous_loan_id.Value)
                                            .Select(pl => pl.agreement_number)
                                            .FirstOrDefault()
                                            : "N/A"

                }
                );

        }
        #endregion
    }
}