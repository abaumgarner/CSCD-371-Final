using System.Data.SQLite;
using DatabaseHandler;

namespace QuestionDriver
{
    public class Question
    {
        private string _question;
        private string[] _choices;
        private string _answer;

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
            _question = str;
        }

        private void SetChoices(string str)
        {
            _choices = str.Split(',');
        }

        private void SetAnswer(string str)
        {
            _answer = str;
        }

        public string GetQuestion()
        {
            return _question;
        }

        public string[] GetChoices()
        {
            return _choices;
        }

        public string GetAnswer()
        {
            return _answer;
        }
    }
}
