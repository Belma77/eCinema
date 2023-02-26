namespace eCinema.WinUI
{
    partial class frmEditMovie
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
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.btnEditWriters = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.clbGenres = new System.Windows.Forms.CheckedListBox();
            this.txtSynopsis = new System.Windows.Forms.RichTextBox();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDirectors = new System.Windows.Forms.Button();
            this.btnProducers = new System.Windows.Forms.Button();
            this.btnEditActors = new System.Windows.Forms.Button();
            this.clbProducers = new System.Windows.Forms.CheckedListBox();
            this.clbDirectors = new System.Windows.Forms.CheckedListBox();
            this.clbWriters = new System.Windows.Forms.CheckedListBox();
            this.clbActors = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(8, 123);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(210, 27);
            this.txtYear.TabIndex = 2;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(8, 179);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(210, 27);
            this.txtDuration.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Title";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(8, 232);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(210, 28);
            this.cmbCountry.TabIndex = 12;
            // 
            // btnEditWriters
            // 
            this.btnEditWriters.Location = new System.Drawing.Point(242, 164);
            this.btnEditWriters.Name = "btnEditWriters";
            this.btnEditWriters.Size = new System.Drawing.Size(214, 29);
            this.btnEditWriters.TabIndex = 13;
            this.btnEditWriters.Text = "Add Writers";
            this.btnEditWriters.UseVisualStyleBackColor = true;
            this.btnEditWriters.Click += new System.EventHandler(this.btnEditWriters_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(600, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(94, 29);
            this.Save.TabIndex = 14;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(8, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 23);
            this.label11.TabIndex = 22;
            this.label11.Text = "Edit Movie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Genres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Release Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Duration (min)";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(8, 70);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(210, 27);
            this.txtTitle.TabIndex = 27;
            // 
            // clbGenres
            // 
            this.clbGenres.CheckOnClick = true;
            this.clbGenres.FormattingEnabled = true;
            this.clbGenres.Location = new System.Drawing.Point(8, 286);
            this.clbGenres.Name = "clbGenres";
            this.clbGenres.Size = new System.Drawing.Size(210, 92);
            this.clbGenres.TabIndex = 28;
            // 
            // txtSynopsis
            // 
            this.txtSynopsis.Location = new System.Drawing.Point(476, 305);
            this.txtSynopsis.Name = "txtSynopsis";
            this.txtSynopsis.Size = new System.Drawing.Size(218, 217);
            this.txtSynopsis.TabIndex = 29;
            this.txtSynopsis.Text = "";
            // 
            // pbPoster
            // 
            this.pbPoster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPoster.Location = new System.Drawing.Point(476, 70);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(218, 195);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 30;
            this.pbPoster.TabStop = false;
            this.pbPoster.Click += new System.EventHandler(this.pbPoster_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Synopsis";
            // 
            // btnDirectors
            // 
            this.btnDirectors.Location = new System.Drawing.Point(8, 502);
            this.btnDirectors.Name = "btnDirectors";
            this.btnDirectors.Size = new System.Drawing.Size(210, 29);
            this.btnDirectors.TabIndex = 32;
            this.btnDirectors.Text = "Add Directors";
            this.btnDirectors.UseVisualStyleBackColor = true;
            this.btnDirectors.Click += new System.EventHandler(this.btnDirectors_Click);
            // 
            // btnProducers
            // 
            this.btnProducers.Location = new System.Drawing.Point(241, 502);
            this.btnProducers.Name = "btnProducers";
            this.btnProducers.Size = new System.Drawing.Size(213, 28);
            this.btnProducers.TabIndex = 33;
            this.btnProducers.Text = "Add Producers";
            this.btnProducers.UseVisualStyleBackColor = true;
            this.btnProducers.Click += new System.EventHandler(this.btnProducers_Click);
            // 
            // btnEditActors
            // 
            this.btnEditActors.Location = new System.Drawing.Point(241, 330);
            this.btnEditActors.Name = "btnEditActors";
            this.btnEditActors.Size = new System.Drawing.Size(214, 29);
            this.btnEditActors.TabIndex = 34;
            this.btnEditActors.Text = "Add Actors";
            this.btnEditActors.UseVisualStyleBackColor = true;
            this.btnEditActors.Click += new System.EventHandler(this.btnEditActors_Click);
            // 
            // clbProducers
            // 
            this.clbProducers.CheckOnClick = true;
            this.clbProducers.FormattingEnabled = true;
            this.clbProducers.Location = new System.Drawing.Point(242, 404);
            this.clbProducers.Name = "clbProducers";
            this.clbProducers.Size = new System.Drawing.Size(213, 92);
            this.clbProducers.TabIndex = 35;
            // 
            // clbDirectors
            // 
            this.clbDirectors.CheckOnClick = true;
            this.clbDirectors.FormattingEnabled = true;
            this.clbDirectors.Location = new System.Drawing.Point(8, 404);
            this.clbDirectors.Name = "clbDirectors";
            this.clbDirectors.Size = new System.Drawing.Size(210, 92);
            this.clbDirectors.TabIndex = 36;
            this.clbDirectors.SelectedIndexChanged += new System.EventHandler(this.clbDirectors_SelectedIndexChanged);
            // 
            // clbWriters
            // 
            this.clbWriters.CheckOnClick = true;
            this.clbWriters.FormattingEnabled = true;
            this.clbWriters.Location = new System.Drawing.Point(242, 70);
            this.clbWriters.Name = "clbWriters";
            this.clbWriters.Size = new System.Drawing.Size(213, 92);
            this.clbWriters.TabIndex = 37;
            // 
            // clbActors
            // 
            this.clbActors.CheckOnClick = true;
            this.clbActors.FormattingEnabled = true;
            this.clbActors.Location = new System.Drawing.Point(242, 232);
            this.clbActors.Name = "clbActors";
            this.clbActors.Size = new System.Drawing.Size(213, 92);
            this.clbActors.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Producers";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Directors";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Writers";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 42;
            this.label10.Text = "Actors";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(476, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "Poster";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ofd";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // frmEditMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 546);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clbActors);
            this.Controls.Add(this.clbWriters);
            this.Controls.Add(this.clbDirectors);
            this.Controls.Add(this.clbProducers);
            this.Controls.Add(this.btnEditActors);
            this.Controls.Add(this.btnProducers);
            this.Controls.Add(this.btnDirectors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbPoster);
            this.Controls.Add(this.txtSynopsis);
            this.Controls.Add(this.clbGenres);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.btnEditWriters);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtYear);
            this.Name = "frmEditMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditMovie";
            this.Load += new System.EventHandler(this.frmEditMovie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtYear;
        private TextBox txtDuration;
        private Label label1;
        private ComboBox cmbCountry;
        private Button btnEditWriters;
        private Button Save;
        private Label label11;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTitle;
        private CheckedListBox clbGenres;
        private RichTextBox txtSynopsis;
        private PictureBox pbPoster;
        private Label label6;
        private Button btnDirectors;
        private Button btnProducers;
        private Button btnEditActors;
        private CheckedListBox clbProducers;
        private CheckedListBox clbDirectors;
        private CheckedListBox clbWriters;
        private CheckedListBox clbActors;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label12;
        private OpenFileDialog openFileDialog1;
        private ErrorProvider err;
    }
}