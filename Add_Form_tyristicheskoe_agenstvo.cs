using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kyrsovaya_Gladkov
{
    public partial class Add_Form_tyristicheskoe_agenstvo : Form
    {
        DataBase database = new DataBase();
        public Add_Form_tyristicheskoe_agenstvo()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();


            long agenstvo_number;
            var agenstvo_email = textBox_agenstvo_email1.Text;
            var agenstvo_name = textBox_agenstvo_name1.Text;
            var agenstvo_country = textBox_agenstvo_country1.Text;

            if (long.TryParse(textBox_agenstvo_number1.Text, out agenstvo_number))
            {
                var addQuery = $"insert into tyristicheskoe_agenstvo (agenstvo_number, agenstvo_email, agenstvo_name, agenstvo_country) values ('{agenstvo_number}', '{agenstvo_email}', '{agenstvo_name}', '{agenstvo_country}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запись не была создана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
