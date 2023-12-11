namespace Kyrsovaya_Gladkov
{
    partial class Add_Form_dogovor
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
            this.textBox_fk_client_id1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox_fk_agenstvo_id1 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox_dogovor_name1 = new System.Windows.Forms.TextBox();
            this.textBox_data_nachala1 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox_data_konca1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox_price_of_tyr1 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_fk_client_id1
            // 
            this.textBox_fk_client_id1.Location = new System.Drawing.Point(129, 156);
            this.textBox_fk_client_id1.Name = "textBox_fk_client_id1";
            this.textBox_fk_client_id1.Size = new System.Drawing.Size(100, 20);
            this.textBox_fk_client_id1.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 66;
            this.label13.Text = "ID клиента:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(47, 138);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 13);
            this.label25.TabIndex = 65;
            this.label25.Text = "ID агентства:";
            // 
            // textBox_fk_agenstvo_id1
            // 
            this.textBox_fk_agenstvo_id1.Location = new System.Drawing.Point(129, 131);
            this.textBox_fk_agenstvo_id1.Name = "textBox_fk_agenstvo_id1";
            this.textBox_fk_agenstvo_id1.Size = new System.Drawing.Size(100, 20);
            this.textBox_fk_agenstvo_id1.TabIndex = 64;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(48, 60);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 13);
            this.label26.TabIndex = 61;
            this.label26.Text = "Дата начала:";
            // 
            // textBox_dogovor_name1
            // 
            this.textBox_dogovor_name1.Location = new System.Drawing.Point(129, 27);
            this.textBox_dogovor_name1.Name = "textBox_dogovor_name1";
            this.textBox_dogovor_name1.Size = new System.Drawing.Size(100, 20);
            this.textBox_dogovor_name1.TabIndex = 55;
            // 
            // textBox_data_nachala1
            // 
            this.textBox_data_nachala1.Location = new System.Drawing.Point(129, 53);
            this.textBox_data_nachala1.Name = "textBox_data_nachala1";
            this.textBox_data_nachala1.Size = new System.Drawing.Size(100, 20);
            this.textBox_data_nachala1.TabIndex = 56;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(61, 112);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 13);
            this.label27.TabIndex = 63;
            this.label27.Text = "Цена тура:";
            // 
            // textBox_data_konca1
            // 
            this.textBox_data_konca1.Location = new System.Drawing.Point(129, 79);
            this.textBox_data_konca1.Name = "textBox_data_konca1";
            this.textBox_data_konca1.Size = new System.Drawing.Size(100, 20);
            this.textBox_data_konca1.TabIndex = 57;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(53, 86);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 13);
            this.label28.TabIndex = 62;
            this.label28.Text = "Дата конца:";
            // 
            // textBox_price_of_tyr1
            // 
            this.textBox_price_of_tyr1.Location = new System.Drawing.Point(129, 105);
            this.textBox_price_of_tyr1.Name = "textBox_price_of_tyr1";
            this.textBox_price_of_tyr1.Size = new System.Drawing.Size(100, 20);
            this.textBox_price_of_tyr1.TabIndex = 58;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 34);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(110, 13);
            this.label30.TabIndex = 60;
            this.label30.Text = "Название договора:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 80);
            this.button1.TabIndex = 68;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Form_dogovor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 335);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_fk_client_id1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.textBox_fk_agenstvo_id1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.textBox_dogovor_name1);
            this.Controls.Add(this.textBox_data_nachala1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.textBox_data_konca1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBox_price_of_tyr1);
            this.Controls.Add(this.label30);
            this.Name = "Add_Form_dogovor";
            this.Text = "Add_Form_dogovor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_fk_client_id1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox_fk_agenstvo_id1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox_dogovor_name1;
        private System.Windows.Forms.TextBox textBox_data_nachala1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox_data_konca1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox_price_of_tyr1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button1;
    }
}