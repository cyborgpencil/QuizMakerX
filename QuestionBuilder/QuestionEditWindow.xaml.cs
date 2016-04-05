using System.Windows;
using System.Windows.Controls;

namespace QuestionBuilder
{
    /// <summary>
    /// Interaction logic for QuestionEditWindow.xaml
    /// </summary>
    public partial class QuestionEditWindow : Window
    {
        private MainWindow mainWindow;
        private QuestionVM _qVM;
        public AppController AppController { get; set; }

        public QuestionEditWindow(MainWindow mainWindow, QuestionVM qVM, AppController appController)
        {
            _qVM = qVM;
            AppController = appController;
            
            this.mainWindow = mainWindow;
            InitializeComponent();

            // Add custom Question Control
            Grid.SetRow(_qVM.GetQuestionControl(), 0);
            Grid.SetColumnSpan(_qVM.GetQuestionControl(), 2);
            grid.Children.Add(_qVM.GetQuestionControl());


            Grid.SetRow(_qVM.GetAnswerControl(), 1);
            Grid.SetColumnSpan(_qVM.GetAnswerControl(), 2);
            grid.Children.Add(_qVM.GetAnswerControl());
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            _qVM.SaveQuestion();
            ChangeToMain();
        }

        private void ChangeToMain()
        {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
        }
    }
}
