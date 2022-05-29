namespace Diplom
{
    partial class TableRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableRole));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yt_Button2 = new Diplom.yt_Button();
            this.yt_Button1 = new Diplom.yt_Button();
            this.konfFormStyle1 = new Diplom.konfFormStyle(this.components);
            this.yt_Button3 = new Diplom.yt_Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yt_Button4 = new Diplom.yt_Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 390);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(735, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(735, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Нажмите на строку";
            // 
            // yt_Button2
            // 
            this.yt_Button2.BackColor = System.Drawing.Color.Red;
            this.yt_Button2.ForeColor = System.Drawing.Color.White;
            this.yt_Button2.Location = new System.Drawing.Point(150, 428);
            this.yt_Button2.Name = "yt_Button2";
            this.yt_Button2.RoundingEnable = true;
            this.yt_Button2.Size = new System.Drawing.Size(119, 50);
            this.yt_Button2.TabIndex = 4;
            this.yt_Button2.Text = "Удалить";
            this.yt_Button2.Click += new System.EventHandler(this.yt_Button2_Click);
            // 
            // yt_Button1
            // 
            this.yt_Button1.BackColor = System.Drawing.Color.YellowGreen;
            this.yt_Button1.ForeColor = System.Drawing.Color.White;
            this.yt_Button1.Location = new System.Drawing.Point(12, 428);
            this.yt_Button1.Name = "yt_Button1";
            this.yt_Button1.RoundingEnable = true;
            this.yt_Button1.Size = new System.Drawing.Size(119, 50);
            this.yt_Button1.TabIndex = 3;
            this.yt_Button1.Text = "Добавить";
            this.yt_Button1.Click += new System.EventHandler(this.yt_Button1_Click);
            // 
            // konfFormStyle1
            // 
            this.konfFormStyle1.AllowUserResize = false;
            this.konfFormStyle1.ContextMenuForm = null;
            this.konfFormStyle1.ControlBoxButtonsWidth = 28;
            this.konfFormStyle1.Form = this;
            this.konfFormStyle1.FormStyle = Diplom.konfFormStyle.fStyle.none;
            // 
            // yt_Button3
            // 
            this.yt_Button3.BackColor = System.Drawing.Color.SteelBlue;
            this.yt_Button3.ForeColor = System.Drawing.Color.White;
            this.yt_Button3.Location = new System.Drawing.Point(288, 428);
            this.yt_Button3.Name = "yt_Button3";
            this.yt_Button3.RoundingEnable = true;
            this.yt_Button3.Size = new System.Drawing.Size(119, 50);
            this.yt_Button3.TabIndex = 5;
            this.yt_Button3.Text = "Обновить";
            this.yt_Button3.Click += new System.EventHandler(this.yt_Button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Количество пользователей:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(572, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Id выбранного пользователя:";
            // 
            // yt_Button4
            // 
            this.yt_Button4.BackColor = System.Drawing.Color.Tomato;
            this.yt_Button4.ForeColor = System.Drawing.Color.White;
            this.yt_Button4.Location = new System.Drawing.Point(422, 428);
            this.yt_Button4.Name = "yt_Button4";
            this.yt_Button4.RoundingEnable = true;
            this.yt_Button4.Size = new System.Drawing.Size(119, 50);
            this.yt_Button4.TabIndex = 8;
            this.yt_Button4.Text = "Изменить";
            this.yt_Button4.Click += new System.EventHandler(this.yt_Button4_Click);
            // 
            // TableRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.yt_Button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yt_Button3);
            this.Controls.Add(this.yt_Button2);
            this.Controls.Add(this.yt_Button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableRole";
            this.Text = "Управление пользователями";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private konfFormStyle konfFormStyle1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private yt_Button yt_Button2;
        private yt_Button yt_Button1;
        private yt_Button yt_Button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private yt_Button yt_Button4;
    }
}