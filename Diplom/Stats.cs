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
    public partial class Stats : Form
    {
        ////Переменная соединения
        //MySqlConnection conn;
        ////DataAdapter представляет собой объект Command , получающий данные из источника данных.
        //private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        ////Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        //private BindingSource bSource = new BindingSource();
        ////DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        ////модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        ////и ограничивающие данные, а также связи между таблицами.
        //private DataSet ds = new DataSet();
        ////Представляет одну таблицу данных в памяти.
        //private DataTable table = new DataTable();
      
        //static readonly string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
        //Переменная соединения
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Объявляем объект соединения глобально
        ////Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        ////что бы в БД не отправлялся null
        string id_selected_rows = "0";
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";

        public Stats()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }
        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListUsersAnalitic();
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
            comboBox1.DataSource = list_stud_table;
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "id";
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
        //public void ReloadAnaliticList()
        //{
        //    //Чистим виртуальную таблицу внутри класса
        //    ControlData.ReloadAnaliticList();
        //    //Вызываем метод получения записей, который вновь заполнит таблицу
        //    ControlData.GetListUsersAnalitic();
        //    //Отражаем количество записей в ДатаГриде
        //    int count_rows = dataGridView1.RowCount - 1;
        //    label1.Text = (count_rows).ToString();
        //}
        public void GetListUsersAnalitic()
        {
        //    string i_cause = dateTimePicker1.Text;
        //    string i_cause2 = dateTimePicker2.Text;
        //    //Запрос для вывода строк в БД
            string commandStr = $"SELECT id_order AS 'Код', status AS 'Статус', FIO AS 'ФИО', numberphone AS 'Номер телефона', executor AS 'Исполнитель', price AS 'Стоимость', cause AS 'Дата приема', IMEI AS 'Серийный номер', conditione AS 'Состояние', device AS 'Название бренда', model AS 'Модель' , type_device AS 'Тип устройства', comm AS 'Комментарий' FROM zakaz ";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
            //    //Отражаем количество записей в ДатаГриде

        }
        public void GetListTest()
        {
            table.Clear();
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text; string master = comboBox1.Text;
            //    //Запрос для вывода строк в БД
            string commandStr = $"SELECT id_order AS 'Код', status AS 'Статус', FIO AS 'ФИО', numberphone AS 'Номер телефона', executor AS 'Исполнитель', price AS 'Стоимость', cause AS 'Дата приема', IMEI AS 'Серийный номер', conditione AS 'Состояние', device AS 'Название бренда', model AS 'Модель' , type_device AS 'Тип устройства', comm AS 'Комментарий' FROM zakaz WHERE executor ='{master}' AND cause BETWEEN '{i_cause}' AND '{i_cause2}'";

            //string commandStr = $"SELECT id_order AS 'Код', status AS 'Статус', FIO AS 'ФИО', numberphone AS 'Номер телефона', executor AS 'Исполнитель', price AS 'Стоимость', cause AS 'Дата приема', IMEI AS 'Серийный номер', conditione AS 'Состояние', device AS 'Название бренда', model AS 'Модель' , type_device AS 'Тип устройства', comm AS 'Комментарий' FROM zakaz WHERE cause BETWEEN '" +i_cause+ "' AND '" + i_cause2 +"' ";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
          //  MessageBox.Show(commandStr);
            //    //Отражаем количество записей в ДатаГриде

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            GetComboBox4();
            GetListUsersAnalitic();
            Vremonte();
            Open();
            All();
            avg();
            price();
            diagnost();
            Ready();
            Issued();
            Wait();

            //   GetListTest();
            //Указываем, что источником данных ДатаГрида является bindingsource, возвращённый из метода класса 
            // dataGridView1.DataSource = ControlData.GetListUsersAnalitic();

            //Видимость полей в гриде
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[9].Visible = true;
            dataGridView1.Columns[10].Visible = true;
            dataGridView1.Columns[11].Visible = true;
            dataGridView1.Columns[12].Visible = true;

            //Ширина полей
            dataGridView1.Columns[0].FillWeight = 11;
            dataGridView1.Columns[1].FillWeight = 23;
            dataGridView1.Columns[2].FillWeight = 50;
            dataGridView1.Columns[3].FillWeight = 24;
            dataGridView1.Columns[4].FillWeight = 53;
            dataGridView1.Columns[5].FillWeight = 22;
            dataGridView1.Columns[6].FillWeight = 23;
            dataGridView1.Columns[7].FillWeight = 30;
            dataGridView1.Columns[8].FillWeight = 30;
            dataGridView1.Columns[9].FillWeight = 20;
            dataGridView1.Columns[10].FillWeight = 30;
            dataGridView1.Columns[11].FillWeight = 20;
            dataGridView1.Columns[12].FillWeight = 40;

            //Режим для полей "Только для чтения"
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;
            dataGridView1.Columns[9].ReadOnly = true;
            dataGridView1.Columns[10].ReadOnly = true;
            dataGridView1.Columns[11].ReadOnly = true;
            dataGridView1.Columns[12].ReadOnly = true;

            //Растягивание полей грида
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Убираем заголовки строк
            dataGridView1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;
            //Отражаем количество записей в ДатаГриде
            //int count_rows = dataGridView1.RowCount - 1;
            //toolStripLabel2.Text = (count_rows).ToString();
        }
        private void Vremonte ()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            string sql_list_users = $"SELECT COUNT(status) FROM zakaz WHERE  executor ='{master}' AND status ='В ремонте' AND cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label6.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД
            conn.Close();
        }
        private void Open()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            string sql_list_users = $"SELECT COUNT(status) FROM zakaz WHERE  executor ='{master}' AND status ='Открыто' AND cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label8.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД
            conn.Close();
        }
        private void All()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            string sql_list_users = $"SELECT COUNT(id_order) FROM zakaz WHERE executor ='{master}' AND cause BETWEEN '{i_cause}' AND '{i_cause2}'";
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label10.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД
            conn.Close();
        }
        private void avg()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            string sql_list_users = $"SELECT round(AVG(price)) FROM zakaz WHERE executor ='{master}' AND cause BETWEEN '{i_cause}' AND '{i_cause2}'";
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label12.Text = (reader_list[0].ToString() + " рублей");
            }
            // закрываем подключение к БД
            conn.Close();
        }
        private void price()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            // Запрос на счет
            string sql_list_users = $"SELECT SUM(price) FROM zakaz WHERE executor ='{master}' AND  cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label4.Text = (reader_list[0].ToString() + " рублей");
            }
            // закрываем подключение к БД

            conn.Close();
        }
        private void diagnost()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            // Запрос на счет
            string sql_list_users = $"SELECT COUNT(status) FROM zakaz WHERE  executor ='{master}' AND status ='Диагностика' AND cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label16.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД

            conn.Close();
        }
        private void Ready()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            // Запрос на счет
            string sql_list_users = $"SELECT COUNT(status) FROM zakaz WHERE  executor ='{master}' AND status ='Готов' AND cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label17.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД

            conn.Close();
        }
        private void Issued()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            // Запрос на счет
            string sql_list_users = $"SELECT COUNT(status) FROM zakaz WHERE  executor ='{master}' AND status ='Выдан' AND cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label18.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД

            conn.Close();
        }
        private void Wait()
        {
            string i_cause = dateTimePicker1.Text;
            string i_cause2 = dateTimePicker2.Text;
            string master = comboBox1.Text;
            conn.Open();
            // Запрос на счет
            string sql_list_users = $"SELECT COUNT(status) FROM zakaz WHERE  executor ='{master}' AND status ='Ждет ЗИП' AND cause  BETWEEN '{i_cause}' AND '{i_cause2}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_list_users, conn);
            // выполняем запрос
            MySqlDataReader reader_list = command.ExecuteReader();
            while (reader_list.Read())
            {
                label20.Text = (reader_list[0].ToString() + " заказов");
            }
            // закрываем подключение к БД

            conn.Close();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
           
        }

       

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            table.Clear();
            GetListTest(); 
            Vremonte();
            Open();
            All();
            avg();
            price();
            diagnost();
            Ready();
            Issued();
            Wait();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
