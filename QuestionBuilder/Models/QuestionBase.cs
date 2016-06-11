using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuestionBuilder.Models
{
    public abstract class QuestionBase : BindableBase
    {
        private string _questionName;
        public string QuestionName
        {
            get { return _questionName; }
            set { SetProperty(ref _questionName, value); }
        }

        private QuestionType _questionType;
        public QuestionType QuestionType
        {
            get { return _questionType; }
            set { SetProperty(ref _questionType, value); }
        }
        
        private string _mainQuestion;
        public string MainQuestion
        {
            get { return _mainQuestion; }
            set { SetProperty(ref _mainQuestion, value); }
        }

        private List<string> _questionAnswers;
        public List<string> QuestionAnswers
        {
            get { return _questionAnswers; }
            set { SetProperty(ref _questionAnswers, value); }
        }

        public override string ToString()
        {
            return String.Format("Name: {0} Question Type: {1} Main Question: {2}", this.QuestionName, this.QuestionType, this.MainQuestion);
        }
    }
}
