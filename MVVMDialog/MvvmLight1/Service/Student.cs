using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmLight1.Service
{
    public class Student:ObservableObject
    {
        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }
    }
}
