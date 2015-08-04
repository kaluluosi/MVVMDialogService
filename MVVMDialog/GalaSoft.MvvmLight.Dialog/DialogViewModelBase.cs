using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaSoft.MvvmLight.Dialog
{
    public abstract class DialogViewModelBase:ViewModelBase
    {
        private bool? dialogResult;

        public bool? DialogResult {
            get { return dialogResult; }
            set { dialogResult = value; RaisePropertyChanged("DialogResult"); }
        }
    }
}
