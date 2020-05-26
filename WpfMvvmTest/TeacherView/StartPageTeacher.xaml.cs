using System.Windows;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ViewModel;

namespace WpfMvvmTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartPageTeacher : Window
    {
        public TeacherVM teacherVM { get; set; }

        public StartPageTeacher(TeacherVM teacher)
        {
            InitializeComponent();
            teacherVM = teacher;
            teacherVM.GetTests(teacherVM);

        }

        
    }
}

