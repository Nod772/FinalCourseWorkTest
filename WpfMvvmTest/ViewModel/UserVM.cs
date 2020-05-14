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
using WpfMvvmTest.UserView;
using WpfMvvmTest.ViewModel.Helper;
using WpfMvvmTest.ViewModel.UserComands;

namespace WpfMvvmTest.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        private string name;
       private string testName;

        private TestDTO selectedTest;

        public ObservableCollection <QuestionDTO> questions { get; set; }
        private QuestionDTO selectedQuestion;
        public ObservableCollection<AswerOpinionDTO> answers { get; set; }
        public AswerOpinionDTO selectedAnswer;

        public GetQuestionsCommand getQuestionscommacd { get; set; }
        public StartTestCommand startComand { get; set; }

    

        public EndCommand endComand { get; set; }
        public FindCommand findComand { get; set; }
        public LogStudCommand logStud { get; set; }
        public StartPageLogCommand startPage { get; set; }

        private LoginStudent loginStudent ;
        private UserTests userTests;
        private UserChoose userChoose;
        public UserVM()
        {
            questions = new ObservableCollection<QuestionDTO>();
            answers = new ObservableCollection<AswerOpinionDTO>();


            getQuestionscommacd = new GetQuestionsCommand(this);
            startComand = new StartTestCommand(this);
            endComand = new EndCommand(this);
            findComand = new FindCommand(this);
            logStud = new LogStudCommand(this);
            startPage = new StartPageLogCommand(this);
           

        }

        

        public QuestionDTO SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
               
                selectedQuestion = value;
                GetAnswers();
                NotifyPropertyChanged();
            }
        }


        public AswerOpinionDTO SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                selectedAnswer = value;
                NotifyPropertyChanged();
            }
        }

        public TestDTO SelectedTest
        {
            get { return selectedTest; }
            set
            {
                selectedTest = value;
                NotifyPropertyChanged();
            }
        }
      
        public string TestName
        {
            get { return testName; }
            set
            { 
                testName = value;
                NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        public async void Login()
        {
          
            userChoose = new UserChoose();
         //   Application.Current.MainWindow.Close();

            userChoose.Show();


        }
        public void StartPageLogStud()
        {
            loginStudent = new LoginStudent();
            Application.Current.MainWindow.Close();
            loginStudent.Show();
        }
       
        public  void StartTesting()
        {

       

            userTests = new UserTests(this);
            Application.Current.MainWindow.Close();
         
            userTests.Show();
          

        }
        public async void FindTest()
        {
            try
            {

            SelectedTest = await UserHepler.GetTest(TestName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
              



        }
        internal void EndTest()
        {
            //
        }
        public  void GetQuestions()
        {
            
            var Newquestions = SelectedTest.Questions;
            if(SelectedQuestion==null)
                SelectedQuestion = Newquestions[0];
            for (int i=0;i<Newquestions.Count;i++)
            {
                questions.Add(Newquestions[i]);
            }


        }

        public async void GetAnswers()
        {
            var answ = await UserHepler.GetAnswers( SelectedQuestion);
            answers.Clear();
            foreach (var item in answ)
            {
                answers.Add(item);
            }


        }
        public event PropertyChangedEventHandler PropertyChanged;


        public void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
