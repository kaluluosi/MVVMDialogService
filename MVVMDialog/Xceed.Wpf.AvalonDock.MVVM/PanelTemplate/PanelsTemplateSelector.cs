using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.AvalonDock.MVVM.PanelTemplate
{
    public class PanelsTemplateSelector:DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container) {
            if(item is ViewModelBase) {
                DataTemplate template = new DataTemplate();
                template.VisualTree = PanelTemplateManager.GetUserControlFactory(item as ViewModelBase);
                return template;
            }
            return base.SelectTemplate(item, container);
        }

    }
}
