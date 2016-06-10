using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionUtilLib.Models
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion()
        {
            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                Name = "TorF";
                QuestionType = QuestionType.TRUE_FASLSE;
                MainQuestion = "This is a maine questrion";
            }
        }
        public TrueFalseQuestion(string name, QuestionType questionType)
        {
            Name = name;
            QuestionType = questionType;
        }
    }
}
