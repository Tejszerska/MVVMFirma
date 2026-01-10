using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
    public class AllPaymentsViewModel : AllViewModel<PaymentsExtendedView>
    {
        #region  Abstract implemented methods
        public override void Sort()
        {

        }

        public override void Search()
        {

        }

        public override List<string> getComboboxSortList()
        {
            return null;
        }

        public override List<string> getComboboxSearchList()
        {
            return null;
        }
        public override void Load()
        {

            List = new ObservableCollection<PaymentsExtendedView>
                (
                from payment in pawnShopEntities.Payments
                where payment.is_active == true
                select new PaymentsExtendedView
                {
                    PaymentID = payment.payment_id,
                    PaymentDate = payment.payment_date,
                    Amount = payment.amount,
                    PaymentMethod = payment.PaymentMethods.name,
                    Description = payment.description
                }
                );
        }
        #endregion Abstract implemented methods
      
        #region Constructor
        public AllPaymentsViewModel()
            : base()
        {
            base.DisplayName = "Payments";

        }
        #endregion
    }
}