using QuizBuilderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuestionBuilder
{
    public class QuestionVM
    {
        public Question _question { get; set; }
        private QuestionService _qService;
        private UserControl _questionAnswerControl;
        private UserControl _questionControl;
        private QuestionEditWindow _questionWindow;

        public QuestionVM(QuestionEditWindow questionWindow)
        {
            _question = new Question();
            _question.CorrectAnswerPlaces = new List<int>();
            _qService = new QuestionService();
        }

        public void SetQuestionControl(int type)
        {
            //User Control type returned based on typr parameter
            _questionControl =  _qService.SetMainQuestionControl(type);
            _questionControl.Name = "mainQuestionControl";
            _questionAnswerControl = _qService.SetQuestionAnswer(type);
        }

        public UserControl GetAnswerControl()
        {
            return _questionAnswerControl;
        }

        public UserControl GetQuestionControl()
        {
            return _questionControl;
        }

        public bool CheckBlankQuestion(string questionText)
        {
            if (questionText != null && questionText != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please Enter a Question");
                return false;
            }
        }

        public void SetCorrectAnswerPlaces()
        {
            if (_question.QuizType == QuestionType.TRUE_FASLSE)
            {
                RadioButton trueCheck = (RadioButton)_questionAnswerControl.FindName("true");

                if (trueCheck.IsChecked == true)
                {
                    _question.TruFalseAnswer = true;
                }
                else
                {
                    _question.TruFalseAnswer = false;
                }
            }
            else
            {
                List<CheckBox> chBox = new List<CheckBox>();
                _question.CorrectAnswerPlaces = new List<int>(new List<int> {0,0,0,0});

                for (int i = 0; i < 4; i++)
                {
                    chBox.Add((CheckBox)_questionAnswerControl.FindName(string.Format("correctAnswer{0}", i+1)));
                }

                for (int i = 0; i < _question.CorrectAnswerPlaces.Count; i++)
                {
                    if (chBox[i].IsChecked.Value)
                    {
                        _question.CorrectAnswerPlaces[i] = 1;
                    }
                    else
                        _question.CorrectAnswerPlaces[i] = 0;
                }
            }
        }

        public void SetMainQuestion()
        {
            TextBox text = (TextBox)_questionControl.FindName("mainQuestion_txBx");
            _question.MainQuestion = text.Text;
        }

        private void ChangeToMain()
        {
            questionWindow.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }


        public void SaveQuestion()
        {
            _question = _qService._question;
            SetMainQuestion();

            if (CheckBlankQuestion(_question.MainQuestion))
            {
                SetCorrectAnswerPlaces();
                _question = _qService._question;

                _qService.SaveQuestion(_question, string.Format("Question-{0}{1}{2}{3}.xml",DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString()));
            }
        }
    }
}
