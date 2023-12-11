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
    public partial class Add_Form_tyr_operator : Form
    {
        DataBase database = new DataBase();
        public Add_Form_tyr_operator()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void Add_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();

            
            var name_operator = textBox_name_operator1.Text;
            long number_operator;
            var mail_operator = textBox_mail_operator1.Text;
            var country_operator = textBox_country_operator1.Text;

            if(long.TryParse(textBox_number_operator1.Text, out number_operator))
            {
                var addQuery = $"insert into tyr_operator (operator_name, operator_number, operator_email, operator_country) values ('{name_operator}', '{number_operator}', '{mail_operator}', '{country_operator}')";

                var command = new SqlCommand(addQuery,database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!","Успех!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запись не была создана!","Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
