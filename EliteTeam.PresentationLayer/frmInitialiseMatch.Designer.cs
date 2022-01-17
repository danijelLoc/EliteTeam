
namespace EliteTeam.PresentationLayer
{
    partial class frmInitialiseMatch
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
            this.comboBoxHome = new System.Windows.Forms.ComboBox();
            this.comboBoxAway = new System.Windows.Forms.ComboBox();
            this.pictureBoxHome = new System.Windows.Forms.PictureBox();
            this.pictureBoxAway = new System.Windows.Forms.PictureBox();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAway)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxHome
            // 
            this.comboBoxHome.FormattingEnabled = true;
            this.comboBoxHome.Location = new System.Drawing.Point(139, 296);
            this.comboBoxHome.Name = "comboBoxHome";
            this.comboBoxHome.Size = new System.Drawing.Size(195, 27);
            this.comboBoxHome.TabIndex = 0;
            // 
            // comboBoxAway
            // 
            this.comboBoxAway.FormattingEnabled = true;
            this.comboBoxAway.Location = new System.Drawing.Point(458, 296);
            this.comboBoxAway.Name = "comboBoxAway";
            this.comboBoxAway.Size = new System.Drawing.Size(195, 27);
            this.comboBoxAway.TabIndex = 1;
            // 
            // pictureBoxHome
            // 
            this.pictureBoxHome.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxHome.Location = new System.Drawing.Point(139, 56);
            this.pictureBoxHome.Name = "pictureBoxHome";
            this.pictureBoxHome.Size = new System.Drawing.Size(195, 196);
            this.pictureBoxHome.TabIndex = 2;
            this.pictureBoxHome.TabStop = false;
            // 
            // pictureBoxAway
            // 
            this.pictureBoxAway.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxAway.Location = new System.Drawing.Point(458, 56);
            this.pictureBoxAway.Name = "pictureBoxAway";
            this.pictureBoxAway.Size = new System.Drawing.Size(195, 196);
            this.pictureBoxAway.TabIndex = 3;
            this.pictureBoxAway.TabStop = false;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(139, 355);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(514, 49);
            this.buttonSimulate.TabIndex = 4;
            this.buttonSimulate.Text = "Simulate Match";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "VS";
            // 
            // frmInitialiseMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.pictureBoxAway);
            this.Controls.Add(this.pictureBoxHome);
            this.Controls.Add(this.comboBoxAway);
            this.Controls.Add(this.comboBoxHome);
            this.Name = "frmInitialiseMatch";
            this.Text = "InitialiseMatch";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAway)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHome;
        private System.Windows.Forms.ComboBox comboBoxAway;
        private System.Windows.Forms.PictureBox pictureBoxHome;
        private System.Windows.Forms.PictureBox pictureBoxAway;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label label1;
    }
}