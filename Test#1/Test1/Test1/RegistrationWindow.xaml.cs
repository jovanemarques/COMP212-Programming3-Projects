using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Test1
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private Login login;
        private SMSEntities ctx;
        EnrolledCourseList enrolledCourses = new EnrolledCourseList();
        Student student = null;
        public RegistrationWindow(SMSEntities ctx, Login login)
        {
            InitializeComponent();
            this.login = login;
            this.ctx = ctx;

            courseComboBox.ItemsSource = ctx.Courses.Select(c => c.CourseCode + "-" + c.CourseTitle).ToList();

            student = ctx.Students.Where(s => s.StudentID == this.login.LoginName)?.First();

            if (student != null)
            {
                foreach (var course in student.Courses)
                {
                    enrolledCourses.Add(new EnrolledCourse(course.CourseCode, course.CourseTitle));
                }
                dbCourses.ItemsSource = enrolledCourses;
            }
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] split = courseComboBox.SelectedValue.ToString().Split('-');
            string code = split[0];
            string name = split[1];
            int countCourse = enrolledCourses.Where(en => en.CourseCode == code).Count();

            if (countCourse == 0)
            {
                enrolledCourses.Add(new EnrolledCourse(code, name));
                student.Courses.Add(ctx.Courses.Where(c => c.CourseCode == code).First());
                ctx.SaveChanges();
            }
            else
            {
                MessageBox.Show("Student " + login.LoginName + " has already enrolled " + split[0]);
            }
        }
    }
}
