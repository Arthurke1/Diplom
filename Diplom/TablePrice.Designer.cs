namespace Diplom
{
    partial class TablePrice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablePrice));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.konfFormStyle1 = new Diplom.konfFormStyle(this.components);
            this.yt_Button1 = new Diplom.yt_Button();
            this.yt_Button2 = new Diplom.yt_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yt_Button3 = new Diplom.yt_Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(781, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown_1);
            // 
            // konfFormStyle1
            // 
            this.konfFormStyle1.AllowUserResize = false;
            this.konfFormStyle1.ContextMenuForm = null;
            this.konfFormStyle1.ControlBoxButtonsWidth = 28;
            this.konfFormStyle1.Form = this;
            this.konfFormStyle1.FormStyle = Diplom.konfFormStyle.fStyle.none;
            // 
            // yt_Button1
            // 
            this.yt_Button1.BackColor = System.Drawing.Color.YellowGreen;
            this.yt_Button1.ForeColor = System.Drawing.Color.White;
            this.yt_Button1.Location = new System.Drawing.Point(12, 453);
            this.yt_Button1.Name = "yt_Button1";
            this.yt_Button1.RoundingEnable = true;
            this.yt_Button1.Size = new System.Drawing.Size(114, 50);
            this.yt_Button1.TabIndex = 1;
            this.yt_Button1.Text = "Добавить";
            this.yt_Button1.Click += new System.EventHandler(this.yt_Button1_Click);
            // 
            // yt_Button2
            // 
            this.yt_Button2.BackColor = System.Drawing.Color.Red;
            this.yt_Button2.ForeColor = System.Drawing.Color.White;
            this.yt_Button2.Location = new System.Drawing.Point(144, 453);
            this.yt_Button2.Name = "yt_Button2";
            this.yt_Button2.RoundingEnable = true;
            this.yt_Button2.Size = new System.Drawing.Size(119, 50);
            this.yt_Button2.TabIndex = 2;
            this.yt_Button2.Text = "Удалить";
            this.yt_Button2.Click += new System.EventHandler(this.yt_Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID выбранной устлуги:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Количество записей в таблице:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // yt_Button3
            // 
            this.yt_Button3.BackColor = System.Drawing.Color.Tomato;
            this.yt_Button3.ForeColor = System.Drawing.Color.White;
            this.yt_Button3.Location = new System.Drawing.Point(279, 453);
            this.yt_Button3.Name = "yt_Button3";
            this.yt_Button3.RoundingEnable = true;
            this.yt_Button3.Size = new System.Drawing.Size(119, 50);
            this.yt_Button3.TabIndex = 7;
            this.yt_Button3.Text = "Изменить";
            this.yt_Button3.Click += new System.EventHandler(this.yt_Button3_Click);
            // 
            // TablePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 515);
            this.Controls.Add(this.yt_Button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yt_Button2);
            this.Controls.Add(this.yt_Button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TablePrice";
            this.Text = "Список услуг";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private konfFormStyle konfFormStyle1;
        private yt_Button yt_Button2;
        private yt_Button yt_Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private yt_Button yt_Button3;
    }
}