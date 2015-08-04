/*
  In App.xaml:
 * 在App.xaml里面设置：
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MVVMDialog.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
 * 在View里设置：
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MVVMDialog.Serivce;

namespace MVVMDialog.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// 这个类提供应用程序中包含所有的ViewModel静态引用和绑定入口。
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator() {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IStudentDataService, ContactBook>();
            SimpleIoc.Default.Register<ContactBook>();
        }

        public MainViewModel Main {
            get {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>

        public static void Cleanup() {

        }
    }
}