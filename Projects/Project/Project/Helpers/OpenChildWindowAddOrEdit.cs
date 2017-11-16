using Project.Model;

namespace Project.Helpers
{
    public class OpenChildWindowAddOrEdit
    {
        public OpenChildWindowAddOrEdit(StudentModel student)
        {
            Student = student;
        }

        public StudentModel Student { get; private set; }
    }
}