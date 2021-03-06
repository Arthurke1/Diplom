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
    public partial class AddRole : Form
    {
        public AddRole()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }
        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ДОБАВИТЬ заказ
        public bool InsertPrepods(string i_fio, string i_login, string i_password, string i_role)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT I INTO auth (fio, login, password, role) VALUES ('{i_fio}', '{i_login}', '{i_password}', '{i_role}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();

            }
            catch
            {
                //Если возникла ошибка, то запрос не вставит ни одной строки
                InsertCount = 0;
            }
            finally
            {
                //Но в любом случае, нужно закрыть соединение
                conn.Close();
                //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
                if (InsertCount != 0)
                {
                    //то результат операции - истина
                    result = true;
                }
            }
            //Вернём результат операции, где его обработает алгоритм
            return result;
        }
        //Объявляем соединения с БД
        MySqlConnection conn;
        private void Form10_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        public void ReloadRoleList()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadRoleList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetRoleList();
          
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string i_fio = textBox1.Text;
            string i_login = textBox2.Text;
            string i_password = textBox3.Text;
            string i_role = comboBox1.Text;
      
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertPrepods(i_fio, i_login, i_password, i_role))
            {
                MessageBox.Show("Успешно добавлено!");
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Такой пользователь существует.", "Ошибка");
            }
            ReloadRoleList();
            //Закрываем форму
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
            }
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
    }
}
