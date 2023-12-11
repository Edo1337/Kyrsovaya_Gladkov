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
using System.Reflection;

namespace Kyrsovaya_Gladkov
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        DataBase database = new DataBase();

        int selectedRow;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns1();
            RefreshDataGrid1(dataGridView1);
            CreateColumns2();
            RefreshDataGrid2(dataGridView2);
            CreateColumns3();
            RefreshDataGrid3(dataGridView3);
            CreateColumns4();
            RefreshDataGrid4(dataGridView4);
            CreateColumns5();
            RefreshDataGrid5(dataGridView5);
        }
        //dataGridView1/tyr_operator
        private void CreateColumns1()
        {
            dataGridView1.Columns.Add("operator_uid", "id Оператора");
            dataGridView1.Columns.Add("operator_name","Название оператора");
            dataGridView1.Columns.Add("operator_number", "Номер оператора");
            dataGridView1.Columns.Add("opearator_email", "Почта оператора");
            dataGridView1.Columns.Add("operator_country","Страна оператора");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt64(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from tyr_operator";

            SqlCommand command= new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }
            reader.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_uid_operator.Text = row.Cells[0].Value.ToString();
                textBox_name_operator.Text = row.Cells[1].Value.ToString();
                textBox_number_operator.Text = row.Cells[2].Value.ToString();
                textBox_mail_operator.Text = row.Cells[3].Value.ToString();
                textBox_country_operator.Text = row.Cells[4].Value.ToString();
            }
        }

        private void refresh_tyr_operator_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1(dataGridView1);
        }

        private void deleteRow1()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void Update1()
        {
            database.openConnection();

            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;
                if(rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from tyr_operator where operator_uid = {id}";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var operator_uid = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var operator_name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var operator_number = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var operator_email = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var operator_country = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update tyr_operator set operator_name = '{operator_name}', operator_number = '{operator_number}', operator_email = '{operator_email}', operator_country = '{operator_country}' where operator_uid = '{operator_uid}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.closeConnection();
        }

        private void Button_add_tyr_operator_Click(object sender, EventArgs e)
        {
            Add_Form_tyr_operator addfrm = new Add_Form_tyr_operator();
            addfrm.Show();
        }

        private void button_delete_tyr_operator_Click(object sender, EventArgs e)
        {
            deleteRow1();
        }

        private void button_save_tyr_operator_Click(object sender, EventArgs e)
        {
            Update1();
        }


        private void Change1()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_uid_operator.Text;
            var name_operator = textBox_name_operator.Text;
            long number_operator;
            var mail_operator = textBox_mail_operator.Text;
            var country_operator = textBox_country_operator.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if(long.TryParse(textBox_number_operator.Text, out number_operator))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, name_operator, number_operator, mail_operator, country_operator);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void button_change_tyr_operator_Click(object sender, EventArgs e)
        {
            Change1();
        }

        //dataGridView2/tyr
        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("tyr_id", "id Тура");
            dataGridView2.Columns.Add("tyr_price", "Цена тура");
            dataGridView2.Columns.Add("dlitelnost", "Длительность");
            dataGridView2.Columns.Add("vid_transporta", "Вид транспорта");
            dataGridView2.Columns.Add("locatsiya", "Локация");
            dataGridView2.Columns.Add("rating_tyra", "Рейтинг тура");
            dataGridView2.Columns.Add("fk_operator_uid", "ID Оператора");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetFloat(5), record.GetInt32(6), RowState.ModifiedNew);
        }
        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from tyr";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                textBox_tyr_id.Text = row.Cells[0].Value.ToString();
                textBox_tyr_price.Text = row.Cells[1].Value.ToString();
                textBox_dlitelnost.Text = row.Cells[2].Value.ToString();
                textBox_vid_transporta.Text = row.Cells[3].Value.ToString();
                textBox_locatsiya.Text = row.Cells[4].Value.ToString();
                textBox_rating_tyra.Text = row.Cells[5].Value.ToString();
                textBox_fk_operator_uid.Text = row.Cells[6].Value.ToString();
            }
        }


        private void button_refresh_tyr_Click(object sender, EventArgs e)
        {
            RefreshDataGrid2(dataGridView2);
        }
        private void deleteRow2()
        {
            int index = dataGridView2.CurrentCell.RowIndex;

            dataGridView2.Rows[index].Visible = false;

            if (dataGridView2.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView2.Rows[index].Cells[7].Value = RowState.Deleted;
                return;
            }

            dataGridView2.Rows[index].Cells[7].Value = RowState.Deleted;
        }
        private void Update2()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView2.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView2.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from tyr where tyr_id = {id}";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var tyr_id = dataGridView2.Rows[index].Cells[0].Value.ToString();
                    var tyr_price = dataGridView2.Rows[index].Cells[1].Value.ToString();
                    var dlitelnost = dataGridView2.Rows[index].Cells[2].Value.ToString();
                    var vid_transporta = dataGridView2.Rows[index].Cells[3].Value.ToString();
                    var locatsiya = dataGridView2.Rows[index].Cells[4].Value.ToString();
                    var rating_tyra = dataGridView2.Rows[index].Cells[5].Value.ToString();
                    var fk_operator_uid = dataGridView2.Rows[index].Cells[6].Value.ToString();

                    var changeQuery = $"update tyr set tyr_price = '{tyr_price}', dlitelnost = '{dlitelnost}', vid_transporta = '{vid_transporta}', locatsiya = '{locatsiya}', rating_tyra = '{rating_tyra}', fk_operator_uid = '{fk_operator_uid}' where tyr_id = '{tyr_id}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.closeConnection();
        }
        private void button_add_tyr_Click(object sender, EventArgs e)
        {
            Add_Form_tyr addfrm = new Add_Form_tyr();
            addfrm.Show();
        }

        private void button_delete_tyr_Click(object sender, EventArgs e)
        {
            deleteRow2();
        }

        private void button_save_tyr_Click(object sender, EventArgs e)
        {
            Update2();
        }
        private void Change2()
        {
            var selectedRowIndex = dataGridView2.CurrentCell.RowIndex;

            var tyr_id = textBox_tyr_id.Text;
            int tyr_price;
            int dlitelnost;
            var vid_transporta = textBox_vid_transporta.Text;
            var locatsiya = textBox_locatsiya.Text;
            float rating_tyra;
            int fk_operator_uid;

            if (dataGridView2.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_tyr_price.Text, out tyr_price) && int.TryParse(textBox_dlitelnost.Text, out dlitelnost) && float.TryParse(textBox_rating_tyra.Text, out rating_tyra) && int.TryParse(textBox_fk_operator_uid.Text, out fk_operator_uid))
                {
                    dataGridView2.Rows[selectedRowIndex].SetValues(tyr_id, tyr_price, dlitelnost, vid_transporta, locatsiya, rating_tyra, fk_operator_uid);
                    dataGridView2.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void button_change_tyr_Click(object sender, EventArgs e)
        {
            Change2();
        }

        //dataGridView3/tyristicheskoe_agenstvo
        private void CreateColumns3()
        {
            dataGridView3.Columns.Add("agenstvo_id", "id агентства");
            dataGridView3.Columns.Add("agenstvo_number", "Номер агентства");
            dataGridView3.Columns.Add("agenstvo_email", "Почта агентства");
            dataGridView3.Columns.Add("agenstvo_name", "Название агентства");
            dataGridView3.Columns.Add("agenstvo_country", "Страна агентства");
            dataGridView3.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow3(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt64(1), record.GetString(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }
        private void RefreshDataGrid3(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from tyristicheskoe_agenstvo";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow3(dgw, reader);
            }
            reader.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[selectedRow];

                textBox_agenstvo_id.Text = row.Cells[0].Value.ToString();
                textBox_agenstvo_number.Text = row.Cells[1].Value.ToString();
                textBox_agenstvo_email.Text = row.Cells[2].Value.ToString();
                textBox_agenstvo_name.Text = row.Cells[3].Value.ToString();
                textBox_agenstvo_country.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button_refresh_tyristicheskoe_agenstvo_Click(object sender, EventArgs e)
        {
            RefreshDataGrid3(dataGridView3);

        }

        private void deleteRow3()
        {
            int index = dataGridView3.CurrentCell.RowIndex;

            dataGridView3.Rows[index].Visible = false;

            if (dataGridView3.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView3.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView3.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void Update3()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView3.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView3.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView3.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from tyristicheskoe_agenstvo where agenstvo_id = {id}";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var agenstvo_id = dataGridView3.Rows[index].Cells[0].Value.ToString();
                    var agenstvo_number = dataGridView3.Rows[index].Cells[1].Value.ToString();
                    var agenstvo_email = dataGridView3.Rows[index].Cells[2].Value.ToString();
                    var agenstvo_name = dataGridView3.Rows[index].Cells[3].Value.ToString();
                    var agenstvo_country = dataGridView3.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update tyr set agenstvo_number = '{agenstvo_number}', agenstvo_email = '{agenstvo_email}', agenstvo_name = '{agenstvo_name}', agenstvo_country = '{agenstvo_country}' where agenstvo_id = '{agenstvo_id}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.closeConnection();
        }
        private void button_add_tyristicheskoe_agenstvo_Click(object sender, EventArgs e)
        {
            Add_Form_tyristicheskoe_agenstvo addfrm = new Add_Form_tyristicheskoe_agenstvo();
            addfrm.Show();
        }

        private void button_delete_tyristicheskoe_agenstvo_Click(object sender, EventArgs e)
        {
            deleteRow3();
        }

        private void button_save_tyristicheskoe_agenstvo_Click(object sender, EventArgs e)
        {
            Update3();
        }

        private void Change3()
        {
            var selectedRowIndex = dataGridView3.CurrentCell.RowIndex;

            var agenstvo_id = textBox_agenstvo_id.Text;
            long agenstvo_number;
            var agenstvo_email = textBox_agenstvo_email.Text;
            var agenstvo_name = textBox_agenstvo_name.Text;
            var agenstvo_country = textBox_agenstvo_country.Text;


            if (dataGridView3.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (long.TryParse(textBox_agenstvo_number.Text, out agenstvo_number))
                {
                    dataGridView3.Rows[selectedRowIndex].SetValues(agenstvo_id, agenstvo_number, agenstvo_email, agenstvo_name, agenstvo_country);
                    dataGridView3.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void button_change_tyristicheskoe_agenstvo_Click(object sender, EventArgs e)
        {
            Change3();
        }

        //dataGridView4/Dogovor
        private void CreateColumns4()
        {
            dataGridView4.Columns.Add("dogovor_id", "ID Договора");
            dataGridView4.Columns.Add("dogovor_name", "Название договора");
            dataGridView4.Columns.Add("data_nachala", "Дата начала");
            dataGridView4.Columns.Add("data_konca", "Дата конца");
            dataGridView4.Columns.Add("price_of_tyr", "Цена тура");
            dataGridView4.Columns.Add("fk_agenstvo_id", "ID Агентства");
            dataGridView4.Columns.Add("fk_client_id", "ID Клиента");
            dataGridView4.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow4(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDateTime(2), record.GetDateTime(3), record.GetInt32(4), record.GetInt32(5), record.GetInt32(6), RowState.ModifiedNew);
        }
        private void RefreshDataGrid4(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from dogovor";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow4(dgw, reader);
            }
            reader.Close();
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[selectedRow];

                textBox_tyr_id.Text = row.Cells[0].Value.ToString();
                textBox_tyr_price.Text = row.Cells[1].Value.ToString();
                textBox_dlitelnost.Text = row.Cells[2].Value.ToString();
                textBox_vid_transporta.Text = row.Cells[3].Value.ToString();
                textBox_locatsiya.Text = row.Cells[4].Value.ToString();
                textBox_rating_tyra.Text = row.Cells[5].Value.ToString();
                textBox_fk_operator_uid.Text = row.Cells[6].Value.ToString();
            }
        }
        private void button_refresh_dogovor_Click(object sender, EventArgs e)
        {
            RefreshDataGrid4(dataGridView4);
        }
        private void deleteRow4()
        {
            int index = dataGridView4.CurrentCell.RowIndex;

            dataGridView4.Rows[index].Visible = false;

            if (dataGridView4.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView4.Rows[index].Cells[7].Value = RowState.Deleted;
                return;
            }

            dataGridView4.Rows[index].Cells[7].Value = RowState.Deleted;
        }
        private void Update4()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView4.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView4.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView4.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from dogovor where dogovor_id = {id}";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var dogovor_id = dataGridView4.Rows[index].Cells[0].Value.ToString();
                    var dogovor_name = dataGridView4.Rows[index].Cells[1].Value.ToString();
                    var data_nachala = dataGridView4.Rows[index].Cells[2].Value.ToString();
                    var data_konca = dataGridView4.Rows[index].Cells[3].Value.ToString();
                    var price_of_tyr = dataGridView4.Rows[index].Cells[4].Value.ToString();
                    var fk_agenstvo_id = dataGridView4.Rows[index].Cells[5].Value.ToString();
                    var fk_client_id = dataGridView4.Rows[index].Cells[6].Value.ToString();

                    var changeQuery = $"update tyr set dogovor_name = '{dogovor_name}', data_nachala = '{data_nachala}', data_konca = '{data_konca}', price_of_tyr = '{price_of_tyr}', fk_agenstvo_id = '{fk_agenstvo_id}', fk_client_id = '{fk_client_id}' where dogovor_id = '{dogovor_id}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }
        private void button_add_dogovor_Click(object sender, EventArgs e)
        {
            Add_Form_dogovor addfrm = new Add_Form_dogovor();
            addfrm.Show();

        }

        private void button_delete_dogovor_Click(object sender, EventArgs e)
        {
            deleteRow4();
        }

        private void button_save_dogovor_Click(object sender, EventArgs e)
        {
            Update4();
        }

        private void Change4()
        {
            var selectedRowIndex = dataGridView4.CurrentCell.RowIndex;

            var dogovor_id = textBox_tyr_id.Text;
            var dogovor_name = textBox_dogovor_name.Text;
            var data_nachala = textBox_data_nachala.Text;
            var data_konca = textBox_data_konca.Text;
            var price_of_tyr = textBox_price_of_tyr.Text;
            int fk_agenstvo_id;
            int fk_client_id;

            if (dataGridView4.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_fk_agenstvo_id.Text, out fk_agenstvo_id) && int.TryParse(textBox_fk_client_id.Text, out fk_client_id))
                {
                    dataGridView4.Rows[selectedRowIndex].SetValues(dogovor_id, dogovor_name, data_nachala, data_konca, price_of_tyr, fk_agenstvo_id, fk_client_id);
                    dataGridView4.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void button_change_dogovor_Click(object sender, EventArgs e)
        {
            Change4();
        }



        //dataGridView5/Client
        private void CreateColumns5()
        {
            dataGridView5.Columns.Add("client_id", "id клиента");
            dataGridView5.Columns.Add("passport", "Паспорт");
            dataGridView5.Columns.Add("client_number", "Номер клиента");
            dataGridView5.Columns.Add("client_name", "Имя");
            dataGridView5.Columns.Add("client_patronymic", "Отчество");
            dataGridView5.Columns.Add("client_surname", "Фамилия");
            dataGridView5.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow5(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt64(1), record.GetInt64(2), record.GetString(3), record.GetString(4), record.GetString(5), RowState.ModifiedNew);
        }
        private void RefreshDataGrid5(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from client";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow5(dgw, reader);
            }
            reader.Close();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[selectedRow];

                textBox_client_id.Text = row.Cells[0].Value.ToString();
                textBox_passport.Text = row.Cells[1].Value.ToString();
                textBox_client_number.Text = row.Cells[2].Value.ToString();
                textBox_client_name.Text = row.Cells[3].Value.ToString();
                textBox_client_patronymic.Text = row.Cells[4].Value.ToString();
                textBox_client_surname.Text = row.Cells[5].Value.ToString();
            }

        }

        private void button_refresh_client_Click(object sender, EventArgs e)
        {
            RefreshDataGrid5(dataGridView5);
        }
        private void deleteRow5()
        {
            int index = dataGridView5.CurrentCell.RowIndex;

            dataGridView5.Rows[index].Visible = false;

            if (dataGridView5.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView5.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }

            dataGridView5.Rows[index].Cells[6].Value = RowState.Deleted;
        }
        private void Update5()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView5.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView5.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView5.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from client where client_id = {id}";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var client_id = dataGridView5.Rows[index].Cells[0].Value.ToString();
                    var passport = dataGridView5.Rows[index].Cells[1].Value.ToString();
                    var client_number = dataGridView5.Rows[index].Cells[2].Value.ToString();
                    var client_name = dataGridView5.Rows[index].Cells[3].Value.ToString();
                    var client_patronymic = dataGridView5.Rows[index].Cells[4].Value.ToString();
                    var client_surname = dataGridView5.Rows[index].Cells[5].Value.ToString();

                    var changeQuery = $"update client set passport = '{passport}', client_number = '{client_number}', client_name = '{client_name}', client_patronymic = '{client_patronymic}', client_surname = '{client_surname}' where client_id = '{client_id}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.closeConnection();
        }

        private void button_add_client_Click(object sender, EventArgs e)
        {
            Add_Form_client addfrm = new Add_Form_client();
            addfrm.Show();
        }

        private void button_delete_client_Click(object sender, EventArgs e)
        {
            deleteRow5();
        }

        private void button_save_client_Click(object sender, EventArgs e)
        {
            Update5();
        }

        private void Change5()
        {
            var selectedRowIndex = dataGridView5.CurrentCell.RowIndex;

            var client_id = textBox_client_id.Text;
            long passport;
            long client_number;
            var client_name = textBox_client_name.Text;
            var client_patronymic = textBox_client_patronymic.Text;
            var client_surname = textBox_client_surname.Text;

            if (dataGridView5.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (long.TryParse(textBox_passport.Text, out passport) && long.TryParse(textBox_client_number.Text, out client_number))
                {
                    dataGridView5.Rows[selectedRowIndex].SetValues(client_id, passport, client_number, client_name, client_patronymic, client_surname);
                    dataGridView5.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void button_change_client_Click(object sender, EventArgs e)
        {
            Change5();
        }

    }
}
