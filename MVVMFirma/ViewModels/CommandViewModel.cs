using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public ICommand Command { get; private set; }
        public string IconCode { get; set; }
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command, string iconCode)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
            this.IconCode = iconCode;
        }
        #endregion

    }
}
