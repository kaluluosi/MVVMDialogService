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
    public class PanelTemplateManager
    {
        private static DataTemplateSelector _defaultPanelsTemplateSelector;

        public static DataTemplateSelector DefaultPanelsTemplateSelector {
            get {
                if(_defaultPanelsTemplateSelector == null)
                    return _defaultPanelsTemplateSelector = new PanelsTemplateSelector();
                return _defaultPanelsTemplateSelector;
            }
        }

        private static Dictionary<Type, Type> _controlFacotry = new Dictionary<Type, Type>();

        public static void Register<VMType, CtrlType>()
            where VMType : ViewModelBase
            where CtrlType : UserControl {
            Type vmType = typeof(VMType);
            Type ctrlType = typeof(CtrlType);

            Register(vmType, ctrlType);
        }

        public static void Register(Type vmType, Type ctrlType) {
            _controlFacotry.Add(vmType, ctrlType);
        }

        public static FrameworkElementFactory GetUserControlFactory(ViewModelBase vm) {
            if(_controlFacotry == null || _controlFacotry.Count == 0)
                return null;
            Type ctrlType = _controlFacotry[vm.GetType()];
            FrameworkElementFactory factory = new FrameworkElementFactory(ctrlType);
            return factory;
        }
    }
}
