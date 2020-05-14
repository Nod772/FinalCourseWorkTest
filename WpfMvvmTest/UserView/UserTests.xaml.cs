using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfMvvmTest.ViewModel;

namespace WpfMvvmTest.UserView
{
    /// <summary>
    /// Interaction logic for UserTests.xaml
    /// </summary>
    public partial class UserTests : Window
    {
        public UserVM user { get; set; }


        public UserTests(UserVM vm)
        {
            InitializeComponent();
            user = vm;
            user.GetQuestions();
            this.DataContext = user;

        }











    }
}
