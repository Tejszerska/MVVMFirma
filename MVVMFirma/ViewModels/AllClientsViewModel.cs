using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class AllClientsViewModel : AllViewModel<ClientsExtendedView>
    {
        #region 
        public override void Load()
        {

            List = new ObservableCollection<ClientsExtendedView>
                (
                from client in pawnShopEntities.Clients
                where client.is_active == true
                select new ClientsExtendedView
                {
                    ClientId = client.client_id,
                    FirstName = client.first_name,
                    LastName = client.last_name,
                    DocumentType = client.DocumentTypes.name,
                    DocumentNumber = client.document_number,
                    PESEL = client.pesel,
                    Address = client.address,
                    AddressSource = client.AddressSources.name,
                    Phone = client.phone,
                    Email = client.email
                }
                );
        }
        #endregion
        #region Constructor
        public AllClientsViewModel()
            : base()
        {
            base.DisplayName = "Clients";

        }

        #endregion
    }
}