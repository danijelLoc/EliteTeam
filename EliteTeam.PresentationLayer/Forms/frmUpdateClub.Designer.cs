
namespace EliteTeam.PresentationLayer
{
    partial class frmUpdateClub
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
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewSquadPlayers = new System.Windows.Forms.ListView();
            this.Player_Name = new System.Windows.Forms.ColumnHeader();
            this.Position = new System.Windows.Forms.ColumnHeader();
            this.Age = new System.Windows.Forms.ColumnHeader();
            this.listViewFreePlayers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(57, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "ShortName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Manager";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 101);
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
            this.textBoxShortName.Location = new System.Drawing.Point(166, 98);
            this.textBoxShortName.Name = "textBoxShortName";
            this.textBoxShortName.Size = new System.Drawing.Size(65, 26);
            this.textBoxShortName.TabIndex = 5;
            // 
            // textBoxManager
            // 
            this.textBoxManager.Location = new System.Drawing.Point(500, 63);
            this.textBoxManager.Name = "textBoxManager";
            this.textBoxManager.Size = new System.Drawing.Size(215, 26);
            this.textBoxManager.TabIndex = 6;
            // 
            // comboBoxTactic
            // 
            this.comboBoxTactic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTactic.FormattingEnabled = true;
            this.comboBoxTactic.Location = new System.Drawing.Point(500, 101);
            this.comboBoxTactic.Name = "comboBoxTactic";
            this.comboBoxTactic.Size = new System.Drawing.Size(215, 27);
            this.comboBoxTactic.TabIndex = 7;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpdate.Location = new System.Drawing.Point(514, 633);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(213, 35);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Update Club";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(353, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "* Double click on player to remove him from club squad.";
            // 
            // listViewSquadPlayers
            // 
            this.listViewSquadPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Player_Name,
            this.Position,
            this.Age});
            this.listViewSquadPlayers.HideSelection = false;
            this.listViewSquadPlayers.Location = new System.Drawing.Point(57, 184);
            this.listViewSquadPlayers.Name = "listViewSquadPlayers";
            this.listViewSquadPlayers.Size = new System.Drawing.Size(658, 144);
            this.listViewSquadPlayers.TabIndex = 14;
            this.listViewSquadPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewSquadPlayers.View = System.Windows.Forms.View.Details;
            this.listViewSquadPlayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSquadPlayers_MouseDoubleClick);
            // 
            // Player_Name
            // 
            this.Player_Name.Tag = "";
            this.Player_Name.Text = "Name";
            this.Player_Name.Width = 400;
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
            // listViewFreePlayers
            // 
            this.listViewFreePlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewFreePlayers.HideSelection = false;
            this.listViewFreePlayers.Location = new System.Drawing.Point(57, 402);
            this.listViewFreePlayers.Name = "listViewFreePlayers";
            this.listViewFreePlayers.Size = new System.Drawing.Size(670, 175);
            this.listViewFreePlayers.TabIndex = 15;
            this.listViewFreePlayers.UseCompatibleStateImageBehavior = false;
            this.listViewFreePlayers.View = System.Windows.Forms.View.Details;
            this.listViewFreePlayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewFreePlayers_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Postition";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Age";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Club Squad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Free Agent Players:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 580);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(285, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "* Double click on player to add him to squad.";
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.DarkRed;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDelete.Location = new System.Drawing.Point(363, 633);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(145, 35);
            this.buttonDelete.TabIndex = 19;
            this.buttonDelete.Text = "Delete Club";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // frmUpdateClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 680);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listViewFreePlayers);
            this.Controls.Add(this.listViewSquadPlayers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxTactic);
            this.Controls.Add(this.textBoxManager);
            this.Controls.Add(this.textBoxShortName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateClub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Club Creator";
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
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewSquadPlayers;
        private System.Windows.Forms.ColumnHeader Player_Name;
        private System.Windows.Forms.ColumnHeader Position;
        private System.Windows.Forms.ColumnHeader Age;
        private System.Windows.Forms.ListView listViewFreePlayers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDelete;
    }
}