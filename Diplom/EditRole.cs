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
    public partial class EditRole : Form
    {

        //Объявляем объект соединения глобально
        MySqlConnection conn;
        public EditRole()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }
        public void SelectData()
        {
            //Открываем соединение
            conn.Open();
            //Меняем на форме название, с указанием того студента, которого хотим изменить
            this.Text = $"Меняем пользователя ID: {ControlData.id_role}";
            //Объявляем запрос на вывод данных из таблицы в поля
            string sql_select_current_stud = $"SELECT FIO, login, password, role FROM auth WHERE id = {ControlData.id_role}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_select_current_stud, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
              comboBox1.Text = reader[3].ToString();
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadRoleList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetRoleList();
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод установления значений полей
            SelectData();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            // Определяем значение переменных для записи в БД
            string n_FIO = textBox1.Text;
            string n_login = textBox2.Text;
            string n_password = textBox3.Text;
            string n_role = comboBox1.Text;
            //Формируем запрос на изменение
            string sql_update_current_stud = $"UPDATE auth SET FIO='{n_FIO}', login='{n_login}', password='{n_password}', role='{n_role}'" +
                $"WHERE (id='{ControlData.id_role}')";
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_update_current_stud, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            MessageBox.Show("Успешно изменен!");
            this.Close();
            reload_list();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46 && number != ' ') //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
    }
}
