using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVVMFirma.ViewModels
{
    public class NewPaymentViewModel : OneViewModel<Payments>
    {
        #region Constructor
        public NewPaymentViewModel()
            : base()
        {
            base.DisplayName = "New Payment";
            item = new Payments();
        }
        #endregion

        #region Properties

        public int Reference_Id
        {
            get { return item.reference_id; }
            set
            {
                if (value != item.reference_id)
                {
                    item.reference_id = value;
                    OnPropertyChanged(() => Reference_Id);
                }
            }
        }

        public DateTime Payment_Date
        {
            get { return item.payment_date; }
            set
            {
                if (value != item.payment_date)
                {
                    item.payment_date = value;
                    OnPropertyChanged(() => Payment_Date);
                }
            }
        }

        public decimal Amount
        {
            get { return item.amount; }
            set
            {
                if (value != item.amount)
                {
                    item.amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }

        public int Payment_Method_Id
        {
            get { return item.payment_method_id; }
            set
            {
                if (value != item.payment_method_id)
                {
                    item.payment_method_id = value;
                    OnPropertyChanged(() => Payment_Method_Id);
                }
            }
        }

        public string Description
        {
            get { return item.description; }
            set
            {
                if (value != item.description)
                {
                    item.description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }



        #endregion

        #region Commands
        public override void Save()
        {
            item.is_active = true;
            item.history_id = createRecordHistory();
            pawnShopEntities.Payments.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}
