using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaSoft.MvvmLight.Dialog
{
    public interface IDialogService
    {
        void Show(ViewModelBase owner,DialogViewModelBase vm);

        void Show(DialogViewModelBase vm);
        bool? ShowDialog(DialogViewModelBase vm);
        bool? ShowDialog(ViewModelBase owner,DialogViewModelBase vm);


    }
}
