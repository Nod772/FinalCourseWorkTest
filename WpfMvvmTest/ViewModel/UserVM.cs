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

using WpfMvvmTest.ServiceReferenceTest;
using WpfMvvmTest.ServiceReferenceAnswerOption;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ServiceReferenceQuestion;
using TestDTO = WpfMvvmTest.ServiceReferenceTest.TestDTO;
using QuestionDTO = WpfMvvmTest.ServiceReferenceQuestion.QuestionDTO;
using AnswerOptionDTO = WpfMvvmTest.ServiceReferenceAnswerOption.AnswerOptionDTO;

namespace WpfMvvmTest.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {
        QuestionServiceClient proxyQuestion = new QuestionServiceClient();

        TestDTO MyTest = new TestDTO();
        List<QuestionDTO> MyQuestion = new List<QuestionDTO>();
        List<AnswerOptionDTO> MyAswerOpinion = new List<AnswerOptionDTO>();


        private string name;
        private string testName;

        private TestDTO selectedTest;
        public ObservableCollection <ServiceReferenceQuestion.QuestionDTO> questions { get; set; }
        private ServiceReferenceQuestion.QuestionDTO selectedQuestion;
        public ObservableCollection<ServiceReferenceAnswerOption.AnswerOptionDTO> answers { get; set; }


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
            answers = new ObservableCollection<ServiceReferenceAnswerOption.AnswerOptionDTO>();


            getQuestionscommacd = new GetQuestionsCommand(this);
            startComand = new StartTestCommand(this);
            endComand = new EndCommand(this);
            findComand = new FindCommand(this);
            logStud = new LogStudCommand(this);
            startPage = new StartPageLogCommand(this);
           
        }

        public async void GetQuestions()
        {
            var Newquestions = SelectedTest.QuestionsDTO;

            var t = new ObservableCollection<QuestionDTO>(await proxyQuestion.QuestionFromIDTestAsync(SelectedTest.ID)).ToList();
          
            if (SelectedQuestion == null)
                SelectedQuestion = t.First();

            
            for (int i = 0; i < t.Count; i++)
            {
                MyQuestion.Add(t[i]);
                questions.Add(t[i]);
            }

          
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
        public TestDTO SelectedTest
        {
            get { return selectedTest; }
            set
            {
                selectedTest = value;
             //   MyTest.NameTest = selectedTest.Name;
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
        public async void StartTesting()
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
       

        public async void GetAnswers()
        {
            var answ = await UserHepler.GetAnswers(SelectedQuestion);
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
