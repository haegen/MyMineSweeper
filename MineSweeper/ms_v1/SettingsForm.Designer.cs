namespace ms_v1
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null ))
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBeginnerHeight = new System.Windows.Forms.TextBox();
            this.tbBeginnerWidth = new System.Windows.Forms.TextBox();
            this.tbBeginnerMines = new System.Windows.Forms.TextBox();
            this.tbIntermediateMines = new System.Windows.Forms.TextBox();
            this.tbIntermediateWidth = new System.Windows.Forms.TextBox();
            this.tbIntermediateHeight = new System.Windows.Forms.TextBox();
            this.tbExpertMines = new System.Windows.Forms.TextBox();
            this.tbExpertWidth = new System.Windows.Forms.TextBox();
            this.tbExpertHeight = new System.Windows.Forms.TextBox();
            this.rbBeginner = new System.Windows.Forms.RadioButton();
            this.rbIntermediate = new System.Windows.Forms.RadioButton();
            this.rbExpert = new System.Windows.Forms.RadioButton();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.tbCustomMines = new System.Windows.Forms.TextBox();
            this.tbCustomWidth = new System.Windows.Forms.TextBox();
            this.tbCustomHeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mines";
            // 
            // tbBeginnerHeight
            // 
            this.tbBeginnerHeight.Enabled = false;
            this.tbBeginnerHeight.Location = new System.Drawing.Point(101, 24);
            this.tbBeginnerHeight.Name = "tbBeginnerHeight";
            this.tbBeginnerHeight.ReadOnly = true;
            this.tbBeginnerHeight.Size = new System.Drawing.Size(35, 20);
            this.tbBeginnerHeight.TabIndex = 3;
            this.tbBeginnerHeight.TabStop = false;
            this.tbBeginnerHeight.Text = "9";
            // 
            // tbBeginnerWidth
            // 
            this.tbBeginnerWidth.Enabled = false;
            this.tbBeginnerWidth.Location = new System.Drawing.Point(142, 24);
            this.tbBeginnerWidth.Name = "tbBeginnerWidth";
            this.tbBeginnerWidth.ReadOnly = true;
            this.tbBeginnerWidth.Size = new System.Drawing.Size(35, 20);
            this.tbBeginnerWidth.TabIndex = 4;
            this.tbBeginnerWidth.TabStop = false;
            this.tbBeginnerWidth.Text = "9";
            // 
            // tbBeginnerMines
            // 
            this.tbBeginnerMines.Enabled = false;
            this.tbBeginnerMines.Location = new System.Drawing.Point(183, 24);
            this.tbBeginnerMines.Name = "tbBeginnerMines";
            this.tbBeginnerMines.ReadOnly = true;
            this.tbBeginnerMines.Size = new System.Drawing.Size(35, 20);
            this.tbBeginnerMines.TabIndex = 5;
            this.tbBeginnerMines.TabStop = false;
            this.tbBeginnerMines.Text = "10";
            // 
            // tbIntermediateMines
            // 
            this.tbIntermediateMines.Enabled = false;
            this.tbIntermediateMines.Location = new System.Drawing.Point(183, 50);
            this.tbIntermediateMines.Name = "tbIntermediateMines";
            this.tbIntermediateMines.ReadOnly = true;
            this.tbIntermediateMines.Size = new System.Drawing.Size(35, 20);
            this.tbIntermediateMines.TabIndex = 8;
            this.tbIntermediateMines.TabStop = false;
            this.tbIntermediateMines.Text = "40";
            // 
            // tbIntermediateWidth
            // 
            this.tbIntermediateWidth.Enabled = false;
            this.tbIntermediateWidth.Location = new System.Drawing.Point(142, 50);
            this.tbIntermediateWidth.Name = "tbIntermediateWidth";
            this.tbIntermediateWidth.ReadOnly = true;
            this.tbIntermediateWidth.Size = new System.Drawing.Size(35, 20);
            this.tbIntermediateWidth.TabIndex = 7;
            this.tbIntermediateWidth.TabStop = false;
            this.tbIntermediateWidth.Text = "16";
            // 
            // tbIntermediateHeight
            // 
            this.tbIntermediateHeight.Enabled = false;
            this.tbIntermediateHeight.Location = new System.Drawing.Point(101, 50);
            this.tbIntermediateHeight.Name = "tbIntermediateHeight";
            this.tbIntermediateHeight.ReadOnly = true;
            this.tbIntermediateHeight.Size = new System.Drawing.Size(35, 20);
            this.tbIntermediateHeight.TabIndex = 6;
            this.tbIntermediateHeight.TabStop = false;
            this.tbIntermediateHeight.Text = "16";
            // 
            // tbExpertMines
            // 
            this.tbExpertMines.Enabled = false;
            this.tbExpertMines.Location = new System.Drawing.Point(183, 76);
            this.tbExpertMines.Name = "tbExpertMines";
            this.tbExpertMines.ReadOnly = true;
            this.tbExpertMines.Size = new System.Drawing.Size(35, 20);
            this.tbExpertMines.TabIndex = 11;
            this.tbExpertMines.TabStop = false;
            this.tbExpertMines.Text = "99";
            // 
            // tbExpertWidth
            // 
            this.tbExpertWidth.Enabled = false;
            this.tbExpertWidth.Location = new System.Drawing.Point(142, 76);
            this.tbExpertWidth.Name = "tbExpertWidth";
            this.tbExpertWidth.ReadOnly = true;
            this.tbExpertWidth.Size = new System.Drawing.Size(35, 20);
            this.tbExpertWidth.TabIndex = 10;
            this.tbExpertWidth.TabStop = false;
            this.tbExpertWidth.Text = "30";
            // 
            // tbExpertHeight
            // 
            this.tbExpertHeight.Enabled = false;
            this.tbExpertHeight.Location = new System.Drawing.Point(101, 76);
            this.tbExpertHeight.Name = "tbExpertHeight";
            this.tbExpertHeight.ReadOnly = true;
            this.tbExpertHeight.Size = new System.Drawing.Size(35, 20);
            this.tbExpertHeight.TabIndex = 9;
            this.tbExpertHeight.TabStop = false;
            this.tbExpertHeight.Text = "16";
            // 
            // rbBeginner
            // 
            this.rbBeginner.AutoSize = true;
            this.rbBeginner.Location = new System.Drawing.Point(12, 25);
            this.rbBeginner.Name = "rbBeginner";
            this.rbBeginner.Size = new System.Drawing.Size(67, 17);
            this.rbBeginner.TabIndex = 12;
            this.rbBeginner.TabStop = true;
            this.rbBeginner.Text = "Beginner";
            this.rbBeginner.UseVisualStyleBackColor = true;
            this.rbBeginner.CheckedChanged += new System.EventHandler(this.rb_CheckedChange);
            // 
            // rbIntermediate
            // 
            this.rbIntermediate.AutoSize = true;
            this.rbIntermediate.Location = new System.Drawing.Point(12, 51);
            this.rbIntermediate.Name = "rbIntermediate";
            this.rbIntermediate.Size = new System.Drawing.Size(83, 17);
            this.rbIntermediate.TabIndex = 13;
            this.rbIntermediate.TabStop = true;
            this.rbIntermediate.Text = "Intermediate";
            this.rbIntermediate.UseVisualStyleBackColor = true;
            this.rbIntermediate.CheckedChanged += new System.EventHandler(this.rb_CheckedChange);
            // 
            // rbExpert
            // 
            this.rbExpert.AutoSize = true;
            this.rbExpert.Location = new System.Drawing.Point(12, 77);
            this.rbExpert.Name = "rbExpert";
            this.rbExpert.Size = new System.Drawing.Size(55, 17);
            this.rbExpert.TabIndex = 14;
            this.rbExpert.TabStop = true;
            this.rbExpert.Text = "Expert";
            this.rbExpert.UseVisualStyleBackColor = true;
            this.rbExpert.CheckedChanged += new System.EventHandler(this.rb_CheckedChange);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(12, 128);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(83, 23);
            this.btnNewGame.TabIndex = 15;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(12, 103);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(60, 17);
            this.rbCustom.TabIndex = 16;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "Custom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rb_CheckedChange);
            // 
            // tbCustomMines
            // 
            this.tbCustomMines.Location = new System.Drawing.Point(183, 102);
            this.tbCustomMines.Name = "tbCustomMines";
            this.tbCustomMines.Size = new System.Drawing.Size(35, 20);
            this.tbCustomMines.TabIndex = 19;
            this.tbCustomMines.Text = "145";
            // 
            // tbCustomWidth
            // 
            this.tbCustomWidth.Location = new System.Drawing.Point(142, 102);
            this.tbCustomWidth.Name = "tbCustomWidth";
            this.tbCustomWidth.Size = new System.Drawing.Size(35, 20);
            this.tbCustomWidth.TabIndex = 18;
            this.tbCustomWidth.Text = "30";
            // 
            // tbCustomHeight
            // 
            this.tbCustomHeight.Location = new System.Drawing.Point(101, 102);
            this.tbCustomHeight.Name = "tbCustomHeight";
            this.tbCustomHeight.Size = new System.Drawing.Size(35, 20);
            this.tbCustomHeight.TabIndex = 17;
            this.tbCustomHeight.Text = "20";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 160);
            this.Controls.Add(this.tbCustomMines);
            this.Controls.Add(this.tbCustomWidth);
            this.Controls.Add(this.tbCustomHeight);
            this.Controls.Add(this.rbCustom);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.rbExpert);
            this.Controls.Add(this.rbIntermediate);
            this.Controls.Add(this.rbBeginner);
            this.Controls.Add(this.tbExpertMines);
            this.Controls.Add(this.tbExpertWidth);
            this.Controls.Add(this.tbExpertHeight);
            this.Controls.Add(this.tbIntermediateMines);
            this.Controls.Add(this.tbIntermediateWidth);
            this.Controls.Add(this.tbIntermediateHeight);
            this.Controls.Add(this.tbBeginnerMines);
            this.Controls.Add(this.tbBeginnerWidth);
            this.Controls.Add(this.tbBeginnerHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBeginnerHeight;
        private System.Windows.Forms.TextBox tbBeginnerWidth;
        private System.Windows.Forms.TextBox tbBeginnerMines;
        private System.Windows.Forms.TextBox tbIntermediateMines;
        private System.Windows.Forms.TextBox tbIntermediateWidth;
        private System.Windows.Forms.TextBox tbIntermediateHeight;
        private System.Windows.Forms.TextBox tbExpertMines;
        private System.Windows.Forms.TextBox tbExpertWidth;
        private System.Windows.Forms.TextBox tbExpertHeight;
        private System.Windows.Forms.RadioButton rbBeginner;
        private System.Windows.Forms.RadioButton rbIntermediate;
        private System.Windows.Forms.RadioButton rbExpert;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.TextBox tbCustomMines;
        private System.Windows.Forms.TextBox tbCustomWidth;
        private System.Windows.Forms.TextBox tbCustomHeight;
    }
}