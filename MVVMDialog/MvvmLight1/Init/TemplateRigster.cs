using MvvmLight1.View;
using MvvmLight1.View.PaneTemplate;
using MvvmLight1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1
{
    public class TemplateRigster
    {

        static TemplateRigster() {

            PanelTemplateManager.Register<TestUserControlViewModel, TestUserControl>();
            PanelTemplateManager.Register<DocumentViewModel, DocumentView>();
        }
    }
}
