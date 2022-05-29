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
    class ControlData
    {
        //Определяем  поле, которое харнит ID заказа из From3 и выводится в форме Menu
        public static string id_order = "0";
        //Определяем  поле, которое харнит ID клиента из EditClient и выводится в форме Menu
        public static string id_client = "0";
        //Определяем  поле, которое харнит ID сотрудника из EditRole и выводится в форме Menu
        public static string id_role = "0";
        //Определяем  поле, которое харнит ID услуги из EditPrice и выводится в форме Menu
        public static string id_price = "0";
        //Определяем параметры подключения
        private const string host = "chuc.caseum.ru";
        private const string port = "33333";
        private const string database = "is_1_18_st3_VKR";
        private const string username = "st_1_18_3";
        private const string password = "77651256";
        //Объявляем и инициализируем соединение
        private static readonly MySqlConnection conn = GetDBConnection();
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private static readonly MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private static readonly BindingSource bSource = new BindingSource();
        private static readonly BindingSource bSource2 = new BindingSource();
        private static readonly BindingSource bSource3 = new BindingSource();
        private static readonly BindingSource bSource4 = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private static DataSet ds = new DataSet();
        //Представляет 1 таблицу данных в памяти.
        private static DataTable table = new DataTable();
        //Представляет 2 таблицу данных в памяти.
        private static DataTable table2 = new DataTable();
        //Представляет 3 таблицу данных в памяти.
        private static DataTable table3 = new DataTable();
        //Представляет 4 таблицу данных в памяти.
        private static DataTable table4 = new DataTable();

        //Статичный метод, формирующий строку для подключения и возвращающий MySqlConnection
        public static MySqlConnection GetDBConnection()
        {
            //Формируем строку подключения
            string connString = $"server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
            //Создаём соединение с нашей строкой подключения
            MySqlConnection conn = new MySqlConnection(connString);
            //Возвращаем данное соединение из метода
            return conn;
        }

        //Метод удаления строк
        public static void DeleteUser(string id_stud)
        {
            //Формируем строку запроса на добавление строк
            string sql_delete_user = "DELETE FROM zakaz WHERE id_order='" + id_stud + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            try
            {
                conn.Open();
                delete_user.ExecuteNonQuery();
                MessageBox.Show("Удаление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления строки \n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
                //Вызов метода обновления ДатаГрида
                ReloadList();
            }
            //conn.Open();
            //delete_user.ExecuteNonQuery();
            //conn.Close();
        }
        public static void DeleteList(string id_stud)
        {
            //Формируем строку запроса на добавление строк
            string sql_delete_user = "DELETE FROM price WHERE id_price='" + id_stud + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            try
            {
                conn.Open();
                delete_user.ExecuteNonQuery();
                MessageBox.Show("Удаление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления строки \n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
                //Вызов метода обновления ДатаГрида
                ReloadPriceList();
            }
            //conn.Open();
            //delete_user.ExecuteNonQuery();
            //conn.Close();
        }
        public static void DeleteRole(string id_stud)
        {
            //Формируем строку запроса на добавление строк
            string sql_delete_user = "DELETE FROM auth WHERE id='" + id_stud + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            try
            {
                conn.Open();
                delete_user.ExecuteNonQuery();
                MessageBox.Show("Удаление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления строки \n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
                //Вызов метода обновления ДатаГрида
                ReloadRoleList();
            }
        }
        public static void DeleteClient(string id_stud)
        {
            //Формируем строку запроса на добавление строк
            string sql_delete_user = "DELETE FROM client WHERE id_client='" + id_stud + "'";
            //Посылаем запрос на обновление данных
            MySqlCommand delete_user = new MySqlCommand(sql_delete_user, conn);
            try
            {
                conn.Open();
                delete_user.ExecuteNonQuery();
                MessageBox.Show("Удаление прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления строки \n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                conn.Close();
                //Вызов метода обновления ДатаГрида
                ReloadClientList();
            }
  
        }

        //Метод изменения статуса
        public static void ChangeStateStudent(string new_state, string redact_id)
        {
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE zakaz SET id_order='{new_state}' WHERE (id='{redact_id}')";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            //Обновляем DataGrid
        }

        //Метод заполнения грида
        public static BindingSource GetListUsers()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            //Запрос для вывода строк в БД
            string commandStr = "SELECT id_order AS 'Код', status AS 'Статус', FIO AS 'ФИО', numberphone AS 'Номер телефона', executor AS 'Исполнитель', price AS 'Стоимость', cause AS 'Дата приема', IMEI AS 'Серийный номер', conditione AS 'Состояние', device AS 'Название бренда', model AS 'Модель' , type_device AS 'Тип устройства', comm AS 'Комментарий' FROM zakaz";
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);         
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Закрываем соединение
            conn.Close();
            //Возвращаем bindingSource
            return bSource;
        }
        public static BindingSource GetClientList()
        {
            //Чистим виртуальную таблицу
            table4.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            //Запрос для вывода строк в БД
            string commandStr = "SELECT id_client AS 'Код', FIO AS 'ФИО', numberphone AS 'Номер телефона', password AS 'Паспорт' FROM client";
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table4);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource4.DataSource = table4;
            //Закрываем соединение
            conn.Close();
            //Возвращаем bindingSource
            return bSource4;
        }

        public static BindingSource GetPriceList()
        {
            //Чистим виртуальную таблицу
            table2.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            //Запрос для вывода строк в БД
            string commandStr = "SELECT id_price AS 'Код', job AS 'Название услуги/работы', time AS 'Еденица', norma AS 'Норма/ч', price AS 'Стоимость' FROM price";
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table2);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource2.DataSource = table2;
            //Закрываем соединение
            conn.Close();
            //Возвращаем bindingSource
            return bSource2;
        }

        public static BindingSource GetRoleList()
        {
            //Чистим виртуальную таблицу
            table3.Clear();
            // устанавливаем соединение с БД
            conn.Open();
            //Запрос для вывода строк в БД
            string commandStr = "SELECT id AS 'Код', fio AS 'ФИО', login AS 'Логин', password AS 'Пароль', role AS 'Уровень доступа' FROM auth";
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table3);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource3.DataSource = table3;
            //Закрываем соединение
            conn.Close();
            //Возвращаем bindingSource
            return bSource3;
        }
        public static void ReloadList()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListUsers();
        }
        public static void ReloadPriceList()
        {
            //Чистим виртуальную таблицу
            table2.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetPriceList();
        }
        public static void ReloadRoleList()
        {
            //Чистим виртуальную таблицу
            table3.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetRoleList();
        }
        public static void ReloadClientList()
        {
            //Чистим виртуальную таблицу
            table4.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetClientList();
        }

    }
}
