using RevisionApp.Models;
using RevisionApp.ViewModel;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace RevisionApp.Views
{
    public partial class QuestionPage : ContentPage
    {
        public ICommand RefreshCommand => new Command(RefreshCommandExec);
      
        public QuestionPage()
        {

            BindingContext = new QuestionPageViewModel();
            InitializeComponent();
           
        }



        void OnDelete(object sender, EventArgs e)
        {
            var questionList = (MenuItem)sender;
            QuestionPageViewModel.QuestionList.Remove((QnA_Model)questionList.CommandParameter);
            DisplayAlert("Deleted Flashcard", "The selected Flashcard has been deleted!", "OK");
        }

        async void Answer_clicked(object sender, EventArgs e)
        {
            var qna = (QnA_Model)((Button)sender).BindingContext;
            await Navigation.PushAsync(new AnswerPage(qna.Question, qna.Answer));
        }

        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");

        void RefreshCommandExec()
        {
            var output = new Label { Text = "" };
            output.Text = File.ReadAllText(fileName);
            questList.IsRefreshing = false;
            
            //StreamReader sr; // Creates StreamReader
            //string Question , Difficulty , Answer;
            //sr = File.OpenText("QuestionsAnswers.txt");
            //while (sr.Peek() != -1) //Continue whiel end of file has not been reached
            //{
            //    Question + Difficulty + Answer = sr.ReadLine;
            //    QnA_Model newQuestionEdit = new QnA_Model { Question = Question, Difficulty = Difficulty, Answer = Answer };
            //}
            //sr.Close(); // Close stream reader



        }

    }
}