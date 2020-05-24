using Xamarin.Forms;

namespace RevisionApp.Views
{
    public partial class AnswerPage : ContentPage
    {
        public AnswerPage(string Question, string Answer)
        {
            InitializeComponent();

            QuestionShow.Text = Question;
            AnswerShow.Text = Answer;
           

        }
    }
}