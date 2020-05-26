using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmTest.Model;

using WpfMvvmTest.ServiceReferenceTest;
using WpfMvvmTest.ServiceReferenceAnswerOption;
using WpfMvvmTest.ServiceReferenceTeacher;
using WpfMvvmTest.ServiceReferenceQuestion;
using TestDTO = WpfMvvmTest.ServiceReferenceTest.TestDTO;
using QuestionDTO = WpfMvvmTest.ServiceReferenceQuestion.QuestionDTO;
using AnswerOptionDTO = WpfMvvmTest.ServiceReferenceAnswerOption.AnswerOptionDTO;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfMvvmTest.ViewModel.Helper
{
    public class UserHepler
    {
        public static async Task<TestDTO> GetTest(string testName)
        {

            TestServiceClient proxyTest = new TestServiceClient();
            try
            {
                var test = await proxyTest.GetTestByNameAsync(testName);
                return test;
            }
            catch (Exception)
            {
                MessageBox.Show("Test Not Found");

            }
            return null;

        }
        //public static async Task<List<QuestionDTO>> GetQuestions(string testName)
        //{

        //    TestthisProg testthisProg = new TestthisProg();
        //    testthisProg.NewTest();


        //    TestDTO test = await GetTest(testName);
        //    List<QuestionDTO> questions = new List<QuestionDTO>();

        //    foreach (var item in test.QuestionsDTO)
        //    {
        //        // questions.Add(item);

        //    }



        //    return questions;
        //}
        public static async Task<ObservableCollection<AnswerOptionDTO>> GetAnswers(QuestionDTO question)
        {
            AnswerOptionServiceClient proxyAnswerOption = new AnswerOptionServiceClient();
            //TestthisProg testthisProg = new TestthisProg();
            ////testthisProg.NewTest();

            //AnswerOptionDTO aswerOpinionDTO1 = new AnswerOptionDTO();
            //AnswerOptionDTO aswerOpinionDTO2 = new AnswerOptionDTO();
            //AnswerOptionDTO aswerOpinionDTO3 = new AnswerOptionDTO();

            //aswerOpinions.Add(aswerOpinionDTO1);
            //aswerOpinions.Add(aswerOpinionDTO2);
            //aswerOpinions.Add(aswerOpinionDTO3);

            //  QuestionDTO questionDTO = testthisProg.questions.First(x=>x==question);


            //    List<AnswerOptionDTO> aswerOpinions = new List<AnswerOptionDTO>();
            //  List<AnswerOptionDTO> answerOptions=
            #region MyRegion

            ObservableCollection<AnswerOptionDTO> aswers = new ObservableCollection<AnswerOptionDTO>(await proxyAnswerOption.GetAnswerOptionsFromQuestionAsync(question.ID));
            //var t = new ObservableCollection<AnswerOptionDTO>(await proxyAnswerOption.GetAnswerOptionsFromQuestionAsync(question.ID)).ToList();

            try
            {

                for (int i = 0; i < aswers.Count; i++)
                {
                    //question.AnswerOptionsDTO. (t[i]);
                    aswers.Add(aswers[i]);
                    if (question.AnswerOptionsDTO[i].isTrueAnswer == true)
                    {

                        aswers[i].isTrueAnswer = true;
                    }
                    else
                    {
                        aswers[i].isTrueAnswer = false;

                    }


                }
            }
            catch (Exception)
            {
                aswers.Remove(aswers.Last());
            
            }
            #endregion
            //ObservableCollection<AswerOpinionDTO> aswers = new ObservableCollection<AswerOpinionDTO>();



            //foreach (var item in question.AnswerOptionsDTO)
            //{
            //    aswers.Add(item);



            //}



            return aswers;

            //foreach (var item in t)
            //{
            //    aswers.Add(item);
            //}
            //for (int i = 0; i < t.Length; i++)
            //{
            //    aswers.Add(t[i]);
            //}
            //return question.AnswerOptionsDTO;


            return aswers;

        }


    }
}
