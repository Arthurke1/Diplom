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
    public partial class TableRole : Form
    {
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";

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
            label2.Text = id_selected_rows;
            ControlData.id_role = id_selected_rows;
        }
        //Метод обновления DataGreed
        public void ReloadRoleList()
        {
            //Чистим виртуальную таблицу внутри класса
            ControlData.ReloadRoleList();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            ControlData.GetRoleList();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;
            label1.Text = (count_rows).ToString();
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
        }


        public TableRole()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            {
                //Указываем, что источником данных ДатаГрида является bindingsource, возвращённый из метода класса 
                dataGridView1.DataSource = ControlData.GetRoleList();

                //Видимость полей в гриде
                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = true;
           //     dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[3].Visible = true;


                //Ширина полей
                dataGridView1.Columns[0].FillWeight = 10;
                dataGridView1.Columns[1].FillWeight = 40;
            //    dataGridView1.Columns[2].FillWeight = 13;
                dataGridView1.Columns[3].FillWeight = 15;

                //Режим для полей "Только для чтения"
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
             //   dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;

                //Растягивание полей грида
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             //   dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //Убираем заголовки строк
                dataGridView1.RowHeadersVisible = false;
                //Показываем заголовки столбцов
                dataGridView1.ColumnHeadersVisible = true;
                //Вызываем метод покраски ДатаГрид
                //ChangeColorDGV();
                int count_rows = dataGridView1.RowCount - 1;
                label1.Text = (count_rows).ToString();
            }
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            //Метод удаления
            ControlData.DeleteRole(id_selected_rows);
            ReloadRoleList();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            // переход на другую форму
            AddRole frm = new AddRole();
            frm.Show();
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            //Метод обновления dataGridView, так как он полностью обновляется, покраски строк не будет. 
            ControlData.ReloadRoleList();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            // переход на другую форму
            EditRole frm = new EditRole();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
