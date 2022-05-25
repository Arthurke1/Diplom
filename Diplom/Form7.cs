using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#EAE7DC");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.Text  = SomeClass.new_inserted_mainOrder_id;
            textBox2.Text = SomeClass.variable_class1;
            textBox3.Text = SomeClass.variable_class2;
            textBox4.Text = SomeClass.variable_class3;
            textBox5.Text = SomeClass.variable_class9;
            textBox6.Text = SomeClass.variable_class10;
            textBox7.Text = SomeClass.variable_class12;
            textBox8.Text = SomeClass.variable_class7;
            textBox9.Text = SomeClass.variable_class8;
            textBox10.Text = SomeClass.variable_class5;
            textBox11.Text = SomeClass.variable_class11;
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            var helper = new WordHelper("akt_priema_na_remont.docx");

            var items = new Dictionary<string, string>
            {
                {"<ID_ORDER>", textBox1.Text },
                {"<CAUSE>", textBox2.Text },
                {"<FIO>", textBox3.Text },
                {"<NUMBERPHONE>", textBox4.Text},
                {"<DEVICE>", textBox5.Text },
                {"<TYPE_DEVICE>", textBox6.Text },
                {"<MODEL>", textBox7.Text },
                {"<IMEI>", textBox8.Text },
                {"<CONDITIONE>", textBox9.Text },
                {"<PRICE>", textBox10.Text },
                {"<COMM>", textBox11.Text },
            };
            helper.Process(items);
        }
    }
}
