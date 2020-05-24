using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Windows.Input;
using RevisionApp.Models;
using Xamarin.Forms;

namespace RevisionApp.ViewModel
{
    public class QuestionPageViewModel
    {
        public ICommand addNewQuestionCommand => new Command(AddQuestAnswers);

        public ICommand RemoveCardCommand => new Command(Removecard);
        public static ObservableCollection<QnA_Model> QuestionList { get; set; }

       
        public string Question { get; set; }
        public string Difficulty { get; set; }
        public string Answer { get; set; }

        public string SelectedCard { get; set; }

        public QuestionPageViewModel()
        {


            QuestionList = new ObservableCollection<QnA_Model>
            {
                new QnA_Model { Question = "What is the capital city of Germany?", Difficulty = "Easy", Answer = "Berlin" },
                new QnA_Model { Question = "What is the capital city of France?", Difficulty = "Easy", Answer = "Paris" },
                new QnA_Model { Question = "What is the capital city of Switzerland?", Difficulty = "Hard", Answer = "Bern" },
                new QnA_Model { Question = "What is the capital city of India?", Difficulty = "Medium", Answer = "New Delhi" },
                new QnA_Model { Question = "What is the capital city of Italy?", Difficulty = "Easy", Answer = "Rome" },
                new QnA_Model { Question = "What is the capital city of Canada?", Difficulty = "Hard", Answer = "Ottawa" },
                new QnA_Model { Question = "What is the capital city of Russia?", Difficulty = "Easy", Answer = "Moscow" }
            };




        }

        public void AddQuestAnswers()
        {
            QuestionList.Add(new QnA_Model { Question = Question , Difficulty = Difficulty , Answer = Answer });
        }

        public void Removecard()
        {
           
        }

    }
}
