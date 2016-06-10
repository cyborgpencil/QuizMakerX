using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionUtilLib.Models
{
    public abstract class Question : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private QuestionType _questionType;
        public QuestionType QuestionType
        {
            get { return _questionType; }
            set
            {
                _questionType = value;
                OnPropertyChanged("QuestionType");
            }
        }

        private string _mainQuestion;
        public string MainQuestion
        {
            get { return _mainQuestion; }
            set
            {
                _mainQuestion = value;
                OnPropertyChanged("MainQuestion");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
