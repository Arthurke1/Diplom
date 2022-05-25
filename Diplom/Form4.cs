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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }

        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ДОБАВИТЬ заказ
        public bool InsertPrepods(string i_status, string i_FIO, string i_numberphone, string i_executor, string i_price, string i_cause, string i_imei, string i_conditione, string i_deivice, string i_type_device, string i_comm, string i_model)
        {
            //определяем переменную, хранящую количество вставленных строк
            int InsertCount = 0;
            //Объявляем переменную храняющую результат операции
            bool result = false;
            // открываем соединение
            conn.Open();
            // запросы
            // запрос вставки данных
            string query = $"INSERT INTO zakaz (status, FIO, numberphone, executor, price, cause, IMEI, conditione, device, type_device, comm, model) VALUES ('{i_status}', '{i_FIO}', '{i_numberphone}', '{i_executor}', '{i_price}', '{i_cause}', '{i_imei}', '{i_conditione}', '{i_deivice}', '{i_type_device}', '{i_comm}', '{i_model}')";
            try
            {
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(query, conn);
                // выполняем запрос
                InsertCount = command.ExecuteNonQuery();
                //string new_inserted_mainOrder_id = command.ExecuteScalar().ToString();
                //Записываем возвращённый последний добавленный ID заказа в глобальную переменную
               // SomeClass.new_inserted_mainOrder_id = new_inserted_mainOrder_id;
                // закрываем подключение к БД
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

        private void Form4_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string i_status = textBox1.Text;
            string i_FIO = textBox2.Text;
            string i_numberphone = textBox3.Text;
            string i_executor = textBox4.Text;
            string i_price = textBox5.Text;
            string i_cause = dateTimePicker1.Text;
            //string i_cause = textBox6.Text;
            string i_imei = textBox7.Text;
            string i_conditione = comboBox1.Text;
            string i_deivice = comboBox3.Text;
            string i_type_device = comboBox2.Text;
            string i_comm = textBox11.Text;
            string i_model = textBox8.Text;
            
            SomeClass.variable_class1 = i_cause;
            SomeClass.variable_class2 = i_FIO;
            SomeClass.variable_class3 = i_numberphone;
            SomeClass.variable_class4 = i_executor;
            SomeClass.variable_class5 = i_price;
            SomeClass.variable_class6 = i_cause;
            SomeClass.variable_class7 = i_imei;
            SomeClass.variable_class8 = i_conditione;
            SomeClass.variable_class9 = i_deivice;
            SomeClass.variable_class10 = i_type_device;
            SomeClass.variable_class11 = i_comm;
            SomeClass.variable_class12 = i_model;
            //Если метод вставки записи в БД вернёт истину, то просто обновим список и увидим вставленное значение
            if (InsertPrepods(i_status, i_FIO, i_numberphone, i_executor, i_price, i_cause, i_imei, i_conditione, i_deivice, i_type_device, i_comm, i_model))
            {
                MessageBox.Show("Успешно добавлено!");
            }
            //Иначе произошла какая то ошибка и покажем пользователю уведомление
            else
            {
                MessageBox.Show("Произошла ошибка.",  "Ошибка");
            }
            Form7 frm = new Form7();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           //dateTimePicker1.CustomFormat = "yyyy.mm.dd";
           // dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        
    }
}
