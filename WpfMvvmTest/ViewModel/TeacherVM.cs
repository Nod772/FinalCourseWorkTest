using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMvvmTest.LoginView;
using WpfMvvmTest.Model;
using WpfMvvmTest.TeacherView;
using WpfMvvmTest.ViewModel.Comands;
using WpfMvvmTest.ViewModel.Helper;

namespace WpfMvvmTest.ViewModel
{
   public class TeacherVM:INotifyPropertyChanged
    {
        private string login;
      

        public ObservableCollection<TestDTO> tests { get; set; }
        public ObservableCollection<string> results { get; set; }

        private TestDTO selectedTest;
        private TeacherDTO currentteacher;

        public GetResultComandICommand getResult { get; set; }
        public RemoveComand removeComand { get; set; }
        public MyTestComand searchComand { get; set; }
        public CreateTestCommand createTestCommand { get; set; }
        public LoginTeacherCommand loginCommand { get; set; }
        public RegisterTeacherCommand RegisterCommand { get; set; }
        public StartPageLogCommand startPageLog { get; set; }


        private LoginTeacher loginTeacherWidnow;      
        private StartPageTeacher startPageTeacherWindow;

        private AddTest addTestWindow;


        public TeacherVM()
        {
            searchComand = new MyTestComand(this);
            tests = new ObservableCollection<TestDTO>();
            results = new ObservableCollection<string>();
            getResult = new GetResultComandICommand(this);
            removeComand = new RemoveComand(this);
            createTestCommand = new CreateTestCommand(this);
            RegisterCommand = new RegisterTeacherCommand(this);
            loginCommand = new LoginTeacherCommand(this);
            startPageLog = new StartPageLogCommand(this);

           
        }
     

        public event PropertyChangedEventHandler PropertyChanged;

        public TestDTO SelectedTest
        {
            get { return selectedTest; }
            set { 
                selectedTest = value;
                NotifyPropertyChanged();
                }
        }
        public AddTest AddTestWindow
        {
            get { return addTestWindow; }
            set
            {
                addTestWindow = value;
                NotifyPropertyChanged();
            }
        }
        public TeacherDTO Currentteacher
        {
            get { return currentteacher; }
            set
            {
                currentteacher = value;
                NotifyPropertyChanged();
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                NotifyPropertyChanged();
            }
        }
     

        public async void Logins(string pass)
        {
            //  await TeacherHelper.Logins(Login, pass);
            //    startPageTeacherWindow 
            startPageTeacherWindow = new StartPageTeacher();
            Application.Current.MainWindow.Close();

            startPageTeacherWindow.Show();


        }
        public async void Registers(string pass)
        {
           
           // if(Register)
            {
                MessageBox.Show("Login exist or field empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
               
            }
          //  else
            {
                await TeacherHelper.Registers(Login, pass);
            }
            await TeacherHelper.Logins(Login, pass);
        }
        public async void GetTests()
        {
            var Newtests = await TeacherHelper.GetTests();
            tests.Clear();
            foreach (var item in Newtests)
            {
               
                tests.Add(item);
            }

        }
        public void StartPageLog()
        {
            loginTeacherWidnow = new LoginTeacher();
            Application.Current.MainWindow.Close();

            loginTeacherWidnow.Show();
            
        }
        public async void GetResult()
        {
            var tests = await TeacherHelper.GetResults();
            results.Clear();
            foreach (var item in tests)
            {
                results.Add(item);
            }

        }
        public  void CreateTest()
        {
            addTestWindow = new AddTest();
            Application.Current.MainWindow.Close();

            addTestWindow.Show();


        }
        public void Remove()
        {
            TeacherHelper.RemoveTest(selectedTest);
        }
        public void NotifyPropertyChanged([CallerMemberName] string propertyname="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
