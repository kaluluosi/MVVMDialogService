using MVVMDialog.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDialog.Serivce
{
    public interface IStudentDataService
    {
        ObservableCollection<Student> GetSutdents();
        void Save();
        void Load();
    }
}
