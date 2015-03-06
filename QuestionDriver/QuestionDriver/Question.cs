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
        public Question()
        {
            Database.CreateDatabase();
        }
    }
}
