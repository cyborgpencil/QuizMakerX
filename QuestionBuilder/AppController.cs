//This class will be used to manage different functions of the QuestionBuilder App
using QuizBuilderLib;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace QuestionBuilder
{
    public class AppController
    {
        public string QuestionDirectory { get; set; }
        public QuizFileUtil quizFileUtil;
        public ObservableCollection<string> ListQuestionsOnFileList { get; set; }

        public AppController()
        {
            quizFileUtil = new QuizFileUtil("QuestionFolder");
            ListQuestionsOnFileList = new ObservableCollection<string>();
        }

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

        public async void GetFileNames(Window win)
        {
            var ListQuestionsByName = await quizFileUtil.GetFileList();

            foreach (var item in ListQuestionsByName)
            {
                ListQuestionsOnFileList.Add(item);
            }
            win.DataContext = this;
            Debug.Write(ListQuestionsOnFileList);
        }
    }
}
