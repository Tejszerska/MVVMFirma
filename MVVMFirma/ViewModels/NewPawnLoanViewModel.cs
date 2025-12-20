using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewPawnLoanViewModel : OneViewModel<PawnLoans>
    {
        #region Constructor
        public NewPawnLoanViewModel()
            : base()
        {
            base.DisplayName = "New Pawn Loan";
            item = new PawnLoans();
        }
        #endregion
        #region Properties

        public int Client_Id
        {
            get { return item.client_id; }
            set
            {
                if (value != item.client_id)
                {
                    item.client_id = value;
                    OnPropertyChanged(() => Client_Id);
                }
            }
        }

        public string Agreement_Number
        {
            get { return item.agreement_number; }
            set
            {
                if (value != item.agreement_number)
                {
                    item.agreement_number = value;
                    OnPropertyChanged(() => Agreement_Number);
                }
            }
        }

        public DateTime Start_Date
        {
            get { return item.start_date; }
            set
            {
                if (value != item.start_date)
                {
                    item.start_date = value;
                    OnPropertyChanged(() => Start_Date);
                }
            }
        }

        public DateTime Due_Date
        {
            get { return item.due_date; }
            set
            {
                if (value != item.due_date)
                {
                    item.due_date = value;
                    OnPropertyChanged(() => Due_Date);
                }
            }
        }

        public decimal Total_Loan_Amount
        {
            get { return item.total_loan_amount; }
            set
            {
                if (value != item.total_loan_amount)
                {
                    item.total_loan_amount = value;
                    OnPropertyChanged(() => Total_Loan_Amount);
                }
            }
        }

        public int Interest_Rate_Id
        {
            get { return item.interest_rate_id; }
            set
            {
                if (value != item.interest_rate_id)
                {
                    item.interest_rate_id = value;
                    OnPropertyChanged(() => Interest_Rate_Id);
                }
            }
        }

        public int Status_Id
        {
            get { return item.status_id; }
            set
            {
                if (value != item.status_id)
                {
                    item.status_id = value;
                    OnPropertyChanged(() => Status_Id);
                }
            }
        }

        public int? Previous_Loan_Id
        {
            get { return item.previous_loan_id; }
            set
            {
                if (value != item.previous_loan_id)
                {
                    item.previous_loan_id = value;
                    OnPropertyChanged(() => Previous_Loan_Id);
                }
            }
        }

        public bool Is_Active
        {
            get { return item.is_active; }
            set
            {
                if (value != item.is_active)
                {
                    item.is_active = value;
                    OnPropertyChanged(() => Is_Active);
                }
            }
        }

        #endregion

        #region Commands
        public override void Save()
        {
            item.history_id = createRecordHistory();
            pawnShopEntities.PawnLoans.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}
