namespace InfoProtection_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valueToEncryptBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.columnNumberBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.repeatNumberBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.encryptButton = new System.Windows.Forms.Button();
            this.encryptedValueBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Престановочний Шифр, КІ - 43, Кіндій Василь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Повідомлення для шифрування:";
            // 
            // valueToEncryptBox
            // 
            this.valueToEncryptBox.Location = new System.Drawing.Point(17, 65);
            this.valueToEncryptBox.Name = "valueToEncryptBox";
            this.valueToEncryptBox.Size = new System.Drawing.Size(513, 20);
            this.valueToEncryptBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Кількість стовпців:";
            // 
            // columnNumberBox
            // 
            this.columnNumberBox.Location = new System.Drawing.Point(17, 109);
            this.columnNumberBox.Name = "columnNumberBox";
            this.columnNumberBox.Size = new System.Drawing.Size(166, 20);
            this.columnNumberBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ключ:";
            // 
            // keyBox
            // 
            this.keyBox.Location = new System.Drawing.Point(189, 109);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(166, 20);
            this.keyBox.TabIndex = 6;
            // 
            // repeatNumberBox
            // 
            this.repeatNumberBox.Enabled = false;
            this.repeatNumberBox.Location = new System.Drawing.Point(364, 109);
            this.repeatNumberBox.Name = "repeatNumberBox";
            this.repeatNumberBox.Size = new System.Drawing.Size(166, 20);
            this.repeatNumberBox.TabIndex = 7;
            this.repeatNumberBox.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Кількість разів:";
            // 
            // encryptButton
            // 
            this.encryptButton.ForeColor = System.Drawing.Color.Black;
            this.encryptButton.Location = new System.Drawing.Point(17, 136);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(166, 35);
            this.encryptButton.TabIndex = 9;
            this.encryptButton.Text = "Обробити";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.encryptButton_MouseClick);
            // 
            // encryptedValueBox
            // 
            this.encryptedValueBox.Enabled = false;
            this.encryptedValueBox.Location = new System.Drawing.Point(17, 194);
            this.encryptedValueBox.Name = "encryptedValueBox";
            this.encryptedValueBox.Size = new System.Drawing.Size(513, 20);
            this.encryptedValueBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Зашифроване повідомлення:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(546, 234);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.encryptedValueBox);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.repeatNumberBox);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.columnNumberBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.valueToEncryptBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox valueToEncryptBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox columnNumberBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.TextBox repeatNumberBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.TextBox encryptedValueBox;
        private System.Windows.Forms.Label label6;
    }
}

