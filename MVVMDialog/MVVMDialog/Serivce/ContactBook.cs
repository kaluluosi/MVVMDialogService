using MVVMDialog.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDialog.Serivce
{
    public class ContactBook:IStudentDataService
    {
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students {
            get { return _students; }
            set { _students = value; }
        }

        public ContactBook() {
            _students = new ObservableCollection<Student>();
            _students.Add(new Student() { Name = "Tony" });
            _students.Add(new Student() { Name = "Sim" });
            _students.Add(new Student() { Name = "Tim" });
        }

        public ObservableCollection<Student> GetSutdents() {
            return _students;
        }

        public void Save() {
            
        }

        public void Load() {
            
        }
    }
}
