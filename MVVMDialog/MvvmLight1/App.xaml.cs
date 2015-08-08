using System.Windows;
using GalaSoft.MvvmLight.Threading;
using MvvmLight1.View.PaneTemplate;

namespace MvvmLight1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App() {
            DispatcherHelper.Initialize();

//             new TemplateRigster();
//             new DialogRigster();
        }
    }
}
