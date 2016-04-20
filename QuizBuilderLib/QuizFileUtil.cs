using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace QuizBuilderLib
{
    public class QuizFileUtil
    {
        public string QuestionAppDirectory { get; set; }
        public List<string> FileListByName { get; set; }

        public QuizFileUtil(string dir)
        {
            QuestionAppDirectory = dir;
            FileListByName = new List<string>();
        }

        public Task<List<string>> GetFileList()
        {

           return Task.Factory.StartNew(() => {
               {
                   if (Directory.Exists(QuestionAppDirectory))
                   {
                       foreach (var item in Directory.GetFiles(QuestionAppDirectory))
                       {
                           FileListByName.Add(item);
                       }
                      
                   }

                   return FileListByName;
               }
            });
        }

    }
}
