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
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }

        //Простой метод добавляющий в таблицу записи, в качестве параметров принимает ДОБАВИТЬ заказ
        //ПРАВИЛЬНЫЙ!
        //public bool InsertPrepods(string i_status, string i_FIO, string i_numberphone, string i_executor, string i_price, string i_cause, string i_imei, string i_conditione, string i_deivice, string i_type_device, string i_comm, string i_model)
        //{
        //    //определяем переменную, хранящую количество вставленных строк
        //    int InsertCount = 0;
        //    //Объявляем переменную храняющую результат операции
        //    bool result = false;
        //    // открываем соединение
        //    conn.Open();
        //    // запросы
        //    // запрос вставки данных
        //    string query = $"INSERT INTO zakaz (status, FIO, numberphone, executor, price, cause, IMEI, conditione, device, type_device, comm, model) VALUES ('{i_status}', '{i_FIO}', '{i_numberphone}', '{i_executor}', '{i_price}', '{i_cause}', '{i_imei}', '{i_conditione}', '{i_deivice}', '{i_type_device}', '{i_comm}', '{i_model}')";
        //    try
        //    {
        //        // объект для выполнения SQL-запроса
        //        MySqlCommand command = new MySqlCommand(query, conn);
        //        // выполняем запрос
        //        InsertCount = command.ExecuteNonQuery();
        //        //string new_inserted_mainOrder_id = command.ExecuteScalar().ToString();
        //        //Записываем возвращённый последний добавленный ID заказа в глобальную переменную
        //       // SomeClass.new_inserted_mainOrder_id = new_inserted_mainOrder_id;
        //        // закрываем подключение к БД
        //    }
        //    catch
        //    {
        //        //Если возникла ошибка, то запрос не вставит ни одной строки
        //        InsertCount = 0;
        //    }
        //    finally
        //    {
        //        //Но в любом случае, нужно закрыть соединение
        //        conn.Close();
        //        //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
        //        if (InsertCount != 0)
        //        {
        //            //то результат операции - истина
        //            result = true;
        //        }
        //    }
        //    //Вернём результат операции, где его обработает алгоритм
        //    return result;
        //}





        //public bool InsertPrepods(string i_status, string i_FIO, string i_numberphone, string i_executor, string i_price, string i_cause, string i_imei, string i_conditione, string i_deivice, string i_type_device, string i_comm, string i_model, string i_password)
        //{
        //    //определяем переменную, хранящую количество вставленных строк
        //    int InsertCount = 0;
        //    //Объявляем переменную храняющую результат операции
        //    bool result = false;
        //    // открываем соединение
        //    conn.Open();
        //    // запросы
            
        //    // запрос вставки данных
        //    string query = $"INSERT INTO zakaz (status, FIO, numberphone, executor, price, cause, IMEI, conditione, device, type_device, comm, model) VALUES ('{i_status}', '{i_FIO}', '{i_numberphone}', '{i_executor}', '{i_price}', '{i_cause}', '{i_imei}', '{i_conditione}', '{i_deivice}', '{i_type_device}', '{i_comm}', '{i_model}');" +
        //        $" INSERT INTO client (FIO, numberphone, password) VALUES('{i_FIO}','{i_numberphone}','{i_password}');" +
        //        $"SELECT id_order FROM zakaz WHERE (id_order = LAST_INSERT_ID());";
        //    try
        //    {
        //        // объект для выполнения SQL-запроса
        //        MySqlCommand command = new MySqlCommand(query, conn);
        //        // выполняем запрос

        //        InsertCount = command.ExecuteNonQuery();
        //        string id = command.ExecuteScalar().ToString();
        //        SomeClass.new_inserted_id = id;
        //        MessageBox.Show($"ID нового клиента {id}");

        //        //string new_inserted_mainOrder_id = command.ExecuteScalar().ToString();
        //        //Записываем возвращённый последний добавленный ID заказа в глобальную переменную
        //        // SomeClass.new_inserted_mainOrder_id = new_inserted_mainOrder_id;
        //        // закрываем подключение к БД
        //    }
        //    catch
        //    {
        //        //Если возникла ошибка, то запрос не вставит ни одной строки
        //        InsertCount = 0;
        //    }
        //    finally
        //    {
        //        //Но в любом случае, нужно закрыть соединение
        //        conn.Close();
        //        //Ессли количество вставленных строк было не 0, то есть вставлена хотя бы 1 строка
        //        if (InsertCount != 0)
        //        {
        //            //то результат операции - истина
        //            result = true;
        //        }
        //    }
        //    //Вернём результат операции, где его обработает алгоритм
        //    return result;
        //}
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
        public void GetComboBox2()
        {
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_device", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name_device", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox2.DataSource = list_stud_table;
            comboBox2.DisplayMember = "name_device";
            comboBox2.ValueMember = "id_device";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_device, name_device FROM type_device";
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
                    rowToAdd["id_device"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name_device"] = list_stud_reader[1].ToString();
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
        //public void GetComboBox3()
        //{
        //    int id_device = Convert.ToInt32(comboBox2.SelectedValue);
        //    //Формирование списка статусов
        //    DataTable list_stud_table = new DataTable();
        //    MySqlCommand list_stud_command = new MySqlCommand();
        //    //Открываем соединение
        //    conn.Open();
        //    //Формируем столбцы для комбобокса списка ЦП
        //    list_stud_table.Columns.Add(new DataColumn("id_brand", System.Type.GetType("System.Int32")));
        //    list_stud_table.Columns.Add(new DataColumn("name_brand", System.Type.GetType("System.String")));
        //    //Настройка видимости полей комбобокса
        //    comboBox3.DataSource = list_stud_table;
        //    comboBox3.DisplayMember = "name_brand";
        //    comboBox3.ValueMember = "id_brand";
        //    //Формируем строку запроса на отображение списка статусов прав пользователя
        //    string sql_list_users = "SELECT id_brand, name_brand FROM brand WHERE name_brand = (SELECT brand FROM type_device WHERE id_device = ('" + id_device + "'))";
        //   // string sql_list_users = "SELECT id_telefon, name FROM telefon";
        //    list_stud_command.CommandText = sql_list_users;
        //    list_stud_command.Connection = conn;
        //    //Формирование списка ЦП для combobox'a
        //    MySqlDataReader list_stud_reader;
        //    try
        //    {
        //        //Инициализируем ридер
        //        list_stud_reader = list_stud_command.ExecuteReader();
        //        while (list_stud_reader.Read())
        //        {
        //            DataRow rowToAdd = list_stud_table.NewRow();
        //            rowToAdd["id_brand"] = Convert.ToInt32(list_stud_reader[0]);
        //            rowToAdd["name_brand"] = list_stud_reader[1].ToString();
        //            list_stud_table.Rows.Add(rowToAdd);
        //        }
        //        list_stud_reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка чтения списка ЦП \n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Application.Exit();
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public void GetComboBoxPhone()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_telefone", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_telefone";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            //string sql_list_users = "SELECT id_brand, name_brand FROM brand WHERE name_brand = (SELECT brand FROM type_device WHERE id_device = ('" + id_device + "'))";
            string sql_list_users = "SELECT id_telefone, name FROM telefon";
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
                    rowToAdd["id_telefone"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxNout()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_nout", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_nout";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_nout, name FROM nout";
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
                    rowToAdd["id_nout"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxHDD()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_hhd", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_hhd";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_hhd, name FROM HDD";
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
                    rowToAdd["id_hhd"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxMFU()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_mfu", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_mfu";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_mfu, name FROM MFU";
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
                    rowToAdd["id_mfu"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxMonitor()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_monitor", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_monitor";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_monitor, name FROM monitor";
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
                    rowToAdd["id_monitor"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxPowersupply()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_ps", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_ps";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_ps, name FROM powersupply";
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
                    rowToAdd["id_ps"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxTablet()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_tablet", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_tablet";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_tablet, name FROM tablet";
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
                    rowToAdd["id_tablet"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxTV()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_tv", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_tv";
            //Формируем строку запроса на отображение списка статусов прав пользователя
            string sql_list_users = "SELECT id_tv, name FROM TV";
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
                    rowToAdd["id_tv"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        public void GetComboBoxVideocard()
        {
            int id_device = Convert.ToInt32(comboBox2.SelectedValue);
            //Формирование списка статусов
            DataTable list_stud_table = new DataTable();
            MySqlCommand list_stud_command = new MySqlCommand();
            //Открываем соединение
            conn.Open();
            //Формируем столбцы для комбобокса списка ЦП
            list_stud_table.Columns.Add(new DataColumn("id_videocard", System.Type.GetType("System.Int32")));
            list_stud_table.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
            //Настройка видимости полей комбобокса
            comboBox3.DataSource = list_stud_table;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id_videocard";
            //Формируем строку запроса на отображение списка статусов прав пользователя       
            string sql_list_users = "SELECT id_videocard, name FROM videocard";
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
                    rowToAdd["id_videocard"] = Convert.ToInt32(list_stud_reader[0]);
                    rowToAdd["name"] = list_stud_reader[1].ToString();
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
        //Объявляем соединения с БД
        MySqlConnection conn;

        private void Form4_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод наполнения ComboBox
            GetComboBox4();
            GetComboBox2();
            //GetComboBox3();
        }
        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetListUsers();      
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string i_status = textBox1.Text;
            string i_FIO = textBox2.Text;
            string i_numberphone = textBox3.Text;
            string i_executor = comboBox4.Text;
            string i_price = textBox5.Text;
            string i_cause = dateTimePicker1.Text;
            //string i_cause = textBox6.Text;
            string i_imei = textBox7.Text;
            string i_conditione = comboBox1.Text;
            string i_deivice = comboBox3.Text;
            string i_type_device = comboBox2.Text;
            string i_comm = textBox11.Text;
            string i_model = textBox8.Text;
            string i_password = textBox6.Text;

            string query = $"INSERT INTO zakaz (status, FIO, numberphone, executor, price, cause, IMEI, conditione, device, type_device, comm, model) VALUES ('{i_status}', '{i_FIO}', '{i_numberphone}', '{i_executor}', '{i_price}', '{i_cause}', '{i_imei}', '{i_conditione}', '{i_deivice}', '{i_type_device}', '{i_comm}', '{i_model}');" +
                $"SELECT id_order FROM zakaz WHERE (id_order = LAST_INSERT_ID());" +
                $" INSERT INTO client (FIO, numberphone, password) VALUES('{i_FIO}','{i_numberphone}','{i_password}');";
                
       
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            string id_insert_client = command.ExecuteScalar().ToString();
            SomeClass.new_inserted_id = id_insert_client;
            MessageBox.Show("Заказ успешно добавлен!");
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            this.Close();


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
           
           
            reload_list();
            CreateAkt frm = new CreateAkt();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
            }
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

        private void comboBox3_Click(object sender, EventArgs e)
        {
         //   GetComboBox3();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Телефон")
            {
                comboBox3.Text = " ";
                GetComboBoxPhone();
            }
            if (comboBox2.Text == "Ноутбук")
            {
                comboBox3.Text = " ";
                GetComboBoxNout();
            }    
            if(comboBox2.Text == "Жесткий диск")
            {
                comboBox3.Text = " ";
                GetComboBoxHDD();
            }
            if (comboBox2.Text == "МФУ")
            {
                comboBox3.Text = " ";
                GetComboBoxMFU();
            }
            if (comboBox2.Text == "Монитор")
            {
                comboBox3.Text = " ";
                GetComboBoxMonitor();
            }
            if (comboBox2.Text == "Блок питания")
            {
                comboBox3.Text = " ";
                GetComboBoxPowersupply();
            }
            if (comboBox2.Text == "Планшет")
            {
                comboBox3.Text = " ";
                GetComboBoxTablet();
            }
            if (comboBox2.Text == "Телевизор")
            {
                comboBox3.Text = " ";
                GetComboBoxTV();
            }
            if (comboBox2.Text == "Видеокарта")
            {
                comboBox3.Text = " ";
                GetComboBoxVideocard();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string i_status = textBox1.Text;
            string i_FIO = textBox2.Text;
            string i_numberphone = textBox3.Text;
            string i_executor = comboBox4.Text;
            string i_price = textBox5.Text;
            string i_cause = dateTimePicker1.Text;
            //string i_cause = textBox6.Text;
            string i_imei = textBox7.Text;
            string i_conditione = comboBox1.Text;
            string i_deivice = comboBox3.Text;
            string i_type_device = comboBox2.Text;
            string i_comm = textBox11.Text;
            string i_model = textBox8.Text;
            string i_password = textBox6.Text;

            string query = $"INSERT INTO zakaz (status, FIO, numberphone, executor, price, cause, IMEI, conditione, device, type_device, comm, model) VALUES ('{i_status}', '{i_FIO}', '{i_numberphone}', '{i_executor}', '{i_price}', '{i_cause}', '{i_imei}', '{i_conditione}', '{i_deivice}', '{i_type_device}', '{i_comm}', '{i_model}');" +
                $"SELECT id_order FROM zakaz WHERE (id_order = LAST_INSERT_ID());" +
                $" INSERT INTO client (FIO, numberphone, password) VALUES('{i_FIO}','{i_numberphone}','{i_password}');";


            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            string id_insert_client = command.ExecuteScalar().ToString();
            SomeClass.new_inserted_id = id_insert_client;
            MessageBox.Show($"ID нового клиента {id_insert_client}");
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            this.Close();


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


            reload_list();
            CreateAkt frm = new CreateAkt();
            frm.Show();
        }
    }
}
