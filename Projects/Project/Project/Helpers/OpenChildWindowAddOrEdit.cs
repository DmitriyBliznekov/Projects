using Project.Model;
using Project.ViewModel;

namespace Project.Helpers
{
    public class OpenChildWindowAddOrEdit
    {
        public OpenChildWindowAddOrEdit(MainViewModel student)
        {
            if (student.SelectedStudent == null)
            {
                CurrentIndex = 0;
                Student = new StudentModel();
            }

            else
            {
                Student = student.SelectedStudent;
                CurrentIndex = student.SelectedIndex;
            }

        }

        public StudentModel Student { get; private set; }

        public int CurrentIndex { get; set; }
    }
}