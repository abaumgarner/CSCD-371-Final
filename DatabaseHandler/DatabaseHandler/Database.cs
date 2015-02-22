using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseHandler
{
    public class Database
    {
        private static SQLiteCommand _sqliteCmd;
        private static SQLiteConnection _sqliteConn;

        public static void CreateDatabase()
        {
            _sqliteConn =
                new SQLiteConnection("Data source = questions.db; Version = 3; New = True; Compress = True;");
            _sqliteConn.Open();
            _sqliteCmd = _sqliteConn.CreateCommand();

            _sqliteCmd.CommandText =
                "CREATE TABLE allQuestions (question VARCHAR(300), options VARCHAR(300), answer VARCHAR(300));";
            _sqliteCmd.ExecuteNonQuery();

            LoadQuestions();
        }

        private static void LoadQuestions()
        {
            var fileNames = GetQuestions();

            LoadQuestionsInDatabase(fileNames);
        }

        private static void LoadQuestionsInDatabase(ArrayList fileNames)
        {
            for (var i = 1; i < fileNames.Count; i += 3)
            {
                var question = fileNames[i];
                var choices = fileNames[i + 1];
                var answer = fileNames[i + 2];

                _sqliteCmd.CommandText = "INSERT INTO allQuestions (question, options, answer) VALUES (?, ?, ?);";
                _sqliteCmd.Parameters.Add("@question", DbType.String).Value = question;
                _sqliteCmd.Parameters.Add("@options", DbType.String).Value = choices;
                _sqliteCmd.Parameters.Add("@answer", DbType.String).Value = answer;
                _sqliteCmd.ExecuteNonQuery();
            }

            _sqliteConn.Close();
        }

        private static ArrayList GetQuestions()
        {
            var fileNames = new ArrayList();
            var path = @"questions\questions.txt";
            var fileInfo = new FileInfo(path);

            if (File.Exists(path))
            {
                using (var fin = File.OpenText(path))
                {
                    while (!fin.EndOfStream)
                    {
                        fileNames.Add(fin.ReadLine());
                        fileNames.TrimToSize();
                    }
                }
            }
            return fileNames;
        }

        public static void OpenDatabase()
        {
            _sqliteConn = new SQLiteConnection("Data Source = questions.db; Version = 3");
            _sqliteConn.Open();
            _sqliteCmd = _sqliteConn.CreateCommand();
        }

        public SQLiteConnection GetDatabaseConnection()
        {
            return _sqliteConn;
        }

        public SQLiteCommand GetSqLiteCommand()
        {
            return _sqliteCmd;
        }

        public void CloseDatabase()
        {
            _sqliteCmd.Dispose();
            _sqliteConn.Close();
            _sqliteConn.Dispose();
        }
    }
}