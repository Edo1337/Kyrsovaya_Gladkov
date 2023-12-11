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
    public partial class Add_Form_dogovor : Form
    {
        DataBase database = new DataBase();
        public Add_Form_dogovor()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();


            var dogovor_name = textBox_dogovor_name1.Text;
            var data_nachala = textBox_data_nachala1.Text;  
            var data_konca = textBox_data_konca1.Text;
            var price_of_tyr = textBox_price_of_tyr1.Text;
            int fk_agenstvo_id;
            int fk_client_id;

            if (int.TryParse(textBox_fk_agenstvo_id1.Text, out fk_agenstvo_id) && int.TryParse(textBox_fk_client_id1.Text, out fk_client_id))
            {
                var addQuery = $"insert into dogovor (dogovor_name, data_nachala, data_konca, price_of_tyr, fk_agenstvo_id, fk_client_id) values ('{dogovor_name}', '{data_nachala}', '{data_konca}', '{price_of_tyr}', '{fk_agenstvo_id}', '{fk_client_id}')";

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
