﻿namespace NubeFactJson
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.cmdProbar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdProbar
            // 
            this.cmdProbar.Location = new System.Drawing.Point(12, 12);
            this.cmdProbar.Name = "cmdProbar";
            this.cmdProbar.Size = new System.Drawing.Size(120, 25);
            this.cmdProbar.TabIndex = 0;
            this.cmdProbar.Text = "Probar Conexión";
            this.cmdProbar.UseVisualStyleBackColor = true;
            this.cmdProbar.Click += new System.EventHandler(this.cmdProbar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cmdProbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdProbar;
    }
}