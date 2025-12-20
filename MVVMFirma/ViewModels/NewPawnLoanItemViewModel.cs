using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewPawnLoanItemViewModel : OneViewModel<PawnLoanItems>
    {
        #region Constructor
        public NewPawnLoanItemViewModel()
            : base()
        {
            base.DisplayName = "New Pawn Loan Item";
            item = new PawnLoanItems();
        }
        #endregion
        #region Properties

        public int Pawn_Loan_Id
        {
            get { return item.pawn_loan_id; }
            set
            {
                if (value != item.pawn_loan_id)
                {
                    item.pawn_loan_id = value;
                    OnPropertyChanged(() => Pawn_Loan_Id);
                }
            }
        }

        public int Item_Id
        {
            get { return item.item_id; }
            set
            {
                if (value != item.item_id)
                {
                    item.item_id = value;
                    OnPropertyChanged(() => Item_Id);
                }
            }
        }

        public decimal Loan_Amount_For_Item
        {
            get { return item.loan_amount_for_item; }
            set
            {
                if (value != item.loan_amount_for_item)
                {
                    item.loan_amount_for_item = value;
                    OnPropertyChanged(() => Loan_Amount_For_Item);
                }
            }
        }

        public string Notes
        {
            get { return item.notes; }
            set
            {
                if (value != item.notes)
                {
                    item.notes = value;
                    OnPropertyChanged(() => Notes);
                }
            }
        }

        #endregion

        #region Commands
        public override void Save()
        {
            item.history_id = createRecordHistory();
            pawnShopEntities.PawnLoanItems.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}