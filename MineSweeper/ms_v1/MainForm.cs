﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ms_v1
{
    /* 
     * TO DO: 
     * - clear method if no mine around (see original minesweeper)
     * - add menue to select dificulty (beginner, intermediate, expert, custom)
     * - dynamic form size (or dynamic button/ panel size)
     * - highscores
     * - timer
     * - include images (mine, exploding mine, flag, questionmark, smilie face (restart button))
     * - by clicking a number, and (a) mine(s) is/are marked -> expose all touching fields (optional)
     */

    public partial class MainForm : Form
    {
        // playing field bounderies
        int playingFieldWidth;
        int playingFieldHeight;

        // start location
        int panelLocationX;
        int panelLocationY;

        // button size
        int buttonSize;

        int minesAmount;
        int markedMines;

        bool gameOver;

        // spezific character for the mine
        char mineCharacter = '#';
        char questionMark = '?';

        // timer
        Timer t1;
        int sec;

        // some controls
        Panel panel1;
        TextBox tbTimer;
        TextBox tbMinesCounter;
        Button btnStart;
        Button[,] playingField;
        Button[,] playingFieldCoverUp;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            initGame();
        }

        /// <summary>
        /// initialize game gomponents
        /// </summary>
        private void initGame()
        {
            this.Controls.Clear();

            // initialize variables
            gameOver = false;
            markedMines = 0;
            sec = 0;
            playingFieldWidth = 9;
            playingFieldHeight = 9;
            panelLocationX = 20;
            panelLocationY = 100;
            buttonSize = 40;
            minesAmount = 10;
            markedMines = 0;

            this.Width = panelLocationX + ((playingFieldWidth * buttonSize) + 15) + panelLocationX;
            this.Height = panelLocationY + ((playingFieldHeight * buttonSize)) + 60;

            // Timer
            t1 = new Timer();
            t1.Interval = 1000;
            t1.Tick += new EventHandler(t1_Tick);

            // evtl in andere methode auslagern
            btnStart = new Button();
            btnStart.Size = new Size(60, 60);
            btnStart.Location = new Point(this.Width / 2 - btnStart.Size.Width / 2 - 7, 20);
            btnStart.Text = "Restart";
            btnStart.Click += new EventHandler(btnStart_Click);
            this.Controls.Add(btnStart);

            tbTimer = new TextBox();
            tbTimer.Enabled = false;
            tbTimer.Multiline = true;
            tbTimer.TextAlign = HorizontalAlignment.Center;
            tbTimer.Size = new Size(buttonSize, buttonSize);
            tbTimer.Location = new Point(this.Width - buttonSize - panelLocationX - 15, 20);
            this.Controls.Add(tbTimer);

            tbMinesCounter = new TextBox();
            tbMinesCounter.Enabled = false;
            tbMinesCounter.Multiline = true;
            tbMinesCounter.TextAlign = HorizontalAlignment.Center;
            tbMinesCounter.Size = new Size(buttonSize, buttonSize);
            tbMinesCounter.Location = new Point(panelLocationX, 20);
            this.Controls.Add(tbMinesCounter);

            panel1 = new Panel();
            panel1.Location = new Point(panelLocationX, panelLocationY);
            panel1.Size = new Size(playingFieldWidth * buttonSize, playingFieldHeight * buttonSize);
            this.Controls.Add(panel1);

            AddPlayingFieldCoverUp();
            AddPlayingField();
            DistributeMines();
            DistributeHints();

           
            tbTimer.Text = sec.ToString();
            tbMinesCounter.Text = (minesAmount - markedMines).ToString();
        }

        /// <summary>
        /// distributes the hints for each adjacant mine
        /// </summary>
        private void DistributeHints()
        {
            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    int minesCount = 0;

                    if (!playingField[column, row].Text.Equals(mineCharacter.ToString()))
                    {
                        if (column - 1 >= 0 && playingField[column - 1, row].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (column + 1 < playingFieldWidth && playingField[column + 1, row].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row - 1 >= 0 && playingField[column, row - 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row - 1 >= 0 && column - 1 >= 0 && playingField[column - 1, row - 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row - 1 >= 0 && column + 1 < playingFieldWidth && playingField[column + 1, row - 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row + 1 < playingFieldHeight && playingField[column, row + 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row + 1 < playingFieldHeight && column - 1 >= 0 && playingField[column - 1, row + 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row + 1 < playingFieldHeight && column + 1 < playingFieldWidth && playingField[column + 1, row + 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (minesCount != 0)
                            playingField[column, row].Text = minesCount.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// distributes the mines
        /// </summary>
        private void DistributeMines()
        {
            Random rnd = new Random();
            int minesCount = 0;

            while (true)
            {
                if (minesCount == minesAmount)
                    break;

                int row = rnd.Next(0, playingFieldHeight);
                int column = rnd.Next(0, playingFieldWidth);

                if (!playingField[column, row].Text.Equals(mineCharacter.ToString()))
                {
                    playingField[column, row].Text = mineCharacter.ToString();
                    minesCount++;
                }
            }
        }

        /// <summary>
        /// creates an dynamic playing field which consists of buttons
        /// </summary>
        private void AddPlayingField()
        {
            int wnh = buttonSize;
            int x = 0;
            int y = 0;

            playingField = new Button[playingFieldWidth, playingFieldHeight];

            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    Button btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(wnh, wnh);
                    btn.Enabled = false;
                    btn.TabStop = false;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);

                    panel1.Controls.Add(btn);
                    playingField[column, row] = btn;

                    x += buttonSize;
                }
                x = 0;
                y += buttonSize;
            }
        }

        /// <summary>
        /// creates a playing field cover up which also consists of buttons
        /// </summary>
        private void AddPlayingFieldCoverUp()
        {
            int wnh = buttonSize;
            int x = 0;
            int y = 0;

            playingFieldCoverUp = new Button[playingFieldWidth, playingFieldHeight];

            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    Button btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(wnh, wnh);
                    btn.TabStop = false;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.MouseDown += new MouseEventHandler(btn_Click);

                    panel1.Controls.Add(btn);
                    playingFieldCoverUp[column, row] = btn;

                    x += buttonSize;
                }
                x = 0;
                y += buttonSize;
            }
        }

        /// <summary>
        /// button click event, which is triggerd by playing field cover up buttons
        /// right click -> sets the button text to '#' (the character spezified to a mine)
        /// left click -> sets the visibility of the button to false and checks if a mine was 'exposed'
        /// 
        /// also checks if the game is over
        /// </summary>
        /// <param name="sender">playing field cover up button</param>
        /// <param name="e">mouse event</param>
        private void btn_Click(Object sender, MouseEventArgs e)
        {
            t1.Start();

            if (!gameOver)
            {
                Button obj = (Button)sender;

                if (e.Button == MouseButtons.Right)
                {
                    if (obj.Text.Equals(String.Empty))
                    {
                        obj.Text = mineCharacter.ToString();
                        obj.ForeColor = Color.Red;
                        markedMines++;
                    }
                    else
                    {
                        if (obj.Text.Equals(mineCharacter.ToString()))
                        {
                            obj.Text = questionMark.ToString();
                            markedMines--;
                        }
                        else
                        {
                            obj.Text = String.Empty;
                        }
                    }

                    tbMinesCounter.Text = markedMines.ToString();
                }

                if (e.Button == MouseButtons.Left)
                {
                    if (!obj.Text.Equals(mineCharacter.ToString()))
                    {
                        obj.Visible = false;
                    }

                    if (getPlayingFieldButton(obj.Location).Text.Equals(mineCharacter.ToString()) && !obj.Text.Equals(mineCharacter.ToString()))
                    {
                        t1.Stop();
                        exposeAlleMines();
                        gameOver = true;
                    }
                }

                if (isWinner() && isAnyPlayingFieldCoverUpButtonVisibleAndNotMarked())
                {
                    t1.Stop();
                    MessageBox.Show("You're Won!");
                }
            }
        }

        /// <summary>
        /// sets visibility of all buttons from playing field cover up to false if a mine is under it
        /// </summary>
        private void exposeAlleMines()
        {
            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    if (playingField[column, row].Text.Equals(mineCharacter.ToString()) && !playingFieldCoverUp[column, row].Text.Equals(mineCharacter.ToString()))
                        playingFieldCoverUp[column, row].Visible = false;
                }
            }
        }
        
        /// <summary>
        /// event to restart the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(Object sender, EventArgs e)
        {
            initGame();
            t1.Stop();
        }

        /// <summary>
        /// gets a playing field button object of a spezified point
        /// </summary>
        /// <param name="p">the location of the button</param>
        /// <returns></returns>
        private Button getPlayingFieldButton(Point p)
        {
            Button obj = null;

            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    if (playingField[column, row].Location == p)
                    {
                        obj = playingField[column, row];
                        break;
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// checks if the right amount and location of every mine is set correctly
        /// </summary>
        /// <returns>true, if every marked mine is correkt, false else</returns>
        private bool isWinner()
        {
            bool winner = false;

            if (markedMines == minesAmount)
            {
                for (int row = 0; row < playingFieldHeight; row++)
                {
                    for (int column = 0; column < playingFieldWidth; column++)
                    {
                        if (playingFieldCoverUp[column, row].Text.Equals(mineCharacter.ToString()))
                        {
                            if (playingField[column, row].Text.Equals(mineCharacter.ToString()))
                                winner = true;
                            else
                                return false;
                        }
                    }
                }
            }

            return winner;
        }

        /// <summary>
        /// checks if every button of the playing field cover up is pressed and marked as a mine
        /// </summary>
        /// <returns>true, if every playing field cover up button is not visible (pressed) and doesn't marked as a mine, false else</returns>
        private bool isAnyPlayingFieldCoverUpButtonVisibleAndNotMarked()
        {
            bool isVisibleAndNotMarked = false;

            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    if (playingFieldCoverUp[column, row].Visible && !playingFieldCoverUp[column, row].Text.Equals(mineCharacter.ToString()))
                        return false;
                    else
                        isVisibleAndNotMarked = true;
                }
            }

            return isVisibleAndNotMarked;
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            tbTimer.Text = (sec++).ToString();
        }
    }
}
