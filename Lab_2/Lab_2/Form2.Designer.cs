namespace Lab_2
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.grpCase = new System.Windows.Forms.GroupBox();
            this.radUpperCase = new System.Windows.Forms.RadioButton();
            this.radLowerCase = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpCase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(24, 24);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(107, 15);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Nhập họ và tên:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(137, 23);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(236, 20);
            this.txtInput.TabIndex = 1;
            // 
            // grpCase
            // 
            this.grpCase.Controls.Add(this.radUpperCase);
            this.grpCase.Controls.Add(this.radLowerCase);
            this.grpCase.Location = new System.Drawing.Point(27, 61);
            this.grpCase.Name = "grpCase";
            this.grpCase.Size = new System.Drawing.Size(322, 67);
            this.grpCase.TabIndex = 2;
            this.grpCase.TabStop = false;
            this.grpCase.Text = "Chọn kiểu chữ";
            // 
            // radUpperCase
            // 
            this.radUpperCase.AutoSize = true;
            this.radUpperCase.Location = new System.Drawing.Point(6, 42);
            this.radUpperCase.Name = "radUpperCase";
            this.radUpperCase.Size = new System.Drawing.Size(88, 17);
            this.radUpperCase.TabIndex = 1;
            this.radUpperCase.Text = "CHỮ IN HOA";
            this.radUpperCase.UseVisualStyleBackColor = true;
            // 
            // radLowerCase
            // 
            this.radLowerCase.AutoSize = true;
            this.radLowerCase.Checked = true;
            this.radLowerCase.Location = new System.Drawing.Point(6, 19);
            this.radLowerCase.Name = "radLowerCase";
            this.radLowerCase.Size = new System.Drawing.Size(79, 17);
            this.radLowerCase.TabIndex = 0;
            this.radLowerCase.TabStop = true;
            this.radLowerCase.Text = "chữ thường";
            this.radLowerCase.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(355, 61);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(49, 67);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(22, 143);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(110, 31);
            this.btnResult.TabIndex = 4;
            this.btnResult.Text = "Kết quả";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Location = new System.Drawing.Point(137, 149);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(266, 20);
            this.txtOutput.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 201);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpCase);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi kiểu chữ";
            this.grpCase.ResumeLayout(false);
            this.grpCase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.GroupBox grpCase;
        private System.Windows.Forms.RadioButton radUpperCase;
        private System.Windows.Forms.RadioButton radLowerCase;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.TextBox txtOutput;
    }
}