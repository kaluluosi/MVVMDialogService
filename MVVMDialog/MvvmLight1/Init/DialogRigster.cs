using GalaSoft.MvvmLight.Dialog;
using MvvmLight1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1
{
    public class DialogRigster
    {
        static DialogRigster() {

            ViewManager.Register<EditViewModel, EditWindow>();

        }
    }
}
