
namespace EliteTeam.PresentationLayer
{
    partial class frmPlayersList
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
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.Player_Name = new System.Windows.Forms.ColumnHeader();
            this.Position = new System.Windows.Forms.ColumnHeader();
            this.Age = new System.Windows.Forms.ColumnHeader();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Player_Name,
            this.Position,
            this.Age});
            this.listViewPlayers.HideSelection = false;
            this.listViewPlayers.Location = new System.Drawing.Point(12, 12);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(776, 380);
            this.listViewPlayers.TabIndex = 0;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.Details;
            this.listViewPlayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewPlayers_MouseDoubleClick);
            // 
            // Player_Name
            // 
            this.Player_Name.Tag = "";
            this.Player_Name.Text = "Name";
            this.Player_Name.Width = 200;
            // 
            // Position
            // 
            this.Position.Text = "Postition";
            this.Position.Width = 150;
            // 
            // Age
            // 
            this.Age.Text = "Age";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(524, 398);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(264, 40);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add player";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "* Double click on name to edit player";
            // 
            // frmPlayersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listViewPlayers);
            this.MaximizeBox = false;
            this.Name = "frmPlayersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Players List";
            this.Load += new System.EventHandler(this.PlayersList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPlayers;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ColumnHeader Player_Name;
        private System.Windows.Forms.ColumnHeader Position;
        private System.Windows.Forms.ColumnHeader Age;
        private System.Windows.Forms.Label label1;
    }
}