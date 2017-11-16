using Project.Model;

namespace Project.Helpers
{
    public class OpenChildWindowAddOrEdit
    {
        public OpenChildWindowAddOrEdit(StudentModel student, bool notEdit, int index)
        {
            Student = student;
            Edit = notEdit;
            Index = index;
        }

        public StudentModel Student { get; private set; }

        public bool Edit { get; set; }

        public int Index { get; set; }
    }
}