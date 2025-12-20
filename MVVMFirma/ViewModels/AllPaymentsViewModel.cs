using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;


namespace MVVMFirma.ViewModels
{
    public class AllPaymentsViewModel : AllViewModel<PaymentsExtendedView>
    {
        #region 
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
        #endregion
        #region Constructor
        public AllPaymentsViewModel()
            : base()
        {
            base.DisplayName = "Payments";

        }
        #endregion
    }
}