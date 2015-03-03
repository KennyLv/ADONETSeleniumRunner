namespace PPLTestMonitor
{
    partial class AddState
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
            this.AddState_txt_stateName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddState_but_OK = new System.Windows.Forms.Button();
            this.AddState_but_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddState_txt_stateName
            // 
            this.AddState_txt_stateName.Location = new System.Drawing.Point(106, 12);
            this.AddState_txt_stateName.Name = "AddState_txt_stateName";
            this.AddState_txt_stateName.Size = new System.Drawing.Size(216, 22);
            this.AddState_txt_stateName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "State Name:";
            // 
            // AddState_but_OK
            // 
            this.AddState_but_OK.Location = new System.Drawing.Point(88, 47);
            this.AddState_but_OK.Name = "AddState_but_OK";
            this.AddState_but_OK.Size = new System.Drawing.Size(114, 45);
            this.AddState_but_OK.TabIndex = 2;
            this.AddState_but_OK.Text = "OK";
            this.AddState_but_OK.UseVisualStyleBackColor = true;
            this.AddState_but_OK.Click += new System.EventHandler(this.AddState_but_OK_Click);
            // 
            // AddState_but_Cancel
            // 
            this.AddState_but_Cancel.Location = new System.Drawing.Point(208, 47);
            this.AddState_but_Cancel.Name = "AddState_but_Cancel";
            this.AddState_but_Cancel.Size = new System.Drawing.Size(114, 45);
            this.AddState_but_Cancel.TabIndex = 3;
            this.AddState_but_Cancel.Text = "Cancel";
            this.AddState_but_Cancel.UseVisualStyleBackColor = true;
            this.AddState_but_Cancel.Click += new System.EventHandler(this.AddState_but_Cancel_Click);
            // 
            // AddState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 104);
            this.Controls.Add(this.AddState_but_Cancel);
            this.Controls.Add(this.AddState_but_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddState_txt_stateName);
            this.Name = "AddState";
            this.Text = "AddState";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddState_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddState_txt_stateName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddState_but_OK;
        private System.Windows.Forms.Button AddState_but_Cancel;
    }
}