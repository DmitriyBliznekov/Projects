using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Project.Model;

namespace Project.ViewModel
{
    public class StudentViewModel : ViewModelBase
    {
        private StudentModel student;
        public StudentModel Student
        {
            get => student;
            set
            {
                student = value;
                RaisePropertyChanged(nameof(Student));
                Console.WriteLine(Student.FirstName);
            }
        }
    }
}
