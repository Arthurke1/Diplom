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
    public partial class TableOrder : Form
    {
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null

        string id_selected_rows = "0";
        static readonly string connStr = $"server=chuc.caseum.ru;port=33333;user=st_1_18_3;database=is_1_18_st3_VKR;password=77651256;";
        DataTable dbdataset;
        MySqlConnection conn = new MySqlConnection(connStr);
        //Метод получения ID выделенной строки, для последующего вызова его в нужных методах
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            //Указываем ID выделенной строки в метке
            toolStripLabel1.Text = id_selected_rows;
            ControlData.id_order = id_selected_rows;
        }

        //Выделение всей строки по ПКМ
        private void dataGridView1_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                //dataGridView1.CurrentRow.Selected = true;
                dataGridView1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }

        //Выделение всей строки по ЛКМ
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
            //Магические строки
            //dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            //dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
            listBox1.Items.Clear();
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
            GetListOrder(count_rows);
        }

        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetListUsers();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
        }

        public TableOrder()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }
        //События открытия (загрузки формы)
        private void Form5_Load(object sender, EventArgs e)
        {
            
            //Указываем, что источником данных ДатаГрида является bindingsource, возвращённый из метода класса 
            dataGridView1.DataSource = ControlData.GetListUsers();
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
            dataGridView1.Columns[0].FillWeight = 10;
            dataGridView1.Columns[1].FillWeight = 20;
            dataGridView1.Columns[2].FillWeight = 50;
            dataGridView1.Columns[3].FillWeight = 24;
            dataGridView1.Columns[4].FillWeight = 45;
            dataGridView1.Columns[5].FillWeight = 17;
            dataGridView1.Columns[6].FillWeight = 20;
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
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
            
        }

        //Вывод данных из БД в listBox1
        private void GetListOrder(int id_cpu)
        {
            conn.Open();
            //Строка запроса
            string commandStr = "SELECT * FROM zakaz WHERE id_order = " + id_selected_rows.ToString();
            //Команда для получения списка
            MySqlCommand cmd_get_list = new MySqlCommand(commandStr, conn);
            //Ридер для хранения списка строк
            MySqlDataReader reader_list = cmd_get_list.ExecuteReader();
            //Читаем ридер
            while (reader_list.Read())
            {
                listBox1.Items.Add("Статус: " + reader_list[1].ToString());
                listBox1.Items.Add("ФИО: " + reader_list[2].ToString());
                listBox1.Items.Add("Номер телефона: " + reader_list[3].ToString());
                listBox1.Items.Add("Исполнитель: " + reader_list[4].ToString());
                listBox1.Items.Add("Стоимость: " + reader_list[5].ToString() + " рублей");
                listBox1.Items.Add("Дата приема: " + reader_list[6].ToString());
                listBox1.Items.Add("IMEI: " + reader_list[7].ToString());
                listBox1.Items.Add("Состояние: " + reader_list[8].ToString());
                listBox1.Items.Add("Название бренда: " + reader_list[9].ToString());
                listBox1.Items.Add("Тип устройства: " + reader_list[10].ToString());
                listBox1.Items.Add("Комментарий: " + reader_list[11].ToString());
                listBox1.Items.Add("Модель: " + reader_list[12].ToString());
            }
            reader_list.Close();
            conn.Close();
        }
        //Кнопка удаления записи 
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {           
            ControlData.DeleteUser(id_selected_rows);
            //Метод обновления dataGridView.
            reload_list();
        }
        //Показывает ID выбранной записи
        private void выделенныйИДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(id_selected_rows);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
        
        //Кнопка обновления 
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Метод обновления dataGridView, так как он полностью обновляется, покраски строк не будет. 
            ControlData.ReloadList();
        }

        //переход на другую форму
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            EditOrder frm = new EditOrder();
            frm.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
          
        }

        //Фильтрация по ФИО
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {          
            ControlData.GetListUsers().Filter = "[ФИО] LIKE'" + toolStripTextBox1.Text + "%'";     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }
        //Фильтрация по Номеру телефона
        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            ControlData.GetListUsers().Filter = "[Номер телефона] LIKE'" + toolStripTextBox2.Text+"%'";
        }
        //Фитрация по Модели
        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            ControlData.GetListUsers().Filter = "[Модель] LIKE'" + toolStripTextBox3.Text + "%'";
        }
        //Фильрация по Типу устройства
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            ControlData.GetListUsers().Filter = "[Тип устройства] LIKE'" + toolStripComboBox1.Text + "%'";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
            toolStripTextBox2.Text = "";
            toolStripTextBox3.Text = "";
            toolStripComboBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
