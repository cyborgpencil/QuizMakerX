using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Diagnostics;
using QuestionBuilder.Models;
using QuestionBuilder.Views;
using System.Collections.ObjectModel;

namespace QuestionBuilder.ViewModels
{
    class QuestionEditorViewModel : BindableBase
    {
        public QuestionToFViewModel QuestionToFViewModel { get; set; }
        public List<string> SelectList { get; set; }

        private ObservableCollection<string> _comboBoxItems;
        public ObservableCollection<string> ComboBoxItems
        {
            get { return _comboBoxItems; }
            set { SetProperty(ref _comboBoxItems, value); }
        }

        /// <summary>
        /// Will set control based on selected string from ComboBox
        /// </summary>
        private string _comboBoxItemSelected;
        public string ComboBoxItemSelected
        {
            get { return _comboBoxItemSelected; }
            set { SetProperty(ref _comboBoxItemSelected, value); SetQuestionControl(value); }
        }

        private UserControl _questionControl;
        public UserControl QuestionControl
        {
            get { return _questionControl; }
            set { SetProperty(ref _questionControl, value); }
        }

        private void SetQuestionControl(string value)
        {
            if (value == "TrueFalse")
            {
                QuestionControl = new QuestionToFView();
            }
            else
            {
                QuestionControl = new QuestionMultiChoice4();
            }
        }

        // Commands
        public ICommand OnLoadCommand { get; set; }
        public ICommand OnQuestionSave { get; set; }

        private bool WindowCanExecute()
        {
            return true;
        }

        private void WindowExecute()
        {
            //SelectList.Add("There are no Questions in this Directory");
        }

        private bool SaveCanExecute()
        {
            return true;
        }

        private void SaveExecute()
        {
            Debug.WriteLine();
        }

        public QuestionEditorViewModel()
        {
            // ViewModels
            QuestionToFViewModel = new QuestionToFViewModel();
            QuestionToFViewModel.QuestionToF.IsFalse = true;
            QuestionToFViewModel.QuestionToF.IsTrue = false;

            //GUI
            SelectList = new List<string>();
            ComboBoxItems = new ObservableCollection<string>();
            ComboBoxItems.Add("TrueFalse");
            ComboBoxItems.Add("MultiChoice-4");

            /// <summary>
            /// Using Prism 6 Commanding
            /// </summary>
            OnLoadCommand = new DelegateCommand(WindowExecute, WindowCanExecute);
            OnQuestionSave = new DelegateCommand(SaveExecute, SaveCanExecute);
        }

       
    }
}
