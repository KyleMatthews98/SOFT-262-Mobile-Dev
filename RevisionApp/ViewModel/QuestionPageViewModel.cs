﻿using RevisionApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;
using System;
using RevisionApp.Views;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RevisionApp.ViewModel
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand addNewQuestionCommand => new Command(AddQuestAnswers);

        public ICommand editNewQuestionCommand => new Command(EditQuestion);

    

        public static ObservableCollection<QnA_Model> QuestionList { get; set; }


        public string Question { get; set; }
        public string Difficulty { get; set; }
        public string Answer { get; set; }

        public QnA_Model SelectedQuestion { get; set; }

       
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

        //public void WriteToFile()
        //{
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string FileName = Path.Combine(path, "myfile.txt");

        //    using (var writer = new StreamWriter(FileName, bool append , System.Text.Encoding encoding, int bufferSize))
        //    {
        //        writer.WriteLine("test");
        //    }
        //}

        public void ReadFromFile()
        {
          

        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string FileName = Path.Combine(path, "myfile.txt");

        //    using (var sr = new StreamReader(FileName))
        //    {
        //        string content = sr.ReadToEnd();
        //        System.Diagnostics.Debug.WriteLine(content);
        //    }
        }

        public void AddQuestAnswers()
        {
        
            QnA_Model newQuestionAdd = new QnA_Model { Question = Question, Difficulty = Difficulty, Answer = Answer };
            QuestionList.Add(newQuestionAdd);

           

            

           // string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "temp.txt");
           //// newQuestionAdd = newQuestionAdd;
           // XmlSerializer serializer  = new XmlSerializer(typeof(List<QnA_Model>));
           // Stream writer = new FileStream(filepath, FileMode.Create); // Initialises the writer

           // serializer.Serialize(writer, Question); // Writes to the file
           // writer.Close();
           // now you can elete under me



            int indexOfAddedQuestion = QuestionList.IndexOf(newQuestionAdd);
            QuestionList.Move(indexOfAddedQuestion, 0);

            //QnA_Model qmodel = new QnA_Model();
          //  qmodel.Question = Question;
            System.Xml.Serialization.XmlSerializer xmlwriter = new System.Xml.Serialization.XmlSerializer(typeof(QnA_Model));
            var paths = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//topicstore.txt";
            System.IO.FileStream file = System.IO.File.Create(paths);

            xmlwriter.Serialize(file, newQuestionAdd);
            file.Close();



            System.Xml.Serialization.XmlSerializer reader =
              new System.Xml.Serialization.XmlSerializer(typeof(QnA_Model));
            System.IO.StreamReader fileRead = new System.IO.StreamReader(paths);
            QnA_Model qmodels = (QnA_Model)reader.Deserialize(file);
            file.Close();



            //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");



            //  File.WriteAllText(fileName, Question + Difficulty + Answer);




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

        private bool _isRefreshing = false;

       

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand RefreshCommand
        {

            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;

                    var output = new Label { Text = "" };
                    // output.Text = File.ReadAllText(fileName);


                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string FileName = Path.Combine(path, "myfile.txt");

                    using (var sr = new StreamReader(FileName))
                    {
                        string content = sr.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine(content);
                        output.Text = content;
                    }

                    //StreamReader sr; // Creates StreamReader
                    //string Question , Difficulty , Answer;
                    //sr = File.OpenText("QuestionsAnswers.txt");
                    //while (sr.Peek() != -1) //Continue whiel end of file has not been reached
                    //{
                    //    Question + Difficulty + Answer = sr.ReadLine;
                    //    QnA_Model newQuestionEdit = new QnA_Model { Question = Question, Difficulty = Difficulty, Answer = Answer };
                    //}
                    //sr.Close(); // Close stream reader

                    IsRefreshing = false;
                });
            }
        }



    }

}
