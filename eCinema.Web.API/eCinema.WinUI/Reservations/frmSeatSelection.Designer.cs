namespace eCinema.WinUI.Reservations
{
    partial class frmSeatSelection
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
            this.label1 = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnFree = new System.Windows.Forms.Button();
            this.btnTaken = new System.Windows.Forms.Button();
            this.lblFree = new System.Windows.Forms.Label();
            this.lblTaken = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pick seats";
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // btnFree
            // 
            this.btnFree.BackColor = System.Drawing.Color.Yellow;
            this.btnFree.Location = new System.Drawing.Point(258, 22);
            this.btnFree.Name = "btnFree";
            this.btnFree.Size = new System.Drawing.Size(25, 22);
            this.btnFree.TabIndex = 4;
            this.btnFree.UseVisualStyleBackColor = false;
            // 
            // btnTaken
            // 
            this.btnTaken.BackColor = System.Drawing.Color.LightGray;
            this.btnTaken.Location = new System.Drawing.Point(387, 24);
            this.btnTaken.Name = "btnTaken";
            this.btnTaken.Size = new System.Drawing.Size(25, 22);
            this.btnTaken.TabIndex = 5;
            this.btnTaken.UseVisualStyleBackColor = false;
            // 
            // lblFree
            // 
            this.lblFree.AutoSize = true;
            this.lblFree.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFree.Location = new System.Drawing.Point(293, 30);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(76, 20);
            this.lblFree.TabIndex = 6;
            this.lblFree.Text = "Free seats";
            // 
            // lblTaken
            // 
            this.lblTaken.AutoSize = true;
            this.lblTaken.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTaken.Location = new System.Drawing.Point(422, 27);
            this.lblTaken.Name = "lblTaken";
            this.lblTaken.Size = new System.Drawing.Size(86, 20);
            this.lblTaken.TabIndex = 7;
            this.lblTaken.Text = "Taken seats";
            // 
            // frmSeatSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(925, 455);
            this.Controls.Add(this.lblTaken);
            this.Controls.Add(this.lblFree);
            this.Controls.Add(this.btnTaken);
            this.Controls.Add(this.btnFree);
            this.Controls.Add(this.label1);
            this.Name = "frmSeatSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeatSelection";
            this.Load += new System.EventHandler(this.frmSeatSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private ErrorProvider err;
        private Label lblTaken;
        private Label lblFree;
        private Button btnTaken;
        private Button btnFree;
    }
}