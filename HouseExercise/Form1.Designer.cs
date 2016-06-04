namespace HouseExercise
{
    partial class Form1
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
            this.goThroughTheDoor = new System.Windows.Forms.Button();
            this.goHere = new System.Windows.Forms.Button();
            this.exits = new System.Windows.Forms.ComboBox();
            this.description = new System.Windows.Forms.TextBox();
            this.check = new System.Windows.Forms.Button();
            this.goHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // goThroughTheDoor
            // 
            this.goThroughTheDoor.Location = new System.Drawing.Point(5, 230);
            this.goThroughTheDoor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goThroughTheDoor.Name = "goThroughTheDoor";
            this.goThroughTheDoor.Size = new System.Drawing.Size(368, 28);
            this.goThroughTheDoor.TabIndex = 1;
            this.goThroughTheDoor.Text = "Go through the door";
            this.goThroughTheDoor.UseVisualStyleBackColor = true;
            this.goThroughTheDoor.Click += new System.EventHandler(this.goThroughTheDoor_Click);
            // 
            // goHere
            // 
            this.goHere.Location = new System.Drawing.Point(5, 194);
            this.goHere.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goHere.Name = "goHere";
            this.goHere.Size = new System.Drawing.Size(100, 28);
            this.goHere.TabIndex = 2;
            this.goHere.Text = "Go here:";
            this.goHere.UseVisualStyleBackColor = true;
            this.goHere.Click += new System.EventHandler(this.goHere_Click);
            // 
            // exits
            // 
            this.exits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exits.FormattingEnabled = true;
            this.exits.Items.AddRange(new object[] {
            "kitchen"});
            this.exits.Location = new System.Drawing.Point(125, 197);
            this.exits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exits.Name = "exits";
            this.exits.Size = new System.Drawing.Size(248, 24);
            this.exits.TabIndex = 3;
            this.exits.SelectedIndexChanged += new System.EventHandler(this.exits_SelectedIndexChanged);
            // 
            // description
            // 
            this.description.Dock = System.Windows.Forms.DockStyle.Top;
            this.description.Location = new System.Drawing.Point(0, 0);
            this.description.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(379, 186);
            this.description.TabIndex = 4;
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(5, 265);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(368, 28);
            this.check.TabIndex = 5;
            this.check.Text = "check";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // goHide
            // 
            this.goHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goHide.Location = new System.Drawing.Point(101, 68);
            this.goHide.Name = "goHide";
            this.goHide.Size = new System.Drawing.Size(176, 51);
            this.goHide.TabIndex = 6;
            this.goHide.Text = "Go Hide!";
            this.goHide.UseVisualStyleBackColor = true;
            this.goHide.Click += new System.EventHandler(this.goHide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 302);
            this.Controls.Add(this.goHide);
            this.Controls.Add(this.check);
            this.Controls.Add(this.description);
            this.Controls.Add(this.exits);
            this.Controls.Add(this.goHere);
            this.Controls.Add(this.goThroughTheDoor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hide and Seek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button goThroughTheDoor;
        private System.Windows.Forms.Button goHere;
        private System.Windows.Forms.ComboBox exits;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button goHide;
    }
}

