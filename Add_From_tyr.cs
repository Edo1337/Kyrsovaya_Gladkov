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
    public partial class Add_Form_tyr : Form
    {
        DataBase database = new DataBase();
        public Add_Form_tyr()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();


            int tyr_price;
            int dlitelnost;
            var vid_transporta = textBox_vid_transporta1.Text;
            var locatsia = textBox_locatsiya1.Text;
            float rating_tyra;
            int fk_operator_uid;

            if (int.TryParse(textBox_tyr_price1.Text, out tyr_price) && int.TryParse(textBox_dlitelnost1.Text, out dlitelnost) && float.TryParse(textBox_rating_tyra1.Text, out rating_tyra) && int.TryParse(textBox_fk_operator_uid1.Text, out fk_operator_uid))
            {
                var addQuery = $"insert into tyr (tyr_price, dlitelnost, vid_transporta, locatsiya, rating_tyra, fk_operator_uid) values ('{tyr_price}', '{dlitelnost}', '{vid_transporta}', '{locatsia}', '{rating_tyra}', '{fk_operator_uid}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запись не была создана!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Form_tyr_Load(object sender, EventArgs e)
        {

        }
    }
}
