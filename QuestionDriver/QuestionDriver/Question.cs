using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DatabaseHandler;

namespace QuestionDriver
{
    public class Question
    {
        private string question;
        private string[] choices;
        private string answer;

        public Question()
        {
            SQLiteDataReader result = Database.GetRandomQuestion();

            result.Read();

            SetQuestion(result.GetString(0));
            SetChoices(result.GetString(1));
            SetAnswer(result.GetString(2));

            result.Dispose();
        }

        private void SetQuestion(string str)
        {
            question = str;
        }

        private void SetChoices(string str)
        {
            choices = str.Split(',');
        }

        private void SetAnswer(string str)
        {
            answer = str;
        }

        public string GetQuestion()
        {
            return question;
        }

        public string[] GetChoices()
        {
            return choices;
        }

        public string GetAnswer()
        {
            return answer;
        }
    }
}
