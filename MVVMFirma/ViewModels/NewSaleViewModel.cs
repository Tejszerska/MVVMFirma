using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NewSaleViewModel : OneViewModel<Sales>
    {
        #region Constructor
        public NewSaleViewModel()
            : base()
        {
            base.DisplayName = "New Sale";
            item = new Sales();
        }
        #endregion

        #region Properties

        public decimal Sale_Price
        {
            get { return item.sale_price; }
            set
            {
                if (value != item.sale_price)
                {
                    item.sale_price = value;
                    OnPropertyChanged(() => Sale_Price);
                }
            }
        }

        public DateTime Sale_Date
        {
            get { return item.sale_date; }
            set
            {
                if (value != item.sale_date)
                {
                    item.sale_date = value;
                    OnPropertyChanged(() => Sale_Date);
                }
            }
        }

        public int Finalization_Source_Id
        {
            get { return item.finalization_source_id; }
            set
            {
                if (value != item.finalization_source_id)
                {
                    item.finalization_source_id = value;
                    OnPropertyChanged(() => Finalization_Source_Id);
                }
            }
        }

        public int? Online_Offer_Id
        {
            get { return item.online_offer_id; }
            set
            {
                if (value != item.online_offer_id)
                {
                    item.online_offer_id = value;
                    OnPropertyChanged(() => Online_Offer_Id);
                }
            }
        }

        public int Payment_Id
        {
            get { return item.payment_id; }
            set
            {
                if (value != item.payment_id)
                {
                    item.payment_id = value;
                    OnPropertyChanged(() => Payment_Id);
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
            item.is_active = true;
            item.history_id = createRecordHistory();
            pawnShopEntities.Sales.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}
