using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diplom
{
    public partial class AddPrice : Form
    {
        public AddPrice()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }
        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ДОБАВИТЬ заказ
        public bool InsertPrepods(string i_job, string i_time, string i_norma, string i_price)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO price (job, time, norma, price) VALUES ('{i_job}', '{i_time}', '{i_norma}', '{i_price}')";
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

        private void Form8_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }
        public void ReloadPriceList()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadPriceList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetPriceList();
            
        }
        private void yt_Button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string i_job = textBox1.Text;
            string i_time = textBox2.Text;
            string i_norma = textBox3.Text;
            string i_price = textBox4.Text;

            SomeClass.variable_class1 = i_job;
            SomeClass.variable_class2 = i_time;
            SomeClass.variable_class3 = i_norma;
            SomeClass.variable_class4 = i_price;
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertPrepods(i_job, i_time, i_norma, i_price))
            {
                MessageBox.Show("Успешно добавлено!");
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Произошла ошибка.", "Ошибка");
            }
            ReloadPriceList();
            //Закрываем форму
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        //ВВод только букв
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
            }

        }
        //Ввод только цифр
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
        //Ввод только цифр
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }
    }
}
