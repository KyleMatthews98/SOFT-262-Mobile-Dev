using System;
using System.Collections.Generic;
using RevisionApp.Models;
using RevisionApp.ViewModel;
using Xamarin.Forms;

namespace RevisionApp.Views
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            BindingContext = new QuestionPageViewModel();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as QnA_Model;
            await Navigation.PushAsync(new AnswerPage(mydetails.Question, mydetails.Answer));
        }

    }
}