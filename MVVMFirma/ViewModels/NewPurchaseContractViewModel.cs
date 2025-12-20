using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{

    public class NewPurchaseContractViewModel : OneViewModel<PurchaseContracts>
    {
        #region Constructor
        public NewPurchaseContractViewModel()
            : base()
        {
            base.DisplayName = "New Purchase Contract";
            item = new PurchaseContracts();
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

        public DateTime Purchase_Date
        {
            get { return item.purchase_date; }
            set
            {
                if (value != item.purchase_date)
                {
                    item.purchase_date = value;
                    OnPropertyChanged(() => Purchase_Date);
                }
            }
        }

        public decimal Total_Purchase_Price
        {
            get { return item.total_purchase_price; }
            set
            {
                if (value != item.total_purchase_price)
                {
                    item.total_purchase_price = value;
                    OnPropertyChanged(() => Total_Purchase_Price);
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


        #endregion

        #region Commands
        public override void Save()
        {
            item.is_active = true;
            item.history_id = createRecordHistory();
            pawnShopEntities.PurchaseContracts.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}