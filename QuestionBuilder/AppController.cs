//This class will be used to manage different functions of the QuestionBuilder App
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace QuestionBuilder
{
    public class AppController
    {
        public string QuestionDirectory = "QuestionFolder";

        public bool CheckSlectedList(int index)
        {
            // if index is 0 then nothing was selected
            if (index == 0)
            {
                MessageBox.Show("Please Select a Question Type");

                return false;
            }
            else
                return true;
        }

        public void CreateQuestionFolder()
        {
            Directory.CreateDirectory(QuestionDirectory);
        }
    }
}
