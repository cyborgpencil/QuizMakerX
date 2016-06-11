using Prism.Commands;
using Prism.Mvvm;
using QuestionBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuestionBuilder.ViewModels
{
    public class QuestionToFViewModel
    {
        public QuestionToF QuestionToF { get; set; }

        public ICommand OnLoadCommand { get; set; }

        public QuestionToFViewModel()
        {
            QuestionToF = new QuestionToF();

            OnLoadCommand = new DelegateCommand(Execute, CanExecute);
        }

        private bool CanExecute()
        {
            return true;
        }

        private void Execute()
        {
            QuestionToF.IsTrue = false;
            QuestionToF.IsFalse = true;
        }
    }
}
