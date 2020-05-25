using RevisionApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;
using System;
using System.Collections.Generic;

namespace RevisionApp.ViewModel
{
    public class QuestionPageViewModel : List<QnA_Model>
    {
        public ICommand addNewQuestionCommand => new Command(AddQuestAnswers);

        public ICommand editNewQuestionCommand => new Command(EditQuestion);

        public static ObservableCollection<QnA_Model> QuestionList { get; set; }

        public string GroupName { get; set; }


        public QuestionPageViewModel(string groupname, List<QnA_Model> source) : base(source)
        {
            GroupName = groupname;
        }
   


        public string Question { get; set; }
        public string Difficulty { get; set; }
        public string Answer { get; set; }

        public QnA_Model SelectedQuestion { get; set; }

        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");

        

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
                new QnA_Model { Question = "What is the capital city of Russia?", Difficulty = "Medium", Answer = "Moscow" }
            };




        }

        public void AddQuestAnswers()
        {
        
            QnA_Model newQuestionAdd = new QnA_Model { Question = Question, Difficulty = Difficulty, Answer = Answer };
            QuestionList.Add(newQuestionAdd);
            int indexOfAddedQuestion = QuestionList.IndexOf(newQuestionAdd);
            QuestionList.Move(indexOfAddedQuestion, 0);
            File.WriteAllText(fileName, Question + Difficulty + Answer);



        }

        public async void EditQuestion()
        {
            int indexOfNewQuestion = QuestionList.IndexOf(SelectedQuestion);
            QuestionList.Remove(SelectedQuestion);
            QnA_Model newQuestionEdit = new QnA_Model { Question = Question, Difficulty = Difficulty, Answer = Answer };
            QuestionList.Add(newQuestionEdit);
            int indexOfDeletedQuestion = QuestionList.IndexOf(newQuestionEdit);

            if (indexOfNewQuestion >= 0)
            {
                QuestionList.Move(indexOfDeletedQuestion, indexOfNewQuestion);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("No Flashcard Selected", "You must select a flashcard to edit!", "Gotcha!");
            }
        }

        public void Refresh()
        {
            var output = new Label { Text = "" };
            output.Text = File.ReadAllText(fileName);


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
