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
            _appController = new AppController();
            _questVM = new QuestionVM(_appController);

            _appController.CreateQuestionFolder();
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
