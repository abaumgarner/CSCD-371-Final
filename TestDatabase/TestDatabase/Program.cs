using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintQuestions();
        }

        private static void PrintQuestions()
        {
            ArrayList questions = LoadQuestions();

            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i]);
            }
        }

        private static ArrayList LoadQuestions()
        {
            ArrayList questions = GetQuestionFileNames();

            return questions;
        }

        private static ArrayList GetQuestionFileNames()
        {
            ArrayList fileNames = new ArrayList();
            string path = @"questions\questions.txt";
            FileInfo fileInfo = new FileInfo(path);

            if (File.Exists(path))
            {
                using (StreamReader fin = File.OpenText(path))
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
    }
}
