/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Dialog;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;
using MvvmLight1.Service;
using MvvmLight1.View;
using MvvmLight1.View.PaneTemplate;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {


        static ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if(ViewModelBase.IsInDesignModeStatic) {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<ContactBook>(()=>{
                ContactBook cb = new ContactBook();
                cb.Students.Add(new Student() { Name = "Tom" });
                cb.Students.Add(new Student() { Name = "Tom2" });
                cb.Students.Add(new Student() { Name = "Tom3" });
                cb.Students.Add(new Student() { Name = "Tom4" });
                cb.Students.Add(new Student() { Name = "Tom5" });
                cb.Students.Add(new Student() { Name = "Tom6" });
                return cb;
            });

            SimpleIoc.Default.Register<IDialogService, DefaultDialogService>();

            SimpleIoc.Default.Register<EditViewModel>(true);

            SimpleIoc.Default.Register<DockExViewModel>(()=> DockExViewModel.Instance);
            SimpleIoc.Default.Register<TemplateRigster>(true);
            SimpleIoc.Default.Register<DialogRigster>(true);

//             PanelTemplateManager.Register<TestUserControlViewModel, TestUserControl>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public EditViewModel Edit {
            get {
                return ServiceLocator.Current.GetInstance<EditViewModel>();
            }
        }

        public DockExViewModel Dock {
            get {
                return ServiceLocator.Current.GetInstance<DockExViewModel>();
            }
        }

//         public DockViewModel DockView {
//             get {
//                 return ServiceLocator.Current.GetInstance<DockViewModel>();
//             }
//         }
// 
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup() {
        }
    }
}