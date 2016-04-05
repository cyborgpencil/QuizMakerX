using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuizBuilderLib
{
    public class Question
    {
        public QuestionType QuizType { get; set; }
        public int AnswerAmount { get; set; }
        public List<int> CorrectAnswerPlaces { get; set; }
        public string MainQuestion { get; set; }
        public bool TruFalseAnswer { get; set; }
    }
}
