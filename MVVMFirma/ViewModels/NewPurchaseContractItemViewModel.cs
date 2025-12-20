using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVVMFirma.ViewModels
{
    public class NewPurchaseContractItemViewModel : OneViewModel<PurchaseContractItems>
    {
        #region Constructor
        public NewPurchaseContractItemViewModel()
            : base()
        {
            base.DisplayName = "New Purchase Contract Item";
            item = new PurchaseContractItems();
        }
        #endregion

        #region Properties

        public int Purchase_Contract_Id
        {
            get { return item.purchase_contract_id; }
            set
            {
                if (value != item.purchase_contract_id)
                {
                    item.purchase_contract_id = value;
                    OnPropertyChanged(() => Purchase_Contract_Id);
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

        public decimal Purchase_Price
        {
            get { return item.purchase_price; }
            set
            {
                if (value != item.purchase_price)
                {
                    item.purchase_price = value;
                    OnPropertyChanged(() => Purchase_Price);
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
            pawnShopEntities.PurchaseContractItems.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}