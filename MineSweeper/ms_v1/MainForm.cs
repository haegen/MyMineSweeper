using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ms_v1
{
    public partial class MainForm : Form
    {
        // playing field bounderies
        int playingFieldWidth;
        int playingFieldHeight;

        // start location
        int panelLocationX;
        int panelLocationY;

        int buttonSize;
        int textBoxSize;
        int minesAmount;
        int markedMines;
        int playingMode;
        bool gameOver;
        int score;

        // spezific character for the mine
        char mineCharacter = '#';
        char questionMark = '?';
        char falseMine = 'F';

        Timer t1;
        int sec;

        // some controls
        MenuStrip menu;
        ToolStripButton gameSettings;
        Panel panel;
        TextBox tbTimer;
        TextBox tbMinesCounter;
        Button btnStart;
        Button[,] playingField;
        Button[,] playingFieldCoverUp;

        public MainForm()
        {
            InitializeComponent();
            initGame(9, 9, 10, 1);
        }

        /// <summary>
        /// initialize game gomponents
        /// </summary>
        public void initGame(int height, int width, int mines, int mode)
        {
            this.Controls.Clear();

            if (t1 != null)
            {
                t1.Dispose();
            }

            // initialize variables
            gameOver = false;
            markedMines = 0;
            sec = 0;
            playingFieldWidth = width;
            playingFieldHeight = height;
            panelLocationX = 20;
            panelLocationY = 124;
            buttonSize = 30;
            textBoxSize = 40;
            minesAmount = mines;
            markedMines = 0;
            score = 0;
            playingMode = mode;

            this.Width = panelLocationX + ((playingFieldWidth * buttonSize) + 15) + panelLocationX;
            this.Height = panelLocationY + ((playingFieldHeight * buttonSize)) + 60;

            // menu
            menu = new MenuStrip();
            gameSettings = new ToolStripButton();
            gameSettings.Text = "Settings";
            gameSettings.Click += new EventHandler(gameSettings_Click);
            menu.Items.Add(gameSettings);
            this.Controls.Add(menu);

            // Timer
            t1 = new Timer();
            t1.Interval = 1000;
            t1.Tick += new EventHandler(t1_Tick);

            // evtl in andere methode auslagern
            btnStart = new Button();
            btnStart.Size = new Size(60, 60);
            btnStart.Location = new Point(this.Width / 2 - btnStart.Size.Width / 2 - 7, menu.Height + 20);
            btnStart.Text = "Restart";
            btnStart.TabStop = false;
            btnStart.Click += new EventHandler(btnStart_Click);
            this.Controls.Add(btnStart);

            // Timer Textbox
            tbTimer = new TextBox();
            tbTimer.Enabled = false;
            tbTimer.Multiline = true;
            tbTimer.TextAlign = HorizontalAlignment.Center;
            tbTimer.Size = new Size(textBoxSize, textBoxSize);
            tbTimer.Location = new Point(this.Width - panelLocationX - 15 - textBoxSize, menu.Height + 20);
            this.Controls.Add(tbTimer);

            // MineCounter Textbox
            tbMinesCounter = new TextBox();
            tbMinesCounter.Enabled = false;
            tbMinesCounter.Multiline = true;
            tbMinesCounter.TextAlign = HorizontalAlignment.Center;
            tbMinesCounter.Size = new Size(textBoxSize, textBoxSize);
            tbMinesCounter.Location = new Point(panelLocationX, menu.Height + 20);
            this.Controls.Add(tbMinesCounter);

            // Playing field panel
            panel = new Panel();
            panel.Location = new Point(panelLocationX, panelLocationY);
            panel.Size = new Size(playingFieldWidth * buttonSize, playingFieldHeight * buttonSize);
            this.Controls.Add(panel);

            AddPlayingFieldCoverUp();
            AddPlayingField();
            DistributeMines();
            //playingField[2, 2].Text = mineCharacter.ToString();
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
                        if (column - 1 >= 0)
                        {
                            if (playingField[column - 1, row].Text.Equals(mineCharacter.ToString()))
                            {
                                minesCount++;
                            }

                            if (row - 1 >= 0)
                            {
                                if (playingField[column - 1, row - 1].Text.Equals(mineCharacter.ToString()))
                                {
                                    minesCount++;
                                }
                            }

                            if (row + 1 < playingFieldHeight)
                            {
                                if (playingField[column - 1, row + 1].Text.Equals(mineCharacter.ToString()))
                                {
                                    minesCount++;
                                }
                            }
                        }

                        if (column + 1 < playingFieldWidth)
                        {
                            if (playingField[column + 1, row].Text.Equals(mineCharacter.ToString()))
                            {
                                minesCount++;
                            }

                            if (row - 1 >= 0)
                            {
                                if (playingField[column + 1, row - 1].Text.Equals(mineCharacter.ToString()))
                                {
                                    minesCount++;
                                }
                            }

                            if (row + 1 < playingFieldHeight)
                            {
                                if (playingField[column + 1, row + 1].Text.Equals(mineCharacter.ToString()))
                                {
                                    minesCount++;
                                }
                            }
                        }
                        
                        if (row - 1 >= 0)
                        {
                            if (playingField[column, row - 1].Text.Equals(mineCharacter.ToString()))
                            {
                                minesCount++;
                            }
                        }
                        
                        if (row + 1 < playingFieldHeight)
                        {
                            if (playingField[column, row + 1].Text.Equals(mineCharacter.ToString()))
                            {
                                minesCount++;
                            }
                        }

                        if (minesCount != 0)
                        {

                            switch (minesCount)
                            {
                                case 1:
                                    playingField[column, row].ForeColor = Color.Blue;
                                    break;

                                case 2:
                                    playingField[column, row].ForeColor = Color.Green;
                                    break;

                                case 3:
                                    playingField[column, row].ForeColor = Color.Red;
                                    break;

                                case 4:
                                    playingField[column, row].ForeColor = Color.DarkBlue;
                                    break;

                                case 5:
                                    playingField[column, row].ForeColor = Color.DarkRed;
                                    break;

                                case 6:
                                    playingField[column, row].ForeColor = Color.Cyan;
                                    break;

                                case 7:
                                    playingField[column, row].ForeColor = Color.Purple;
                                    break;

                                case 8:
                                    playingField[column, row].ForeColor = Color.YellowGreen;
                                    break;
                            }

                            playingField[column, row].Text = minesCount.ToString();
                            playingField[column, row].Enabled = true;
                            playingField[column, row].BackColor = Color.DarkGray;
                        }
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
                {
                    break;
                }

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
                    btn.Name = "btn" + column + "_"+ row;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                    btn.BackColor = Color.DarkGray;
                    btn.MouseDown += new MouseEventHandler(btnPlayingField_Click);

                    panel.Controls.Add(btn);
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
                    btn.Name = "btn" + column + "_" + row;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
                    btn.MouseDown += new MouseEventHandler(btnPlayingFieldCoverUp_Click);

                    panel.Controls.Add(btn);
                    playingFieldCoverUp[column, row] = btn;

                    x += buttonSize;
                }
                x = 0;
                y += buttonSize;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayingField_Click(Object sender, MouseEventArgs e)
        {
            if (!gameOver)
            {
                Button obj = (Button)sender;

                if (e.Button == MouseButtons.Middle)
                {
                    if (isAmountOfMinesMarked(obj))
                    {
                        bla(obj);
                    }

                    if (isWinner() && isAnyPlayingFieldCoverUpButtonVisibleAndNotMarked())
                    {
                        t1.Stop();
                        score = (int)((double)minesAmount / Convert.ToInt32(tbTimer.Text) * 1000 * playingMode);
                        MessageBox.Show("You're Won!\n\nScore: " + score);
                    }
                }
            }
        }

        // buggy
        private void bla(Button obj)
        {
            Point p = getCoordinates(obj);
            int column = p.X;
            int row = p.Y;

            if (column - 1 >= 0)
            {
                if (!playingFieldCoverUp[column - 1, row].Text.Equals(mineCharacter.ToString()))
                {
                    playingFieldCoverUp[column - 1, row].Visible = false;
                    if (playingField[column - 1, row].Text.Equals(String.Empty))
                    {
                        clearBlanks(playingField[column - 1, row]);
                    }

                    if (playingField[column - 1, row].Text.Equals(mineCharacter.ToString()))
                    {
                        exposeAlleMines();
                    }
                }

                if (row - 1 >= 0)
                {
                    if (!playingFieldCoverUp[column - 1, row - 1].Text.Equals(mineCharacter.ToString()))
                    {
                        playingFieldCoverUp[column - 1, row - 1].Visible = false;
                        if (playingField[column - 1, row - 1].Text.Equals(String.Empty))
                        {
                            clearBlanks(playingField[column - 1, row - 1]);
                        }

                        if (playingField[column - 1, row - 1].Text.Equals(mineCharacter.ToString()))
                        {
                            exposeAlleMines();
                        }
                    }
                }

                if (row + 1 < playingFieldHeight)
                {
                    if (!playingFieldCoverUp[column - 1, row + 1].Text.Equals(mineCharacter.ToString()))
                    {
                        playingFieldCoverUp[column - 1, row + 1].Visible = false;
                        if (playingField[column - 1, row + 1].Text.Equals(String.Empty))
                        {
                            clearBlanks(playingField[column - 1, row + 1]);
                        }

                        if (playingField[column - 1, row + 1].Text.Equals(mineCharacter.ToString()))
                        {
                            exposeAlleMines();
                        }
                    }
                }
            }

            if (column + 1 < playingFieldWidth)
            {
                if (!playingFieldCoverUp[column + 1, row].Text.Equals(mineCharacter.ToString()))
                {
                    playingFieldCoverUp[column + 1, row].Visible = false;
                    if (playingField[column + 1, row].Text.Equals(String.Empty))
                    {
                        clearBlanks(playingField[column + 1, row]);
                    }

                    if (playingField[column + 1, row].Text.Equals(mineCharacter.ToString()))
                    {
                        exposeAlleMines();
                    }
                }

                if (row - 1 >= 0)
                {
                    if (!playingFieldCoverUp[column + 1, row - 1].Text.Equals(mineCharacter.ToString()))
                    {
                        playingFieldCoverUp[column + 1, row - 1].Visible = false;
                        if (playingField[column + 1, row - 1].Text.Equals(String.Empty))
                        {
                            clearBlanks(playingField[column + 1, row - 1]);
                        }

                        if (playingField[column + 1, row - 1].Text.Equals(mineCharacter.ToString()))
                        {
                            exposeAlleMines();
                        }
                    }
                }

                if (row + 1 < playingFieldHeight)
                {
                    if (!playingFieldCoverUp[column + 1, row + 1].Text.Equals(mineCharacter.ToString()))
                    {
                        playingFieldCoverUp[column + 1, row + 1].Visible = false;
                        if (playingField[column + 1, row + 1].Text.Equals(String.Empty))
                        {
                            clearBlanks(playingField[column + 1, row + 1]);
                        }

                        if (playingField[column + 1, row + 1].Text.Equals(mineCharacter.ToString()))
                        {
                            exposeAlleMines();
                        }
                    }
                }
            }

            if (row - 1 >= 0)
            {
                if (!playingFieldCoverUp[column, row - 1].Text.Equals(mineCharacter.ToString()))
                {
                    playingFieldCoverUp[column, row - 1].Visible = false;
                    if (playingField[column, row - 1].Text.Equals(String.Empty))
                    {
                        clearBlanks(playingField[column, row - 1]);
                    }

                    if (playingField[column, row - 1].Text.Equals(mineCharacter.ToString()))
                    {
                        exposeAlleMines();
                    }
                }
            }

            if (row + 1 < playingFieldHeight)
            {
                if (!playingFieldCoverUp[column, row + 1].Text.Equals(mineCharacter.ToString()))
                {
                    playingFieldCoverUp[column, row + 1].Visible = false;
                    if (playingField[column, row + 1].Text.Equals(String.Empty))
                    {
                        clearBlanks(playingField[column, row + 1]);
                    }

                    if (playingField[column, row + 1].Text.Equals(mineCharacter.ToString()))
                    {
                        exposeAlleMines();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool isAmountOfMinesMarked(Button obj)
        {
            bool isAmountOfMinesMarked = false;

            Point p = getCoordinates(obj);
            int column = p.X;
            int row = p.Y;

            int amount = 0;

            if (column - 1 >= 0)
            {
                if (playingFieldCoverUp[column - 1, row].Text.Equals(mineCharacter.ToString()))
                {
                    amount++;
                }

                if (row - 1 >= 0)
                {
                    if (playingFieldCoverUp[column - 1, row - 1].Text.Equals(mineCharacter.ToString()))
                    {
                        amount++;
                    }
                }

                if (row + 1 < playingFieldHeight)
                {
                    if (playingFieldCoverUp[column - 1, row + 1].Text.Equals(mineCharacter.ToString()))
                    {
                        amount++;
                    }
                }
            }

            if (column + 1 < playingFieldWidth)
            {
                if (playingFieldCoverUp[column + 1, row].Text.Equals(mineCharacter.ToString()))
                {
                    amount++;
                }

                if (row - 1 >= 0)
                {
                    if (playingFieldCoverUp[column + 1, row - 1].Text.Equals(mineCharacter.ToString()))
                    {
                        amount++;
                    }
                }

                if (row + 1 < playingFieldHeight)
                {
                    if (playingFieldCoverUp[column + 1, row + 1].Text.Equals(mineCharacter.ToString()))
                    {
                        amount++;
                    }
                }
            }

            if (row - 1 >= 0)
            {
                if (playingFieldCoverUp[column, row - 1].Text.Equals(mineCharacter.ToString()))
                {
                    amount++;
                }
            }

            if (row + 1 < playingFieldHeight)
            {
                if (playingFieldCoverUp[column, row + 1].Text.Equals(mineCharacter.ToString()))
                {
                    amount++;
                }
            }

            if (obj.Text.Equals(amount.ToString()))
            {
                isAmountOfMinesMarked = true;
            }

            return isAmountOfMinesMarked;
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
        private void btnPlayingFieldCoverUp_Click(Object sender, MouseEventArgs e)
        {
            if (!gameOver)
            {
                t1.Start();
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
                            obj.ForeColor = Color.Blue;
                            markedMines--;
                        }
                        else
                        {
                            obj.Text = String.Empty;
                        }
                    }

                    tbMinesCounter.Text = (minesAmount - markedMines).ToString();
                }

                if (e.Button == MouseButtons.Left)
                {
                    if (obj.Text.Equals(String.Empty))
                    {
                        obj.Visible = false;
                        clearBlanks(obj);
                    }

                    Point p = getCoordinates(obj);
                    int column = p.X;
                    int row = p.Y;
                    if (playingField[column, row].Text.Equals(mineCharacter.ToString()) && obj.Text.Equals(String.Empty))
                    {
                        exposeAlleMines();
                    }
                }

                if (isWinner() && isAnyPlayingFieldCoverUpButtonVisibleAndNotMarked())
                {
                    t1.Stop();
                    score = (int)((double)minesAmount / Convert.ToInt32(tbTimer.Text) * 1000 * playingMode);
                    MessageBox.Show("You're Won!\n\nScore: " + score);
                }
            }
        }

        /// <summary>
        /// clears all blank playingField buttons, if an button with no number (hint) is exposed
        /// </summary>
        /// <param name="sender">the playingfieldcoverup button</param>
        private void clearBlanks(Button sender) 
        {
            Point coordinates = getCoordinates(sender);
            int column = coordinates.X;
            int row = coordinates.Y;

            List<Point> blanks = new List<Point>();

            do
            {
                if (blanks.Count > 0)
                {
                    coordinates = blanks.ElementAt(0);
                    blanks.RemoveAt(0);
                    column = coordinates.X;
                    row = coordinates.Y;
                }

                if (playingField[column, row].Text.Equals(String.Empty))
                {
                    if (column + 1 < playingFieldWidth)
                    {
                        if (playingFieldCoverUp[column + 1, row].Visible)
                        {
                            if (playingFieldCoverUp[column + 1, row].Text.Equals(String.Empty))
                            {
                                playingFieldCoverUp[column + 1, row].Visible = false;
                                if (playingField[column + 1, row].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                {
                                    blanks.Add(new Point(column + 1, row));
                                }
                            }
                        }

                        if (row + 1 < playingFieldHeight)
                        {
                            if (playingFieldCoverUp[column + 1, row + 1].Visible)
                            {
                                if (playingFieldCoverUp[column + 1, row + 1].Text.Equals(String.Empty))
                                {
                                    playingFieldCoverUp[column + 1, row + 1].Visible = false;
                                    if (playingField[column + 1, row + 1].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                    {
                                        blanks.Add(new Point(column + 1, row + 1));
                                    }
                                }
                            }
                        }

                        if (row - 1 >= 0)
                        {
                            if (playingFieldCoverUp[column + 1, row - 1].Visible)
                            {
                                if (playingFieldCoverUp[column + 1, row - 1].Text.Equals(String.Empty))
                                {
                                    playingFieldCoverUp[column + 1, row - 1].Visible = false;
                                    if (playingField[column + 1, row - 1].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                    {
                                        blanks.Add(new Point(column + 1, row - 1));
                                    }
                                }
                            }
                        }
                    }

                    if (column - 1 >= 0)
                    {
                        if (playingFieldCoverUp[column - 1, row].Visible)
                        {
                            if (playingFieldCoverUp[column - 1, row].Text.Equals(String.Empty))
                            {
                                playingFieldCoverUp[column - 1, row].Visible = false;
                                if (playingField[column - 1, row].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                {
                                    blanks.Add(new Point(column - 1, row));
                                }
                            }
                        }

                        if (row + 1 < playingFieldHeight)
                        {
                            if (playingFieldCoverUp[column - 1, row + 1].Visible)
                            {
                                if (playingFieldCoverUp[column - 1, row + 1].Text.Equals(String.Empty))
                                {
                                    playingFieldCoverUp[column - 1, row + 1].Visible = false;
                                    if (playingField[column - 1, row + 1].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                    {
                                        blanks.Add(new Point(column - 1, row + 1));
                                    }
                                }
                            }
                        }

                        if (row - 1 >= 0)
                        {
                            if (playingFieldCoverUp[column - 1, row - 1].Visible)
                            {
                                if (playingFieldCoverUp[column - 1, row - 1].Text.Equals(String.Empty))
                                {
                                    playingFieldCoverUp[column - 1, row - 1].Visible = false;
                                    if (playingField[column - 1, row - 1].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                    {
                                        blanks.Add(new Point(column - 1, row - 1));
                                    }
                                }
                            }
                        }
                    }

                    if (row + 1 < playingFieldHeight)
                    {
                        if (playingFieldCoverUp[column, row + 1].Visible)
                        {
                            if (playingFieldCoverUp[column, row + 1].Text.Equals(String.Empty))
                            {
                                playingFieldCoverUp[column, row + 1].Visible = false;
                                if (playingField[column, row + 1].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                {
                                    blanks.Add(new Point(column, row + 1));
                                }
                            }
                        }
                    }

                    if (row - 1 >= 0)
                    {
                        if (playingFieldCoverUp[column, row - 1].Visible)
                        {
                            if (playingFieldCoverUp[column, row - 1].Text.Equals(String.Empty))
                            {
                                playingFieldCoverUp[column, row - 1].Visible = false;
                                if (playingField[column, row - 1].Text.Equals(String.Empty) && !blanks.Contains(coordinates))
                                {
                                    blanks.Add(new Point(column, row - 1));
                                }
                            }
                        }
                    }
                }

            } while (blanks.Count > 0);
        }

        /// <summary>
        /// get the array cooridnates (column, row) of a butten object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>the coordinates</returns>
        private Point getCoordinates(Button obj)
        {
            Point p = new Point();
            for (int row = 0; row < playingFieldHeight; row++)
            {
                for (int column = 0; column < playingFieldWidth; column++)
                {
                    if (playingField[column, row].Name.Equals(obj.Name))
                    {
                        p.X = column;
                        p.Y = row;
                        return p;
                    }
                }
            }
            return p;
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
                    if (playingFieldCoverUp[column, row].Text.Equals(mineCharacter.ToString()) && !playingField[column, row].Text.Equals(mineCharacter.ToString()))
                    {
                        playingFieldCoverUp[column, row].Text = falseMine.ToString();
                    }

                    if (playingField[column, row].Text.Equals(mineCharacter.ToString()) && !playingFieldCoverUp[column, row].Text.Equals(mineCharacter.ToString()))
                    {
                        //if (!playingFieldCoverUp[column, row].Text.Equals(falseMine.ToString()))
                        //{
                            playingFieldCoverUp[column, row].Visible = false;
                        //}
                    }
                }
            }

            t1.Stop();
            gameOver = true;
        }
        
        /// <summary>
        /// event to restart the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(Object sender, EventArgs e)
        {
            initGame(playingFieldHeight, playingFieldWidth, minesAmount, playingMode);
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
                            {
                                winner = true;
                            }
                            else
                            {
                                return false;
                            }
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
                    {
                        return false;
                    }
                    else
                    {
                        isVisibleAndNotMarked = true;
                    }
                }
            }

            return isVisibleAndNotMarked;
        }

        /// <summary>
        /// gets triggerd every second to increase the value of the timer textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Tick(Object sender, EventArgs e)
        {
            tbTimer.Text = (sec++).ToString();
        }

        /// <summary>
        /// gets triggerd if the toolstripmenu item is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameSettings_Click(Object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(this);
            sf.ShowDialog();
        }
    }
}
