using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1.Service
{
    public class ContactBook:ObservableObject
    {
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();

        internal ObservableCollection<Student> Students {
            get { return _students; }
            set { _students = value; RaisePropertyChanged(); }
        }

    }
}
