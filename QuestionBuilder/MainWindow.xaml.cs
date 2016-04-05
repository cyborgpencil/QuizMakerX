using System.Windows;

namespace QuestionBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuestionVM _questVM;
        private AppController _appController;

        public MainWindow()
        {
            _questVM = new QuestionVM();
            _appController = new AppController();
            InitializeComponent();
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_appController.CheckSlectedList(type_comboBox.SelectedIndex))
            {
                _questVM.SetQuestionControl(type_comboBox.SelectedIndex);
                this.Hide();
                QuestionEditWindow questEditWindow = new QuestionEditWindow(this, _questVM, _appController);
                questEditWindow.Show();
            }
        }
    }
}
