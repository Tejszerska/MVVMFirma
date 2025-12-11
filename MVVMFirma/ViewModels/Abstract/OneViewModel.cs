using MVVMFirma.Helper;
using MVVMFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    public abstract class OneViewModel<T> : WorkspaceViewModel
    {
        #region Database
        protected PawnShopEntities pawnShopEntities;
        protected T item;
        #endregion
        #region Constructor
        public OneViewModel()
        {
            pawnShopEntities = new PawnShopEntities();
        }
        #endregion
        #region Commends
        // komendy przyciskow zapisz i zamknij
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(saveAndClose);

                }
                return _SaveAndCloseCommand;
            }
        }
        public abstract void Save();
        protected int createRecordHistory()
        {
            RecordHistory recordHistory = new RecordHistory();
            recordHistory.created_by = 0;
            recordHistory.created_at = DateTime.Now;
            recordHistory.created_in = 1;
            pawnShopEntities.RecordHistory.Add(recordHistory);
            pawnShopEntities.SaveChanges();
            return recordHistory.history_id;

        }
        private void saveAndClose()
        {
            Save();
            OnRequestClose();
        }
        #endregion
    }
}
