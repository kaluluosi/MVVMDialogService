using GalaSoft.MvvmLight;
using MVVMDialog.Model;
using MVVMDialog.Serivce;

namespace MVVMDialog.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IStudentDataService _dataService;
        private ContactBook _contactBook;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IStudentDataService dataService) {
            _dataService = dataService;
//             _contactBook = cb;

            string a = "";
        }
    }
}