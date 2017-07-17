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
    public partial class SettingsForm : Form
    {
        MainForm mf;

        int width;
        int height;
        int mines;
        int mode;

        public SettingsForm(MainForm mf)
        {
            InitializeComponent();

            this.mf = mf;
        }

        private void rb_CheckedChange(object sender, EventArgs e)
        {
            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (rbBeginner.Checked)
            {
                this.height = Convert.ToInt32(tbBeginnerHeight.Text);
                this.width = Convert.ToInt32(tbBeginnerWidth.Text);
                this.mines = Convert.ToInt32(tbBeginnerMines.Text);
                this.mode = 1;
            }

            if (rbIntermediate.Checked)
            {
                this.height = Convert.ToInt32(tbIntermediateHeight.Text);
                this.width = Convert.ToInt32(tbIntermediateWidth.Text);
                this.mines = Convert.ToInt32(tbIntermediateMines.Text);
                this.mode = 2;
            }

            if (rbExpert.Checked)
            {
                this.height = Convert.ToInt32(tbExpertHeight.Text);
                this.width = Convert.ToInt32(tbExpertWidth.Text);
                this.mines = Convert.ToInt32(tbExpertMines.Text);
                this.mode = 3;
            }

            if (rbCustom.Checked)
            {
                this.height = Convert.ToInt32(tbCustomHeight.Text);
                this.width = Convert.ToInt32(tbCustomWidth.Text);
                this.mines = Convert.ToInt32(tbCustomMines.Text);
                this.mode = 0;
            }

            mf.initGame(height, width, mines, mode);
            this.Close();
        }
    }
}
