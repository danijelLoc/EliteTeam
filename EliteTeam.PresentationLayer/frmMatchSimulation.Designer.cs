
namespace EliteTeam.PresentationLayer
{
    partial class frmMatchSimulation
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
            this.txtHomeClubName = new System.Windows.Forms.Label();
            this.txtAwayClubName = new System.Windows.Forms.Label();
            this.txtHomeGoals = new System.Windows.Forms.Label();
            this.txtAwayGoals = new System.Windows.Forms.Label();
            this.scoreSeparator = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listGoalsBoxHome = new System.Windows.Forms.ListBox();
            this.listGoalsBoxAway = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtHomeClubName
            // 
            this.txtHomeClubName.AutoSize = true;
            this.txtHomeClubName.Font = new System.Drawing.Font("Segoe UI", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHomeClubName.Location = new System.Drawing.Point(165, 55);
            this.txtHomeClubName.Name = "txtHomeClubName";
            this.txtHomeClubName.Size = new System.Drawing.Size(167, 30);
            this.txtHomeClubName.TabIndex = 0;
            this.txtHomeClubName.Text = "HomeClubName";
            // 
            // txtAwayClubName
            // 
            this.txtAwayClubName.AutoSize = true;
            this.txtAwayClubName.Font = new System.Drawing.Font("Segoe UI", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAwayClubName.Location = new System.Drawing.Point(539, 55);
            this.txtAwayClubName.Name = "txtAwayClubName";
            this.txtAwayClubName.Size = new System.Drawing.Size(161, 30);
            this.txtAwayClubName.TabIndex = 1;
            this.txtAwayClubName.Text = "AwayClubName";
            // 
            // txtHomeGoals
            // 
            this.txtHomeGoals.AutoSize = true;
            this.txtHomeGoals.BackColor = System.Drawing.SystemColors.Control;
            this.txtHomeGoals.Font = new System.Drawing.Font("Segoe UI", 22.25455F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHomeGoals.Location = new System.Drawing.Point(378, 49);
            this.txtHomeGoals.Name = "txtHomeGoals";
            this.txtHomeGoals.Size = new System.Drawing.Size(38, 46);
            this.txtHomeGoals.TabIndex = 2;
            this.txtHomeGoals.Text = "0";
            // 
            // txtAwayGoals
            // 
            this.txtAwayGoals.AutoSize = true;
            this.txtAwayGoals.BackColor = System.Drawing.SystemColors.Control;
            this.txtAwayGoals.Font = new System.Drawing.Font("Segoe UI", 22.25455F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAwayGoals.Location = new System.Drawing.Point(466, 49);
            this.txtAwayGoals.Name = "txtAwayGoals";
            this.txtAwayGoals.Size = new System.Drawing.Size(38, 46);
            this.txtAwayGoals.TabIndex = 3;
            this.txtAwayGoals.Text = "0";
            // 
            // scoreSeparator
            // 
            this.scoreSeparator.AutoSize = true;
            this.scoreSeparator.Location = new System.Drawing.Point(432, 64);
            this.scoreSeparator.Name = "scoreSeparator";
            this.scoreSeparator.Size = new System.Drawing.Size(12, 19);
            this.scoreSeparator.TabIndex = 4;
            this.scoreSeparator.Text = ":";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(81, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(691, 11);
            this.progressBar1.TabIndex = 5;
            // 
            // listGoalsBoxHome
            // 
            this.listGoalsBoxHome.BackColor = System.Drawing.SystemColors.Control;
            this.listGoalsBoxHome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listGoalsBoxHome.FormattingEnabled = true;
            this.listGoalsBoxHome.ItemHeight = 19;
            this.listGoalsBoxHome.Location = new System.Drawing.Point(165, 98);
            this.listGoalsBoxHome.Name = "listGoalsBoxHome";
            this.listGoalsBoxHome.Size = new System.Drawing.Size(223, 57);
            this.listGoalsBoxHome.TabIndex = 6;
            // 
            // listGoalsBoxAway
            // 
            this.listGoalsBoxAway.BackColor = System.Drawing.SystemColors.Control;
            this.listGoalsBoxAway.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listGoalsBoxAway.FormattingEnabled = true;
            this.listGoalsBoxAway.ItemHeight = 19;
            this.listGoalsBoxAway.Location = new System.Drawing.Point(539, 98);
            this.listGoalsBoxAway.Name = "listGoalsBoxAway";
            this.listGoalsBoxAway.Size = new System.Drawing.Size(223, 57);
            this.listGoalsBoxAway.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Beige;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(165, 136);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(535, 341);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmMatchSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listGoalsBoxAway);
            this.Controls.Add(this.listGoalsBoxHome);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.scoreSeparator);
            this.Controls.Add(this.txtAwayGoals);
            this.Controls.Add(this.txtHomeGoals);
            this.Controls.Add(this.txtAwayClubName);
            this.Controls.Add(this.txtHomeClubName);
            this.Name = "frmMatchSimulation";
            this.Text = "Match";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHomeClubName;
        private System.Windows.Forms.Label txtAwayClubName;
        private System.Windows.Forms.Label txtHomeGoals;
        private System.Windows.Forms.Label txtAwayGoals;
        private System.Windows.Forms.Label scoreSeparator;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listGoalsBoxHome;
        private System.Windows.Forms.ListBox listGoalsBoxAway;
        private System.Windows.Forms.ListView listView1;
    }
}