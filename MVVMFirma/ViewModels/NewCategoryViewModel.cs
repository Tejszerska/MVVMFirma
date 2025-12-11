using MVVMFirma.Models;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NewCategoryViewModel : OneViewModel<Categories>
    {
        public NewCategoryViewModel()
                        : base()
        {
            base.DisplayName = "New Category";
            item = new Categories();
        }
        #region Properties
        // tylko dla pol towarow ktore bedziemy dodawac - dodajemu properties
        public string Name
        {
            get
            {
                return item.name;
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
        public int? Parent_ID
        {
            get
            {
                return item.parent_id;
            }
            set
            {
                if (value != item.parent_id)
                {
                    item.parent_id = value;
                    OnPropertyChanged(() => Parent_ID );
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
            pawnShopEntities.Categories.Add(item);
            pawnShopEntities.SaveChanges();
        }
        #endregion
    }

}


