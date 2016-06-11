using System;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Controls;
using System.Collections.Generic;

namespace QuizBuilderLib
{
    public class QuestionService
    {
        public Question _question;

        public QuestionService()
        {
            _question = new Question();
        }

        public UserControl SetQuestionAnswer(int type)
        {
            switch(type)
            {
                case 2: // Multiple Choice
                    {
                        _question.AnswerAmount = 4;
                        _question.CorrectAnswerPlaces = new List<int>(_question.AnswerAmount);
                        _question.QuizType = new QuestionType();
                        _question.QuizType = QuestionType.MULTI_CHOICE;
                        return new FourAnswerControl();
                    }
                default:
                    {
                        _question.AnswerAmount = 2;
                        _question.CorrectAnswerPlaces = new List<int>(_question.AnswerAmount);
                        _question.QuizType = new QuestionType();
                        _question.QuizType = QuestionType.TRUE_FASLSE;
                        return new TrueFalseControl2();
                    }
            }
        }

        public UserControl SetMainQuestionControl(int type)
        {
            switch (type)
            {
                default: // Currrent all Questions will be texted base
                    return new TextQuestionControl();
            }
        }

        public void SaveQuestion(Question question, string filename)
        {
            using (StreamWriter stream = new StreamWriter(filename))
            {
                try {
                    XmlSerializer XML = new XmlSerializer(typeof(Question));
                    XML.Serialize(stream, question);
                }catch(Exception ex)
                {
                    string mesaage = ex.InnerException.Message;

                }
            }
        }

        
    }
}
