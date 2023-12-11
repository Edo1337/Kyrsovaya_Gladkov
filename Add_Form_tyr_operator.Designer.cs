namespace Kyrsovaya_Gladkov
{
    partial class Add_Form_tyr_operator
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_country_operator1 = new System.Windows.Forms.TextBox();
            this.textBox_mail_operator1 = new System.Windows.Forms.TextBox();
            this.textBox_number_operator1 = new System.Windows.Forms.TextBox();
            this.textBox_name_operator1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Страна оператора:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Почта оператора:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Номер оператора:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Название оператора:";
            // 
            // textBox_country_operator1
            // 
            this.textBox_country_operator1.Location = new System.Drawing.Point(135, 104);
            this.textBox_country_operator1.Name = "textBox_country_operator1";
            this.textBox_country_operator1.Size = new System.Drawing.Size(100, 20);
            this.textBox_country_operator1.TabIndex = 15;
            // 
            // textBox_mail_operator1
            // 
            this.textBox_mail_operator1.Location = new System.Drawing.Point(135, 78);
            this.textBox_mail_operator1.Name = "textBox_mail_operator1";
            this.textBox_mail_operator1.Size = new System.Drawing.Size(100, 20);
            this.textBox_mail_operator1.TabIndex = 14;
            // 
            // textBox_number_operator1
            // 
            this.textBox_number_operator1.Location = new System.Drawing.Point(135, 52);
            this.textBox_number_operator1.Name = "textBox_number_operator1";
            this.textBox_number_operator1.Size = new System.Drawing.Size(100, 20);
            this.textBox_number_operator1.TabIndex = 13;
            // 
            // textBox_name_operator1
            // 
            this.textBox_name_operator1.Location = new System.Drawing.Point(135, 26);
            this.textBox_name_operator1.Name = "textBox_name_operator1";
            this.textBox_name_operator1.Size = new System.Drawing.Size(100, 20);
            this.textBox_name_operator1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 71);
            this.button1.TabIndex = 21;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Form_tyr_operator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 230);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_country_operator1);
            this.Controls.Add(this.textBox_mail_operator1);
            this.Controls.Add(this.textBox_number_operator1);
            this.Controls.Add(this.textBox_name_operator1);
            this.Name = "Add_Form_tyr_operator";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Add_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_country_operator1;
        private System.Windows.Forms.TextBox textBox_mail_operator1;
        private System.Windows.Forms.TextBox textBox_number_operator1;
        private System.Windows.Forms.TextBox textBox_name_operator1;
        private System.Windows.Forms.Button button1;
    }
}