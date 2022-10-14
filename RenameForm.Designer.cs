
namespace MGRModLauncher
{
    partial class RenameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRename = new System.Windows.Forms.Label();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.buttonRenameContentExit = new System.Windows.Forms.Button();
            this.buttonSaveNewNameContent = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.labelRename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 40);
            this.panel1.TabIndex = 0;
            // 
            // labelRename
            // 
            this.labelRename.AutoSize = true;
            this.labelRename.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRename.ForeColor = System.Drawing.Color.White;
            this.labelRename.Location = new System.Drawing.Point(10, 3);
            this.labelRename.Name = "labelRename";
            this.labelRename.Size = new System.Drawing.Size(279, 33);
            this.labelRename.TabIndex = 0;
            this.labelRename.Text = "R e n a m e  T h e  M o d";
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(68)))));
            this.textBoxNewName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNewName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNewName.ForeColor = System.Drawing.Color.White;
            this.textBoxNewName.Location = new System.Drawing.Point(12, 46);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(277, 22);
            this.textBoxNewName.TabIndex = 1;
            // 
            // buttonRenameContentExit
            // 
            this.buttonRenameContentExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRenameContentExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(120)))));
            this.buttonRenameContentExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRenameContentExit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRenameContentExit.ForeColor = System.Drawing.Color.White;
            this.buttonRenameContentExit.Location = new System.Drawing.Point(0, 120);
            this.buttonRenameContentExit.Name = "buttonRenameContentExit";
            this.buttonRenameContentExit.Size = new System.Drawing.Size(300, 30);
            this.buttonRenameContentExit.TabIndex = 2;
            this.buttonRenameContentExit.Text = "E x i t";
            this.buttonRenameContentExit.UseVisualStyleBackColor = true;
            this.buttonRenameContentExit.Click += new System.EventHandler(this.buttonRenameContentExit_Click);
            // 
            // buttonSaveNewNameContent
            // 
            this.buttonSaveNewNameContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSaveNewNameContent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(120)))));
            this.buttonSaveNewNameContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveNewNameContent.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveNewNameContent.ForeColor = System.Drawing.Color.White;
            this.buttonSaveNewNameContent.Location = new System.Drawing.Point(0, 90);
            this.buttonSaveNewNameContent.Name = "buttonSaveNewNameContent";
            this.buttonSaveNewNameContent.Size = new System.Drawing.Size(300, 30);
            this.buttonSaveNewNameContent.TabIndex = 3;
            this.buttonSaveNewNameContent.Text = "S a v e";
            this.buttonSaveNewNameContent.UseVisualStyleBackColor = true;
            this.buttonSaveNewNameContent.Click += new System.EventHandler(this.buttonSaveNewNameContent_Click);
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.buttonSaveNewNameContent);
            this.Controls.Add(this.buttonRenameContentExit);
            this.Controls.Add(this.textBoxNewName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RenameForm";
            this.Text = "RenameForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelRename;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.Button buttonRenameContentExit;
        private System.Windows.Forms.Button buttonSaveNewNameContent;
    }
}