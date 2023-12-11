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
    public partial class Add_Form_client : Form
    {
        DataBase database = new DataBase();
        public Add_Form_client()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();


            long passport;
            long client_number;
            var client_name = textBox_client_name1.Text;
            var client_patronymic = textBox_client_patronymic1.Text;
            var client_surname = textBox_client_surname1.Text;

            if (long.TryParse(textBox_passport1.Text, out passport) && long.TryParse(textBox_client_number1.Text, out client_number))
            {
                var addQuery = $"insert into client (passport, client_number, client_name, client_patronymic, client_surname) values ('{passport}', '{client_number}', '{client_name}', '{client_patronymic}', '{client_surname}')";

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
