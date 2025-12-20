using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
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

        #region List

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