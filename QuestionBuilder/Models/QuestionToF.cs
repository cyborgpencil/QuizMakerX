using System.Collections.Generic;
using System.ComponentModel;

namespace QuestionBuilder.Models
{
    public class QuestionToF : QuestionBase
    {
        public bool IsTrue { get; set; }
        public bool IsFalse { get; set; }

        public QuestionToF()
        {

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                QuestionAnswers = new List<string>(2);
                QuestionAnswers.Add("True");
                QuestionAnswers.Add("False");

                IsTrue = false;
                IsFalse = true;
            }
        }
    }
}
