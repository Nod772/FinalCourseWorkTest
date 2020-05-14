using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTest.Model;
using WpfMvvmTest.TeacherView;
using WpfMvvmTest.ViewModel.Comands;
using WpfMvvmTest.ViewModel.Helper;

using WpfMvvmTest.ServiceReferenceTest;
using WpfMvvmTest.ServiceReferenceAnswerOption;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ServiceReferenceQuestion;
using TestDTO = WpfMvvmTest.ServiceReferenceTest.TestDTO;
using QuestionDTO = WpfMvvmTest.ServiceReferenceQuestion.QuestionDTO;
using AnswerOptionDTO = WpfMvvmTest.ServiceReferenceAnswerOption.AnswerOptionDTO;


namespace WpfMvvmTest.ViewModel
{
    public class AddTestVM : INotifyPropertyChanged
    {
        private string nametext;
        private string questiontext;
        private string answertext;
        private bool istrue=false;



        public event PropertyChangedEventHandler PropertyChanged;


        private TestDTO NewTest;

        public ObservableCollection<QuestionDTO> questions { get; set; }
        public ObservableCollection<AnswerOptionDTO> Answers { get; set; }

        private QuestionDTO selectedQuestion;

     

        private AnswerOptionDTO selectedAnswer;

        public AddQuestionCommand AddQuestionCommand { get; set; }
        public DeleteAnswerComand deleteanswerComand { get; set; }
        public AddAsnwerComand addanswerComand { get; set; }
       
        public AddQuestionWindowCommand addQuestionWindowComand { get; set; }


        private AddQuestion addQuestionWindow;

        public AddTestVM()
        {

            AddQuestionCommand = new AddQuestionCommand(this);
            deleteanswerComand = new DeleteAnswerComand(this);
            addanswerComand = new AddAsnwerComand(this);
         
            addQuestionWindowComand = new AddQuestionWindowCommand(this);

            questions = new ObservableCollection<QuestionDTO>();
            Answers = new ObservableCollection<AnswerOptionDTO>();
            NewTest = new TestDTO();
        }
        public string QuestionText
        {
            get { return questiontext; }
            set
            {
                questiontext = value;
                NotifyPropertyChanged();
            }
        }
        public string Nametext
        {
            get { return nametext; }
            set
            {
                nametext = value;
                NotifyPropertyChanged();
            }
        }
        public bool Istrue
        {
            get { return istrue; }
            set
            {
                istrue = value;
                NotifyPropertyChanged();
            }
        }
        public string Answertext
        {
            get { return answertext; }
            set
            {
                answertext = value;
                NotifyPropertyChanged();
            }
        }
      

      

        public AnswerOptionDTO SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                selectedAnswer = value;
                NotifyPropertyChanged();
            }
        }

        public QuestionDTO SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                NotifyPropertyChanged();
            }
        }

        public  void AddQuestioncommand()
        {

           questions.Add(SelectedQuestion);

        }
        public void AddQuestionWindow()
        {
            addQuestionWindow = new AddQuestion();
            addQuestionWindow.Show();
        }
        public  void AddAnswer()//////////////
        {
            Answers.Add(SelectedAnswer);
//Answers.Add(aswer);
            

        }

        internal void AddTest()
        {
            NewTest.Name = Nametext;
            //AddTest()
        }
        public  void DeleteAnswer()
        {
            Answers.Remove(SelectedAnswer);

        }
     
        public void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
