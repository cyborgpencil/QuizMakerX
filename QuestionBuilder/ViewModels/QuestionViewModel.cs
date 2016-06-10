using QuestionUtilLib.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QuestionBuilder.ViewModels
{
    public class QuestionViewModel : ObservableCollection<Question>
    { 

        public QuestionViewModel()
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                Add(new TrueFalseQuestion()
                {
                    Name = "TorF1",
                    MainQuestion = "This is the main question for this",
                    QuestionType = QuestionType.TRUE_FASLSE
                });
            }
        }
    }
}
