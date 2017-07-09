using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ms_v1
{
    public partial class MainForm : Form
    {
        // playing field bounderies
        int width = 9;
        int height = 9;

        // start location
        int xLocation = 20;
        int yLocation = 80;

        // button size
        int buttonSize = 40;

        // amount of mines
        int minesAmount = 10;

        int markedMines = 0;

        // spezific character for the mine
        char mineCharacter = '#';
        char notSureCharacter = '?';

        bool gameOver;

        // some controls
        Panel panel1;
        TextBox tbMinesAmount;
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

            // evtl in andere methode auslagern
            btnStart = new Button();
            btnStart.Location = new Point(170, 12);
            btnStart.Text = "Restart";
            btnStart.Click += new EventHandler(btnStart_Click);
            this.Controls.Add(btnStart);

            panel1 = new Panel();
            panel1.Location = new Point(12, 77);
            panel1.AutoSize = true;
            this.Controls.Add(panel1);

            xLocation = panel1.Location.X;
            yLocation = panel1.Location.Y;

            tbMinesAmount = new TextBox();
            tbMinesAmount.ReadOnly = true;
            tbMinesAmount.Enabled = false;
            tbMinesAmount.Location = new Point(327, 12);
            this.Controls.Add(tbMinesAmount);

            tbMinesCounter = new TextBox();
            tbMinesCounter.ReadOnly = true;
            tbMinesCounter.Enabled = false;
            tbMinesCounter.Location = new Point(12, 12);
            this.Controls.Add(tbMinesCounter);

            AddPlayingFieldCoverUp();
            AddPlayingField();
            DistributeMines();
            DistributeHints();

            tbMinesAmount.Text = minesAmount.ToString();
            tbMinesCounter.Text = "0";
        }

        /// <summary>
        /// distributes the hints for each adjacant mine
        /// </summary>
        private void DistributeHints()
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int minesCount = 0;

                    if (!playingField[column, row].Text.Equals(mineCharacter.ToString()))
                    {
                        if (column - 1 >= 0 && playingField[column - 1, row].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (column + 1 < width && playingField[column + 1, row].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row - 1 >= 0 && playingField[column, row - 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row - 1 >= 0 && column - 1 >= 0 && playingField[column - 1, row - 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row - 1 >= 0 && column + 1 < width && playingField[column + 1, row - 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row + 1 < height && playingField[column, row + 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row + 1 < height && column - 1 >= 0 && playingField[column - 1, row + 1].Text.Equals(mineCharacter.ToString()))
                            minesCount++;

                        if (row + 1 < height && column + 1 < width && playingField[column + 1, row + 1].Text.Equals(mineCharacter.ToString()))
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

                int row = rnd.Next(0, height);
                int column = rnd.Next(0, width);

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
            int x = xLocation;
            int y = yLocation;

            playingField = new Button[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
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
                x = xLocation;
                y += buttonSize;
            }
        }

        /// <summary>
        /// creates a playing field cover up which also consists of buttons
        /// </summary>
        private void AddPlayingFieldCoverUp()
        {
            int wnh = buttonSize;
            int x = xLocation;
            int y = yLocation;

            playingFieldCoverUp = new Button[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
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
                x = xLocation;
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
            if (!gameOver)
            {
                Button obj = (Button)sender;

                if (e.Button == MouseButtons.Right)
                {
                    if (!obj.Text.Equals(mineCharacter.ToString()))
                    {
                        obj.Text = mineCharacter.ToString();
                        obj.ForeColor = Color.Red;
                        markedMines++;
                    }
                    else
                    {
                        obj.Text = String.Empty;
                        markedMines--;
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
                        MessageBox.Show("Game Over!");
                        exposeAlleMines();
                        gameOver = true;
                    }

                    // TO DO: clear method if no mine around (see original minesweeper)
                }

                if (isWinner() && isAnyPlayingFieldCoverUpButtonVisibleAndNotMarked())
                    MessageBox.Show("You're Won!");
            }
        }

        /// <summary>
        /// sets visibility of all buttons from playing field cover up to false if a mine is under it
        /// </summary>
        private void exposeAlleMines()
        {
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (playingField[column, row].Text.Equals(mineCharacter.ToString()))
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
        }

        /// <summary>
        /// gets a playing field button object of a spezified point
        /// </summary>
        /// <param name="p">the location of the button</param>
        /// <returns></returns>
        private Button getPlayingFieldButton(Point p)
        {
            Button obj = null;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
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
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
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

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (playingFieldCoverUp[column, row].Visible && !playingFieldCoverUp[column, row].Text.Equals(mineCharacter.ToString()))
                        return false;
                    else
                        isVisibleAndNotMarked = true;
                }
            }

            return isVisibleAndNotMarked;
        }
    }
}
