
namespace MGRModLauncher
{
    partial class ModMenuModContent
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
            this.ModViewIndicator = new System.Windows.Forms.Panel();
            this.ModContextText = new System.Windows.Forms.Label();
            this.ModViewIndicator.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModViewIndicator
            // 
            this.ModViewIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(98)))));
            this.ModViewIndicator.Controls.Add(this.ModContextText);
            this.ModViewIndicator.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModViewIndicator.Location = new System.Drawing.Point(0, 0);
            this.ModViewIndicator.Name = "ModViewIndicator";
            this.ModViewIndicator.Size = new System.Drawing.Size(330, 30);
            this.ModViewIndicator.TabIndex = 0;
            this.ModViewIndicator.Click += new System.EventHandler(this.ModViewIndicator_Click);
            // 
            // ModContextText
            // 
            this.ModContextText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ModContextText.AutoSize = true;
            this.ModContextText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModContextText.ForeColor = System.Drawing.Color.White;
            this.ModContextText.Location = new System.Drawing.Point(3, 3);
            this.ModContextText.Name = "ModContextText";
            this.ModContextText.Size = new System.Drawing.Size(118, 24);
            this.ModContextText.TabIndex = 0;
            this.ModContextText.Text = "MODNAME";
            this.ModContextText.Click += new System.EventHandler(this.ModContextText_Click);
            // 
            // ModMenuModContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(330, 50);
            this.Controls.Add(this.ModViewIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModMenuModContent";
            this.Tag = "";
            this.Text = "ModMenuModContent";
            this.ModViewIndicator.ResumeLayout(false);
            this.ModViewIndicator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ModViewIndicator;
        private System.Windows.Forms.Label ModContextText;
    }
}