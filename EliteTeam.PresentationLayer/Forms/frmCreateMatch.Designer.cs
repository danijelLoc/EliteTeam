
namespace EliteTeam.PresentationLayer
{
    partial class frmCreateMatch
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
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxHome
            // 
            this.comboBoxHome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHome.FormattingEnabled = true;
            this.comboBoxHome.Location = new System.Drawing.Point(140, 160);
            this.comboBoxHome.Name = "comboBoxHome";
            this.comboBoxHome.Size = new System.Drawing.Size(195, 27);
            this.comboBoxHome.TabIndex = 0;
            // 
            // comboBoxAway
            // 
            this.comboBoxAway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAway.FormattingEnabled = true;
            this.comboBoxAway.Location = new System.Drawing.Point(459, 160);
            this.comboBoxAway.Name = "comboBoxAway";
            this.comboBoxAway.Size = new System.Drawing.Size(195, 27);
            this.comboBoxAway.TabIndex = 1;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(140, 219);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(514, 49);
            this.buttonSimulate.TabIndex = 4;
            this.buttonSimulate.Text = "Simulate Match";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "VS";
            // 
            // frmCreateMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.comboBoxAway);
            this.Controls.Add(this.comboBoxHome);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.Name = "frmCreateMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Match";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHome;
        private System.Windows.Forms.ComboBox comboBoxAway;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label label1;
    }
}