namespace eCinema.WinUI
{
    partial class frmAddMovie
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
            this.components = new System.ComponentModel.Container();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnProducers = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSynopsis = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.clbGenres = new System.Windows.Forms.CheckedListBox();
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPoster
            // 
            this.pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPoster.Location = new System.Drawing.Point(397, 81);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(252, 260);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 0;
            this.pbPoster.TabStop = false;
            this.pbPoster.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(125, 67);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(251, 27);
            this.txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Release Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Duration (min)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Country";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(125, 100);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(251, 27);
            this.txtYear.TabIndex = 11;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(125, 133);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(251, 27);
            this.txtDuration.TabIndex = 15;
            // 
            // btnProducers
            // 
            this.btnProducers.Location = new System.Drawing.Point(535, 390);
            this.btnProducers.Name = "btnProducers";
            this.btnProducers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnProducers.Size = new System.Drawing.Size(114, 29);
            this.btnProducers.TabIndex = 20;
            this.btnProducers.Text = "Next step";
            this.btnProducers.UseVisualStyleBackColor = true;
            this.btnProducers.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(10, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Add Movie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(272, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Step: 1 of 5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Synopsis";
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Location = new System.Drawing.Point(127, 298);
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.Size = new System.Drawing.Size(253, 121);
            this.txtSynopsis.TabIndex = 24;
            this.txtSynopsis.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ofd";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Genres";
            // 
            // clbGenres
            // 
            this.clbGenres.CheckOnClick = true;
            this.clbGenres.FormattingEnabled = true;
            this.clbGenres.Location = new System.Drawing.Point(127, 200);
            this.clbGenres.Name = "clbGenres";
            this.clbGenres.Size = new System.Drawing.Size(251, 92);
            this.clbGenres.TabIndex = 27;
            this.clbGenres.SelectedIndexChanged += new System.EventHandler(this.clbGenres_SelectedIndexChanged);
            // 
            // cmbCountries
            // 
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(125, 166);
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(251, 28);
            this.cmbCountries.TabIndex = 28;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Poster";
            // 
            // frmAddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 432);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbCountries);
            this.Controls.Add(this.clbGenres);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnProducers);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.pbPoster);
            this.Name = "frmAddMovie";
            this.Text = "frmAddMovie";
            this.Load += new System.EventHandler(this.frmAddMovie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbPoster;
        private TextBox txtTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox txtYear;
        private TextBox txtDuration;
        private Button btnProducers;
        private Label label11;
        private Label label4;
        private Label label6;
        private RichTextBox txtSynopsis;
        private OpenFileDialog openFileDialog1;
        private Label label7;
        private CheckedListBox clbGenres;
        private ComboBox cmbCountries;
        private ErrorProvider err;
        private Label label8;
    }
}