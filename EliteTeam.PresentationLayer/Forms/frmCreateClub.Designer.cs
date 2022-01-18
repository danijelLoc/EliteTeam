
namespace EliteTeam.PresentationLayer
{
    partial class frmCreateClub
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxShortName = new System.Windows.Forms.TextBox();
            this.textBoxManager = new System.Windows.Forms.TextBox();
            this.comboBoxTactic = new System.Windows.Forms.ComboBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonLogo = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "ShortName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Manager";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tactic";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(166, 66);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(215, 26);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxShortName
            // 
            this.textBoxShortName.Location = new System.Drawing.Point(166, 102);
            this.textBoxShortName.Name = "textBoxShortName";
            this.textBoxShortName.Size = new System.Drawing.Size(115, 26);
            this.textBoxShortName.TabIndex = 5;
            // 
            // textBoxManager
            // 
            this.textBoxManager.Location = new System.Drawing.Point(166, 136);
            this.textBoxManager.Name = "textBoxManager";
            this.textBoxManager.Size = new System.Drawing.Size(215, 26);
            this.textBoxManager.TabIndex = 6;
            // 
            // comboBoxTactic
            // 
            this.comboBoxTactic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTactic.FormattingEnabled = true;
            this.comboBoxTactic.Location = new System.Drawing.Point(166, 218);
            this.comboBoxTactic.Name = "comboBoxTactic";
            this.comboBoxTactic.Size = new System.Drawing.Size(215, 27);
            this.comboBoxTactic.TabIndex = 7;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxLogo.Location = new System.Drawing.Point(487, 44);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(213, 201);
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonLogo
            // 
            this.buttonLogo.Location = new System.Drawing.Point(487, 251);
            this.buttonLogo.Name = "buttonLogo";
            this.buttonLogo.Size = new System.Drawing.Size(213, 26);
            this.buttonLogo.TabIndex = 9;
            this.buttonLogo.Text = "Select Logo";
            this.buttonLogo.UseVisualStyleBackColor = true;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(487, 345);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(213, 47);
            this.buttonCreate.TabIndex = 10;
            this.buttonCreate.Text = "Create Club";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // frmCreateClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 420);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonLogo);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.comboBoxTactic);
            this.Controls.Add(this.textBoxManager);
            this.Controls.Add(this.textBoxShortName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCreateClub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Club Creator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxShortName;
        private System.Windows.Forms.TextBox textBoxManager;
        private System.Windows.Forms.ComboBox comboBoxTactic;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonLogo;
        private System.Windows.Forms.Button buttonCreate;
    }
}