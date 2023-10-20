namespace chart
{
    partial class Form2
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
            this.L4 = new System.Windows.Forms.Button();
            this.L2 = new System.Windows.Forms.Button();
            this.L3 = new System.Windows.Forms.Button();
            this.L1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L4
            // 
            this.L4.Location = new System.Drawing.Point(204, 407);
            this.L4.Name = "L4";
            this.L4.Size = new System.Drawing.Size(393, 31);
            this.L4.TabIndex = 2;
            this.L4.Text = "Lab6";
            this.L4.UseVisualStyleBackColor = true;
            this.L4.Click += new System.EventHandler(this.L4_Click);
            // 
            // L2
            // 
            this.L2.Location = new System.Drawing.Point(204, 333);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(393, 31);
            this.L2.TabIndex = 3;
            this.L2.Text = "Lab2";
            this.L2.UseVisualStyleBackColor = true;
            this.L2.Click += new System.EventHandler(this.L2_Click);
            // 
            // L3
            // 
            this.L3.Location = new System.Drawing.Point(204, 370);
            this.L3.Name = "L3";
            this.L3.Size = new System.Drawing.Size(393, 31);
            this.L3.TabIndex = 4;
            this.L3.Text = "Lab5";
            this.L3.UseVisualStyleBackColor = true;
            this.L3.Click += new System.EventHandler(this.L3_Click);
            // 
            // L1
            // 
            this.L1.Location = new System.Drawing.Point(204, 296);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(393, 31);
            this.L1.TabIndex = 5;
            this.L1.Text = "Lab1";
            this.L1.UseVisualStyleBackColor = true;
            this.L1.Click += new System.EventHandler(this.L1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L1);
            this.Controls.Add(this.L3);
            this.Controls.Add(this.L2);
            this.Controls.Add(this.L4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button L4;
        private System.Windows.Forms.Button L2;
        private System.Windows.Forms.Button L3;
        private System.Windows.Forms.Button L1;
    }
}