using GalaSoft.MvvmLight;
using MvvmLight1.Model;
using MvvmLight1.Service;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Dialog;
using System.Windows.Input;
using System.Windows;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly ContactBook _contactBook;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students {
            get { return _students; }
            set { _students = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle {
            get {
                return _welcomeTitle;
            }

            set {
                if(_welcomeTitle == value) {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        public RelayCommand<Student> EditCmd { get;private set; }
       

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService,ContactBook cb) {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) => {
                    if(error != null) {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
            _contactBook = cb;
            _students = cb.Students;

            EditCmd = new RelayCommand<Student>(edit, canEdit);

        }


        private bool canEdit(Student arg) {
            return true;
        }

        private void edit(Student obj) {
            //             EditViewModel editVM = new EditViewModel(obj);
            //             _dialogService.ShowDialog(editVM);
            EditViewModel editVM = ViewManager.Show<EditViewModel>();
            editVM.Student = obj ;
            editVM.Name = obj.Name;
        }


   
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}