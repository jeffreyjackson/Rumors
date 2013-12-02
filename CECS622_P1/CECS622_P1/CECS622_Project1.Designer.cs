namespace CECS622_P1
{
    partial class frmProject1
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
            this.txtNumStudents = new System.Windows.Forms.TextBox();
            this.lblNumStudents = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNumStudents
            // 
            this.txtNumStudents.Location = new System.Drawing.Point(117, 9);
            this.txtNumStudents.Name = "txtNumStudents";
            this.txtNumStudents.Size = new System.Drawing.Size(88, 20);
            this.txtNumStudents.TabIndex = 0;
            // 
            // lblNumStudents
            // 
            this.lblNumStudents.AutoSize = true;
            this.lblNumStudents.Location = new System.Drawing.Point(40, 12);
            this.lblNumStudents.Name = "lblNumStudents";
            this.lblNumStudents.Size = new System.Drawing.Size(71, 13);
            this.lblNumStudents.TabIndex = 1;
            this.lblNumStudents.Text = "# of Students";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(117, 35);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(88, 31);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // frmProject1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 76);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblNumStudents);
            this.Controls.Add(this.txtNumStudents);
            this.Name = "frmProject1";
            this.Text = "Project 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumStudents;
        private System.Windows.Forms.Label lblNumStudents;
        private System.Windows.Forms.Button btnExecute;
    }
}

