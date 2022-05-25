﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Form2 : Form
    {
        public Form2()
        {
           
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }

        //Метод расстановки функционала формы взависимости от роли пользователя, которая передается посредством  поля класса,
        //в которое данное значени в свою очередь попало из запроса
        public void ManagerRole(int role)
        {
            switch (role)
            {
                //И в зависимости от того, какая роль (цифра) хранится в поле класса и передана в метод, показываются те или иные кнопки.
                //Вы можете скрыть их и не отображать вообще, здесь они просто выключены
                case 1:
                    label5.Text = "Администратор";
                    label5.ForeColor = Color.Red;
                    yt_Button1.Enabled = true;
                    yt_Button2.Enabled = true;
                    yt_Button3.Enabled = true;
                    yt_Button4.Enabled = true;
                    yt_Button5.Enabled = true;

                    break;
                case 2:
                    label5.Text = "Мастер";
                    label5.ForeColor = Color.Green;
                    yt_Button1.Visible = true;
                    yt_Button2.Visible = false;
                    yt_Button3.Visible = true;
                    yt_Button5.Visible = false;
               
                    break;
                case 3:
                    label5.Text = "Минимальный";
                    label5.ForeColor = Color.Yellow;
                    yt_Button1.Enabled = false;
                    yt_Button2.Enabled = false;
                    yt_Button3.Enabled = true;
                    break;
                //Если по какой то причине в классе ничего не содержится, то всё отключается вообще
                default:
                    label5.Text = "Неопределённый";
                    label5.ForeColor = Color.Red;
                    yt_Button1.Enabled = false;
                    yt_Button2.Enabled = false;
                    yt_Button3.Enabled = false;
                    break;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {        
                //Вытаскиваем из класса поля в label'ы
                label1.Text = Auth.auth_id;
                label2.Text = Auth.auth_fio;
                //Вызываем метод управления ролями
                ManagerRole(Auth.auth_role);
        }

      

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            // переход на другую форму
            Form5 frm = new Form5();
            frm.Show();
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            // переход на другую форму
            Form4 frm = new Form4();
            frm.Show();
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            // переход на другую форму
            Form6 frm = new Form6();
            frm.Show();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            this.Close(); //Закрываем форму
        }

        private void yt_Button5_Click(object sender, EventArgs e)
        {
            // переход на другую форму
            Form9 frm = new Form9();
            frm.Show();
        }
    }
}
