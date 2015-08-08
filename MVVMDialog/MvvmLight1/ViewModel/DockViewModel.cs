using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DockViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the DockViewModel class.
        /// </summary>
        public DockViewModel() {
            _views.Add(new TestUserControlViewModel());
        }

        private ObservableCollection<ViewModelBase> _views = new ObservableCollection<ViewModelBase>();

        public ObservableCollection<ViewModelBase> Views {
            get { return _views; }
            set { _views = value; RaisePropertyChanged(); }
        }
    }
}