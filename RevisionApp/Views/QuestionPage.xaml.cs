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

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as QnA_Model;
            await Navigation.PushAsync(new AnswerPage(selected.Question, selected.Answer));
        }


        void OnDelete(object sender, EventArgs e)
        {
            var questionList = (MenuItem)sender;
            QuestionPageViewModel.QuestionList.Remove((QnA_Model)questionList.CommandParameter);
            DisplayAlert("Deleted Flashcard","The selected Flashcard has been deleted!", "OK");
        }

      
    }
}