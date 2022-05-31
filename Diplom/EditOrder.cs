using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diplom
{
    public partial class EditOrder : Form
    {
        //Объявляем объект соединения глобально
        MySqlConnection conn;
        public EditOrder()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }

        public void SelectData()
        {
            //Открываем соединение
            conn.Open();
            //Меняем на форме название, с указанием того студента, которого хотим изменить
            this.Text = $"Меняем заказ ID: {ControlData.id_order}";
            //Объявляем запрос на вывод данных из таблицы в поля
            string sql_select_current_stud = $"SELECT zakaz.id_order, status.id_status, zakaz.FIO, zakaz.numberphone, auth.id, zakaz.price, zakaz.cause, zakaz.IMEI, zakaz.conditione, zakaz.device, zakaz.type_device, zakaz.comm, zakaz.model FROM zakaz, auth, status WHERE id_order = {ControlData.id_order}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_select_current_stud, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                comboBox1.SelectedValue = reader[1].ToString();
                textBox2.Text = reader[2].ToString();
                textBox3.Text = reader[3].ToString();
                textBox9.Text = reader[10].ToString();
                textBox10.Text = reader[9].ToString();
                textBox8.Text = reader[12].ToString();
                textBox7.Text = reader[7].ToString();
                textBox4.Text = reader[8].ToString();
                dateTimePicker1.Text = reader[6].ToString();
                textBox11.Text = reader[11].ToString();
                comboBox4.SelectedValue = reader[4].ToString();
                textBox5.Text = reader[5].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        public void GetComboBox1()
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_status", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name_status", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox1.DataSource = list_stud_table;
            comboBox1.DisplayMember = "name_status";
            comboBox1.ValueMember = "id_status";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_status, name_status FROM status";
            list_stud_command.CommandText = sql_list_users;
            list_stud_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_stud_reader;
            try
            {
                //Инициализируем ридер
                list_stud_reader = list_stud_command.ExecuteReader();
                while (list_stud_reader.Read())
                {
                    DataRow rowToAdd = list_stud_table.NewRow();
                    rowToAdd["id_status"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name_status"] = list_stud_reader[1].ToString();
                    list_stud_table.Rows.Add(rowToAdd);
                }
                list_stud_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }

        public void GetComboBox4()
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("fio", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox4.DataSource = list_stud_table;
            comboBox4.DisplayMember = "fio";
            comboBox4.ValueMember = "id";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id, fio FROM auth";
            list_stud_command.CommandText = sql_list_users;
            list_stud_command.Connection = conn;
            //Формирование списка ЦП для combobox'a
            MySqlDataReader list_stud_reader;
            try
            {
                //Инициализируем ридер
                list_stud_reader = list_stud_command.ExecuteReader();
                while (list_stud_reader.Read())
                {
                    DataRow rowToAdd = list_stud_table.NewRow();
                    rowToAdd["id"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["fio"] = list_stud_reader[1].ToString();
                    list_stud_table.Rows.Add(rowToAdd);
                }
                list_stud_reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
            }
        }
        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetListUsers();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем методы наполнения ComboBox
            GetComboBox4();
            GetComboBox1();
            //GetComboBox3();
            //Вызываем метод установления значений полей
            SelectData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            //Определяем значение переменных для записи в БД
            string n_status = comboBox1.Text;
            string n_FIO = textBox2.Text;
            string n_numberphone = textBox3.Text;
            string n_type_device = textBox9.Text;
            string n_device = textBox10.Text;
            string n_model = textBox8.Text;
            string n_IMEI = textBox7.Text;
            string n_condition = textBox4.Text;
            string n_comm = textBox11.Text;
            string n_executor = comboBox4.Text;
            string n_price = textBox5.Text;
            string n_cause = dateTimePicker1.Text;

            //Формируем запрос на изменение
            string sql_update_current_stud = $"UPDATE zakaz SET status='{n_status}', FIO='{n_FIO}', numberphone='{n_numberphone}', executor='{n_executor}', price='{n_price}', cause='{n_cause}', IMEI='{n_IMEI}', conditione='{n_condition}', device='{n_device}' , type_device='{n_type_device}', comm='{n_comm}', model='{n_model}'" +
                $"WHERE (id_order='{ControlData.id_order}')";
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_update_current_stud, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            this.Close();
            reload_list();
        }
    }
}
