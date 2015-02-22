using System.ComponentModel;
using System.Windows.Forms;

namespace MazeTesterWinForm
{
    partial class MazeTester
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBox_MazeOut = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_MoveNorth = new System.Windows.Forms.Button();
            this.btn_MoveWest = new System.Windows.Forms.Button();
            this.btn_MoveEast = new System.Windows.Forms.Button();
            this.btn_MoveSouth = new System.Windows.Forms.Button();
            this.btn_Database = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox_MazeOut
            // 
            this.txtBox_MazeOut.Location = new System.Drawing.Point(236, 70);
            this.txtBox_MazeOut.Multiline = true;
            this.txtBox_MazeOut.Name = "txtBox_MazeOut";
            this.txtBox_MazeOut.ReadOnly = true;
            this.txtBox_MazeOut.Size = new System.Drawing.Size(366, 261);
            this.txtBox_MazeOut.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(377, 347);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_MoveNorth
            // 
            this.btn_MoveNorth.Location = new System.Drawing.Point(377, 399);
            this.btn_MoveNorth.Name = "btn_MoveNorth";
            this.btn_MoveNorth.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveNorth.TabIndex = 2;
            this.btn_MoveNorth.Text = "North";
            this.btn_MoveNorth.UseVisualStyleBackColor = true;
            this.btn_MoveNorth.Click += new System.EventHandler(this.btn_MoveNorth_Click);
            // 
            // btn_MoveWest
            // 
            this.btn_MoveWest.Location = new System.Drawing.Point(303, 428);
            this.btn_MoveWest.Name = "btn_MoveWest";
            this.btn_MoveWest.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveWest.TabIndex = 3;
            this.btn_MoveWest.Text = "West";
            this.btn_MoveWest.UseVisualStyleBackColor = true;
            this.btn_MoveWest.Click += new System.EventHandler(this.btn_MoveWest_Click);
            // 
            // btn_MoveEast
            // 
            this.btn_MoveEast.Location = new System.Drawing.Point(452, 428);
            this.btn_MoveEast.Name = "btn_MoveEast";
            this.btn_MoveEast.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveEast.TabIndex = 4;
            this.btn_MoveEast.Text = "East";
            this.btn_MoveEast.UseVisualStyleBackColor = true;
            this.btn_MoveEast.Click += new System.EventHandler(this.btn_MoveEast_Click);
            // 
            // btn_MoveSouth
            // 
            this.btn_MoveSouth.Location = new System.Drawing.Point(377, 457);
            this.btn_MoveSouth.Name = "btn_MoveSouth";
            this.btn_MoveSouth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_MoveSouth.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveSouth.TabIndex = 5;
            this.btn_MoveSouth.Text = "South";
            this.btn_MoveSouth.UseVisualStyleBackColor = true;
            this.btn_MoveSouth.Click += new System.EventHandler(this.btn_MoveSouth_Click);
            // 
            // btn_Database
            // 
            this.btn_Database.Location = new System.Drawing.Point(559, 399);
            this.btn_Database.Name = "btn_Database";
            this.btn_Database.Size = new System.Drawing.Size(75, 23);
            this.btn_Database.TabIndex = 6;
            this.btn_Database.Text = "Database";
            this.btn_Database.UseVisualStyleBackColor = true;
            this.btn_Database.Click += new System.EventHandler(this.btn_Database_Click);
            // 
            // MazeTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 605);
            this.Controls.Add(this.btn_Database);
            this.Controls.Add(this.btn_MoveSouth);
            this.Controls.Add(this.btn_MoveEast);
            this.Controls.Add(this.btn_MoveWest);
            this.Controls.Add(this.btn_MoveNorth);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txtBox_MazeOut);
            this.Name = "MazeTester";
            this.Text = "Maze Tester";
            this.Load += new System.EventHandler(this.Maze_Tester_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Maze_Tester_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBox_MazeOut;
        private Button btn_Start;
        private Button btn_MoveNorth;
        private Button btn_MoveWest;
        private Button btn_MoveEast;
        private Button btn_MoveSouth;
        private Button btn_Database;
    }
}

