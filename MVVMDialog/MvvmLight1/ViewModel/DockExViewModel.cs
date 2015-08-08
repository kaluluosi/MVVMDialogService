using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DockExViewModel : ViewModelBase
    {
        private static int count = 0;
        private static DockExViewModel _instance = new DockExViewModel();
        public static DockExViewModel Instance {
            get {
                if(_instance == null)
                    _instance = new DockExViewModel();
                return _instance;
            }
        }

        private ViewModelBase _activeContent;

        public ViewModelBase ActiveContent {
            get { return _activeContent; }
            set { 
                _activeContent = value; 
                RaisePropertyChanged("ActiveContent"); 
                OnActiveContentChanged(); 
            }
        }

        private TestUserControlViewModel _testUserControlViewModel;
        public TestUserControlViewModel TestUserCtrlVM{
            get{
                if(_testUserControlViewModel==null)
                    _testUserControlViewModel=new TestUserControlViewModel();
                return _testUserControlViewModel;
            }
        }

        private List<DocumentViewModel> _documents = new List<DocumentViewModel>(){
            new DocumentViewModel(){Text="haha"},
            new DocumentViewModel(){Text="mama"}
        };

        public List<DocumentViewModel> Documents {
            get { return _documents; }
            set { _documents = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ViewModelBase> _views;
        public ObservableCollection<ViewModelBase> Views {
            get {
                if(_views == null) {
                    _views = new ObservableCollection<ViewModelBase>();
                    _views.Add(TestUserCtrlVM);
                }
                return _views;
            }
        }

        /// <summary>
        /// Initializes a new instance of the DockExViewModel class.
        /// </summary>
        public DockExViewModel() {
            count++;
        }

        public event EventHandler ActiveContentChanged;
        private void OnActiveContentChanged() {
            if(ActiveContentChanged != null)
                ActiveContentChanged(this, new EventArgs());
        }
    }
}