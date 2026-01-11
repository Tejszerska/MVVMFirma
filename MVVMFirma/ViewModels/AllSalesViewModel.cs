using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class AllSalesViewModel : AllViewModel<SalesForAllView>
    {
        #region Abstract implemented methods
        public override void Sort()
        {
            if (SortField == "Price")
            {
                List = new ObservableCollection<SalesForAllView>(List.OrderBy(x => x.TotalAmount));
            }
            if (SortField == "Sale date")
            {
                List = new ObservableCollection<SalesForAllView>(List.OrderBy(x => x.SaleDate));
            }
            if (SortField == "Payment date")
            {
                List = new ObservableCollection<SalesForAllView>(List.OrderBy(x => x.PaymentDate));
            }
        }

        public override void Search()
        {
            if (SearchField == "Id")
            {
                if (int.TryParse(SearchTextBox, out int search))
                {
                    List = new ObservableCollection<SalesForAllView>(List.Where(x => x.SaleID == search));
                }
            }
            if (SearchField == "Price")
            {
                if (decimal.TryParse(SearchTextBox, out decimal search))
                {
                    List = new ObservableCollection<SalesForAllView>(List.Where(x => x.TotalAmount == search));
                }
            }
            if (SearchField == "Status")
            {
                List = new ObservableCollection<SalesForAllView>(List.Where(x => x.Status != null && x.Status.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Payment method")
            {
                List = new ObservableCollection<SalesForAllView>(List.Where(x => x.PaymentMethod != null && x.PaymentMethod.ToLower().StartsWith(SearchTextBox)));
            }
            if (SearchField == "Sale date")
            {
                if (DateTime.TryParse(SearchTextBox, out DateTime searchDate))
                {
                    List = new ObservableCollection<SalesForAllView>(List.Where(x => x.SaleDate.Date == searchDate.Date));
                }
            }
            if (SearchField == "Payment date")
            {
                if (DateTime.TryParse(SearchTextBox, out DateTime searchDate))
                {
                  List = new ObservableCollection<SalesForAllView>(List.Where(x => x.PaymentDate.Date == searchDate.Date));
                }
            }

        }

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Price", "Sale date", "Payment date" };
        }

        public override List<string> getComboboxSearchList()
        {
            return new List<string> { "Id", "Price", "Status", "Payment method", "Sale date", "Payment date" };
        }
        public override void Load()
        {

            List = new ObservableCollection<SalesForAllView>
                (
                from sale in pawnShopEntities.Sales
                where sale.is_active == true
                select new SalesForAllView
                {
                    SaleID = sale.sale_id,
                    SaleDate = sale.sale_date,
                    TotalAmount = sale.sale_price,
                    Status = sale.SalesStatuses.name,
                    PaymentMethod = sale.Payments.PaymentMethods.name,
                    PaymentDate = sale.Payments.payment_date,
                    Items = 
                        (
                        from saleItem in pawnShopEntities.SalesItems
                        where saleItem.sale_id == sale.sale_id
                        select new SaleItemForAllView
                        {
                            ItemID = saleItem.item_id,
                            ItemName = saleItem.Items.name,
                            SellingPrice = saleItem.Items.sale_price,
                            Condition = saleItem.Items.ItemConditions.name
                        }
                        ).ToList()
                }
                );
        }
        #endregion
        #region Constructor
        public AllSalesViewModel()
            : base()
        {
            base.DisplayName = "Sales";

        }

        #endregion
    }
}