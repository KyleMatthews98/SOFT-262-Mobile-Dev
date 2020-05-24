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
            var mydetails = e.Item as QnA_Model;
            await Navigation.PushAsync(new AnswerPage(mydetails.Question, mydetails.Answer));
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var questionList = (MenuItem)sender;
            QuestionPageViewModel.QuestionList.Remove((QnA_Model)questionList.CommandParameter);
        }
    }
}