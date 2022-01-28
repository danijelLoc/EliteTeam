
namespace EliteTeam.PresentationLayer
{
    partial class frmMatch
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
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.listMatchLog = new System.Windows.Forms.ListView();
            this.headerTime = new System.Windows.Forms.ColumnHeader();
            this.headerAction = new System.Windows.Forms.ColumnHeader();
            this.headerType = new System.Windows.Forms.ColumnHeader();
            this.txtMinutes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeconds = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHomeClubName
            // 
            this.txtHomeClubName.AutoSize = true;
            this.txtHomeClubName.Font = new System.Drawing.Font("Segoe UI", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHomeClubName.Location = new System.Drawing.Point(91, 82);
            this.txtHomeClubName.Name = "txtHomeClubName";
            this.txtHomeClubName.Size = new System.Drawing.Size(167, 30);
            this.txtHomeClubName.TabIndex = 0;
            this.txtHomeClubName.Text = "HomeClubName";
            // 
            // txtAwayClubName
            // 
            this.txtAwayClubName.Font = new System.Drawing.Font("Segoe UI", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAwayClubName.Location = new System.Drawing.Point(533, 82);
            this.txtAwayClubName.Name = "txtAwayClubName";
            this.txtAwayClubName.Size = new System.Drawing.Size(249, 30);
            this.txtAwayClubName.TabIndex = 1;
            this.txtAwayClubName.Text = "AwayClubName";
            this.txtAwayClubName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHomeGoals
            // 
            this.txtHomeGoals.AutoSize = true;
            this.txtHomeGoals.BackColor = System.Drawing.SystemColors.Control;
            this.txtHomeGoals.Font = new System.Drawing.Font("Segoe UI", 15.70909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHomeGoals.Location = new System.Drawing.Point(395, 80);
            this.txtHomeGoals.Name = "txtHomeGoals";
            this.txtHomeGoals.Size = new System.Drawing.Size(27, 32);
            this.txtHomeGoals.TabIndex = 2;
            this.txtHomeGoals.Text = "0";
            // 
            // txtAwayGoals
            // 
            this.txtAwayGoals.AutoSize = true;
            this.txtAwayGoals.BackColor = System.Drawing.SystemColors.Control;
            this.txtAwayGoals.Font = new System.Drawing.Font("Segoe UI", 15.70909F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAwayGoals.Location = new System.Drawing.Point(446, 80);
            this.txtAwayGoals.Name = "txtAwayGoals";
            this.txtAwayGoals.Size = new System.Drawing.Size(27, 32);
            this.txtAwayGoals.TabIndex = 3;
            this.txtAwayGoals.Text = "0";
            // 
            // scoreSeparator
            // 
            this.scoreSeparator.AutoSize = true;
            this.scoreSeparator.Location = new System.Drawing.Point(428, 85);
            this.scoreSeparator.Name = "scoreSeparator";
            this.scoreSeparator.Size = new System.Drawing.Size(12, 19);
            this.scoreSeparator.TabIndex = 4;
            this.scoreSeparator.Text = ":";
            // 
            // progressBarTime
            // 
            this.progressBarTime.BackColor = System.Drawing.Color.Silver;
            this.progressBarTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBarTime.Location = new System.Drawing.Point(91, 57);
            this.progressBarTime.Maximum = 90;
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(691, 10);
            this.progressBarTime.TabIndex = 5;
            // 
            // listMatchLog
            // 
            this.listMatchLog.BackColor = System.Drawing.Color.Gainsboro;
            this.listMatchLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listMatchLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerTime,
            this.headerAction,
            this.headerType});
            this.listMatchLog.HideSelection = false;
            this.listMatchLog.Location = new System.Drawing.Point(91, 170);
            this.listMatchLog.Name = "listMatchLog";
            this.listMatchLog.Size = new System.Drawing.Size(691, 346);
            this.listMatchLog.TabIndex = 8;
            this.listMatchLog.UseCompatibleStateImageBehavior = false;
            this.listMatchLog.View = System.Windows.Forms.View.Details;
            // 
            // headerTime
            // 
            this.headerTime.Text = "Time";
            // 
            // headerAction
            // 
            this.headerAction.Text = "Event Description";
            this.headerAction.Width = 490;
            // 
            // headerType
            // 
            this.headerType.Text = "Summary";
            this.headerType.Width = 120;
            // 
            // txtMinutes
            // 
            this.txtMinutes.AutoSize = true;
            this.txtMinutes.Font = new System.Drawing.Font("Segoe UI", 22.25455F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMinutes.Location = new System.Drawing.Point(373, 9);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(58, 47);
            this.txtMinutes.TabIndex = 9;
            this.txtMinutes.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18.32727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(424, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 38);
            this.label1.TabIndex = 10;
            this.label1.Text = ":";
            // 
            // txtSeconds
            // 
            this.txtSeconds.AutoSize = true;
            this.txtSeconds.Font = new System.Drawing.Font("Segoe UI", 22.25455F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSeconds.Location = new System.Drawing.Point(437, 9);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(58, 47);
            this.txtSeconds.TabIndex = 11;
            this.txtSeconds.Text = "00";
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(361, 128);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(86, 26);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(453, 128);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(86, 26);
            this.buttonResume.TabIndex = 13;
            this.buttonResume.Text = "Start";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // frmMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.listMatchLog);
            this.Controls.Add(this.progressBarTime);
            this.Controls.Add(this.scoreSeparator);
            this.Controls.Add(this.txtAwayGoals);
            this.Controls.Add(this.txtHomeGoals);
            this.Controls.Add(this.txtAwayClubName);
            this.Controls.Add(this.txtHomeClubName);
            this.Name = "frmMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMatch_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHomeClubName;
        private System.Windows.Forms.Label txtAwayClubName;
        private System.Windows.Forms.Label txtHomeGoals;
        private System.Windows.Forms.Label txtAwayGoals;
        private System.Windows.Forms.Label scoreSeparator;
        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.ListView listMatchLog;
        private System.Windows.Forms.Label txtMinutes;
        private System.Windows.Forms.ColumnHeader headerAction;
        private System.Windows.Forms.ColumnHeader headerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtSeconds;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.ColumnHeader headerTime;
    }
}