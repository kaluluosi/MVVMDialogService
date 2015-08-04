using GalaSoft.MvvmLight;
using MvvmLight1.Service;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Dialog;
using GalaSoft.MvvmLight.Ioc;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EditViewModel : DialogViewModelBase
    {
        private Student _student;

        private string _name="";

        public string Name {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }

        private RelayCommand _SubmitCmd;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SubmitCmd {
            get {
                return _SubmitCmd
                    ?? (_SubmitCmd = new RelayCommand(
                    () => {
                        _student.Name = _name;
                        DialogResult = true;
                    }));
            }
        }

        public RelayCommand<string> ApplyCmd {
            get;
            private set;
        }

        [PreferredConstructor]
        public EditViewModel() {
            ApplyCmd = new RelayCommand<string>(apply, canApply);
        }

        private bool canApply(string arg) {
            if(_student == null)
                return false;
            if(_student.Name == arg)
                return false;
            else
                return true;
        }

        private void apply(string arg) {
            _student.Name = _name;
        }

        /// <summary>
        /// Initializes a new instance of the EditViewModel class.
        /// </summary>
        public EditViewModel(Student student) {
            _student = student;
            _name = _student.Name;
        }
    }
}