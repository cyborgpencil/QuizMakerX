using System.Windows.Controls;

namespace QuizBuilderLib
{
    /// <summary>
    /// Interaction logic for TextQuestionControl.xaml
    /// </summary>
    public partial class TextQuestionControl : UserControl
    {

        public TextQuestionControl()
        {
            InitializeComponent();
        }

        public string GetQuestionText()
        {
            return mainQuestion_txBx.Text;
        }
    }
}
