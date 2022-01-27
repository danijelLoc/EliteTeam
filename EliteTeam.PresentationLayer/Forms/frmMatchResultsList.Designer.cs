
namespace EliteTeam.PresentationLayer
{
    partial class frmMatchResultsList
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.homeClub = new System.Windows.Forms.ColumnHeader();
            this.homeClubGoals = new System.Windows.Forms.ColumnHeader();
            this.awayClubGoals = new System.Windows.Forms.ColumnHeader();
            this.awayClub = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.homeClub,
            this.homeClubGoals,
            this.awayClubGoals,
            this.awayClub});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // homeClub
            // 
            this.homeClub.Text = "Home Club";
            this.homeClub.Width = 250;
            // 
            // homeClubGoals
            // 
            this.homeClubGoals.Text = "Home Goals";
            this.homeClubGoals.Width = 100;
            // 
            // awayClubGoals
            // 
            this.awayClubGoals.Text = "Away Goals";
            this.awayClubGoals.Width = 100;
            // 
            // awayClub
            // 
            this.awayClub.Text = "Away Club";
            this.awayClub.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.awayClub.Width = 250;
            // 
            // frmMatchResultsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Name = "frmMatchResultsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Results History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader homeClub;
        private System.Windows.Forms.ColumnHeader awayClub;
        private System.Windows.Forms.ColumnHeader homeClubGoals;
        private System.Windows.Forms.ColumnHeader awayClubGoals;
    }
}