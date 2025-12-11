using MVVMFirma.Helper;
using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NewBranchViewModel : OneViewModel<Branches>
    {
        #region Constructor
        public NewBranchViewModel()
            :base( )
        {
            base.DisplayName = "New Branch";
            item = new Branches();
        }
        #endregion
        #region Properties
        // tylko dla pol towarow ktore bedziemy dodawac - dodajemu properties
        public string Name
        {
            get
            {   return item.name;
            }
            set
            {
                if (value != item.name)
                {
                    item.name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }
        public string Address
        {
            get
            {
                return item.address;
            }
            set
            {
                if (value != item.address)
                {
                    item.address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }
        public string Phone
        {
            get
            {
                return item.phone;
            }
            set
            {
                if (value != item.phone)
                {
                    item.phone = value;
                    OnPropertyChanged(() => Phone);
                }
            }
        }
        #endregion
        #region Commends
        // komendy przyciskow zapisz i zamknij
        public override void Save()
        {
            item.is_active = true;
            item.history_id = createRecordHistory();
            pawnShopEntities.Branches.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }
}
