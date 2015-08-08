using GalaSoft.MvvmLight;
using Xceed.Wpf.AvalonDock;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TestUserControlViewModel : ViewModelBase
    {

        /// <summary>
        /// Initializes a new instance of the TestUserControlViewModel class.
        /// </summary>
        public TestUserControlViewModel() {
            DockExViewModel.Instance.ActiveContentChanged += Instance_ActiveContentChanged;
            string d = "";
        }

        void Instance_ActiveContentChanged(object sender, System.EventArgs e) {
            if(DockExViewModel.Instance.ActiveContent is DocumentViewModel)
                DocContent = (DockExViewModel.Instance.ActiveContent as DocumentViewModel).Text;
        }

        private string _docContent = "";
        public string DocContent {
            get {
                return _docContent;
            }
            set {
                _docContent = value;
                RaisePropertyChanged("DocContent");
            }
        }
    }
}