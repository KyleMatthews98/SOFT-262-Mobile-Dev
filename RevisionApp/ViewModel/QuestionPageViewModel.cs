using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RevisionApp.Models;
using Xamarin.Forms;

namespace RevisionApp.ViewModel
{
    public class QuestionPageViewModel
    {

        public ObservableCollection<QnA_Model> QuestionList { get; set; }

        public QuestionPageViewModel()
        {


            QuestionList = new ObservableCollection<QnA_Model>();
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of Germany?", Difficulty = "Easy", Answer = "Berlin" });
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of France?", Difficulty = "Easy", Answer = "Paris" });
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of Switzerland?", Difficulty = "Hard", Answer = "Bern" });
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of India?", Difficulty = "Medium", Answer = "New Delhi" });
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of Italy?", Difficulty = "Easy", Answer = "Rome" });
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of Canada?", Difficulty = "Hard", Answer = "Ottawa" });
            QuestionList.Add(new QnA_Model { Question = "What is the capital city of Russia?", Difficulty = "Easy", Answer = "Moscow" });



        }

    }
}
