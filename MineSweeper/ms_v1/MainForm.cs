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
        int width = 10;
        int height = 10;

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

        private void initGame()
        {
            this.Controls.Clear();

            playingField = new Button[width, height];
            playingFieldCoverUp = new Button[width, height];

            AddButtons();
            AddPlayingField();
            DistributeMines();
            DistributeHints();
        }

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

        private void AddPlayingField()
        {
            int wnh = buttonSize;
            int x = xLocation;
            int y = yLocation;

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

                    this.Controls.Add(btn);
                    playingField[column, row] = btn;

                    x += buttonSize;
                }
                x = xLocation;
                y += buttonSize;
            }
        }

        private void AddButtons()
        {
            int wnh = buttonSize;
            int x = xLocation;
            int y = yLocation;

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

                    this.Controls.Add(btn);
                    playingFieldCoverUp[column, row] = btn;

                    x += buttonSize;
                }
                x = xLocation;
                y += buttonSize;
            }
        }

        private void btn_Click(Object sender, MouseEventArgs e)
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
            }

            if (e.Button == MouseButtons.Left)
            {
                if (!obj.Text.Equals(mineCharacter.ToString()))
                {
                    obj.Visible = false;
                }

                if (getPlayingFieldButton(obj.Location).Text.Equals(mineCharacter.ToString()))
                {
                    if (MessageBox.Show("BOOM!\n\nRestart?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        initGame();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

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


    }
}
