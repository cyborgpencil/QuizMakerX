using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace QuestionBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuestionVM _questVM;
        public AppController AppController { get; set; }

        public MainWindow()
        {
            AppController = new AppController();
            _questVM = new QuestionVM(AppController);
            InitializeComponent();
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            if (AppController.CheckSlectedList(type_comboBox.SelectedIndex))
            {
                _questVM.SetQuestionControl(type_comboBox.SelectedIndex);
                this.Hide();
                QuestionEditWindow questEditWindow = new QuestionEditWindow(this, _questVM, AppController);
                questEditWindow.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppController.GetFileNames(this);
        }
    }
}
