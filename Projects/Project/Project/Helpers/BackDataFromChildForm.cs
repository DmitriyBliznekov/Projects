using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.View;
using Project.ViewModel;

namespace Project.Helpers
{
    public class BackDataFromChildForm
    {
        public BackDataFromChildForm(StudentViewModel student)
        {
            Student = student.Student;
            Index = student.Index;
        }

        public StudentModel Student { get; private set; }

        public int Index { get; set; }
    }
}
