using RevisionApp.Models;
using RevisionApp.ViewModel;
using System;
using Xamarin.Forms;

namespace RevisionApp.Views
{
    public partial class QuestionPage : ContentPage
    {


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

        async void show_clicked(object sender, EventArgs e)
        {
            var qna = (QnA_Model)((Button)sender).BindingContext;
            await Navigation.PushAsync(new AnswerPage(qna.Question, qna.Answer));
        }

    }
}