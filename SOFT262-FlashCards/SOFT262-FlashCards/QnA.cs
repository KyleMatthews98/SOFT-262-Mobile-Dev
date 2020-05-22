using System;
using System.Collections.Generic;
using System.Text;

namespace SOFT262_FlashCards
{
    public class QnA
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public QnA(string answer, string question) => (Question, Answer) = (question, answer);
    }
}
