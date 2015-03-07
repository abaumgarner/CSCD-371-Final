﻿using System;
using System.IO;
using System.Windows.Forms;
using DatabaseHandler;
using MazeBuilder;
using System.Data.SQLite;
using QuestionDriver;

namespace MazeTesterWinForm
{
    public partial class MazeTester : Form
    {
        private Maze _maze;

        public MazeTester()
        {
            InitializeComponent();
        }

        private void Maze_Tester_KeyDown(object sender, KeyEventArgs e)
        {
            DisplayMaze();
            while (!_maze.PlayerInExit())
            {
                if (e.KeyCode == Keys.W)
                    _maze.MoveNorth();
                else if (e.KeyCode == Keys.S)
                    _maze.MoveSouth();
                else if (e.KeyCode == Keys.A)
                    _maze.MoveWest();
                else if (e.KeyCode == Keys.D)
                    _maze.MoveEast();

                if (!_maze.MazeTraversal())
                {
                    MessageBox.Show("MAZE CAN NO LONGER BE TRAVERSED");
                }

                DisplayMaze();
            }
            MessageBox.Show("You made it to the exit.");
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            var builder = new MazeBuilder.MazeBuilder(5);
            _maze = builder.Build();

            DisplayMaze();
        }

        private void btn_MoveNorth_Click(object sender, EventArgs e)
        {
            _maze.MoveNorth();
            DisplayMaze();
        }

        private void DisplayMaze()
        {
            txtBox_MazeOut.Text = _maze.ToString();
        }

        private void btn_MoveEast_Click(object sender, EventArgs e)
        {
            _maze.MoveEast();
            DisplayMaze();
        }

        private void btn_MoveSouth_Click(object sender, EventArgs e)
        {
            _maze.MoveSouth();
            DisplayMaze();
        }

        private void btn_MoveWest_Click(object sender, EventArgs e)
        {
            _maze.MoveWest();
            DisplayMaze();
        }

        private void btn_Database_Click(object sender, EventArgs e)
        {
            if (!File.Exists("questions.db"))
                Database.CreateDatabase();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var file = txtBox_File.Text;

            Database.AddQuestionsFile(file);
        }

        private void btn_Question_Click(object sender, EventArgs e)
        {
            SQLiteDataReader result = Database.GetRandomQuestion();
            int i = 0;
            result.Read();
            string[] titles = {"Question", "Choices", "Answer"};

            for(i =0; i < 3; i++)
            {
                if (i == 1)
                {
                    string str = result.GetString(i);
                    string[] ara = str.Split(',');

                    string temp = "";

                    foreach (var item in ara)
                    {
                        temp += item + Environment.NewLine;
                    }

                    MessageBox.Show(temp, titles[i]);
                }
                else
                    MessageBox.Show(result.GetString(i), titles[i]);
            }
            result.Dispose();
        }

        private void btn_QuestionObj_Click(object sender, EventArgs e)
        {
            Question question = new Question();

            MessageBox.Show(question.GetQuestion(),"Question");

            for(int i = 0; i < question.GetChoices().Length; i++)
                MessageBox.Show(question.GetChoices()[i], "Choices");

            MessageBox.Show(question.GetAnswer());
        }
    }
}