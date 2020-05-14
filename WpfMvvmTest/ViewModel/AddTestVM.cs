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

namespace WpfMvvmTest.ViewModel
{
    public class AddTestVM : INotifyPropertyChanged
    {
        private string nametext;
        private string questiontext;
        private string answertext;
        private bool istrue = false;



        public event PropertyChangedEventHandler PropertyChanged;


        private TestDTO NewTest;

        public ObservableCollection<QuestionDTO> questions { get; set; }
        public ObservableCollection<AswerOpinionDTO> Answers { get; set; }

        private QuestionDTO selectedQuestion;



        private AswerOpinionDTO selectedAnswer;

        public AddQuestionCommand AddQuestionCommand { get; set; }
        public DeleteAnswerComand deleteanswerComand { get; set; }
        public AddAsnwerComand addanswerComand { get; set; }

        public AddQuestionWindowCommand addQuestionWindowComand { get; set; }




        public AddTestVM()
        {

            AddQuestionCommand = new AddQuestionCommand(this);
            deleteanswerComand = new DeleteAnswerComand(this);
            addanswerComand = new AddAsnwerComand(this);

            addQuestionWindowComand = new AddQuestionWindowCommand(this);

            questions = new ObservableCollection<QuestionDTO>();
            Answers = new ObservableCollection<AswerOpinionDTO>();
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




        public AswerOpinionDTO SelectedAnswer
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

        public void AddQuestioncommand()
        {

            questions.Add(SelectedQuestion);

        }
        public void AddQuestionWindow()
        {
            // Application.Current

        }
        public void AddAnswer()//////////////
        {
            Answers.Add(SelectedAnswer);
            //Answers.Add(aswer);


        }

        internal void AddTest()
        {
            NewTest.NameTest = Nametext;
            //AddTest()
        }
        public void DeleteAnswer()
        {
            Answers.Remove(SelectedAnswer);

        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
