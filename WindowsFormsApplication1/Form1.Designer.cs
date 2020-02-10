namespace Kuras
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surpass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apmoketa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.virsytas_limitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vidurkis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kmGPs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.litrai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likpr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.likpab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.surname,
            this.card,
            this.surpass,
            this.city,
            this.number,
            this.model});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(9, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(562, 581);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.HeaderText = "Vardas";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 65;
            // 
            // surname
            // 
            this.surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.surname.HeaderText = "Pavarde";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            this.surname.Width = 72;
            // 
            // card
            // 
            this.card.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.card.HeaderText = "Kortele";
            this.card.Name = "card";
            this.card.ReadOnly = true;
            this.card.Width = 65;
            // 
            // surpass
            // 
            this.surpass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.surpass.HeaderText = "Limitas";
            this.surpass.Name = "surpass";
            this.surpass.ReadOnly = true;
            this.surpass.Width = 64;
            // 
            // city
            // 
            this.city.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.city.HeaderText = "Miestas";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            this.city.Width = 68;
            // 
            // number
            // 
            this.number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.number.HeaderText = "Numeris";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 70;
            // 
            // model
            // 
            this.model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.model.HeaderText = "Modelis";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Width = 68;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.Location = new System.Drawing.Point(415, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ištrinti Vartotoją";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.button3.Location = new System.Drawing.Point(122, 636);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Print Skolingi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // searchBox
            // 
            this.searchBox.AccessibleDescription = "";
            this.searchBox.AccessibleName = "";
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.searchBox.Location = new System.Drawing.Point(9, 10);
            this.searchBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(121, 24);
            this.searchBox.TabIndex = 5;
            this.searchBox.Tag = "";
            // 
            // button4
            // 
            this.button4.AccessibleDescription = "";
            this.button4.Location = new System.Drawing.Point(134, 10);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.data,
            this.suma,
            this.apmoketa,
            this.virsytas_limitas,
            this.limit,
            this.vidurkis,
            this.km,
            this.kmGPs,
            this.litrai,
            this.likpr,
            this.likpab});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Location = new System.Drawing.Point(577, 38);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView2.Size = new System.Drawing.Size(569, 581);
            this.dataGridView2.TabIndex = 8;
            // 
            // data
            // 
            this.data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.Width = 55;
            // 
            // suma
            // 
            this.suma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.suma.HeaderText = "Suma";
            this.suma.Name = "suma";
            this.suma.ReadOnly = true;
            this.suma.Width = 59;
            // 
            // apmoketa
            // 
            this.apmoketa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.apmoketa.HeaderText = "Apmok.";
            this.apmoketa.Name = "apmoketa";
            this.apmoketa.ReadOnly = true;
            this.apmoketa.Width = 68;
            // 
            // virsytas_limitas
            // 
            this.virsytas_limitas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.virsytas_limitas.HeaderText = "Virs.Lim.";
            this.virsytas_limitas.Name = "virsytas_limitas";
            this.virsytas_limitas.ReadOnly = true;
            this.virsytas_limitas.Width = 71;
            // 
            // limit
            // 
            this.limit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.limit.HeaderText = "Limitas";
            this.limit.Name = "limit";
            this.limit.ReadOnly = true;
            this.limit.Width = 64;
            // 
            // vidurkis
            // 
            this.vidurkis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.vidurkis.HeaderText = "L/100km";
            this.vidurkis.Name = "vidurkis";
            this.vidurkis.ReadOnly = true;
            this.vidurkis.Width = 75;
            // 
            // km
            // 
            this.km.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.km.HeaderText = "km";
            this.km.Name = "km";
            this.km.ReadOnly = true;
            this.km.Width = 46;
            // 
            // kmGPs
            // 
            this.kmGPs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.kmGPs.HeaderText = "km GPS";
            this.kmGPs.Name = "kmGPs";
            this.kmGPs.ReadOnly = true;
            this.kmGPs.Width = 71;
            // 
            // litrai
            // 
            this.litrai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.litrai.HeaderText = "Litrai";
            this.litrai.Name = "litrai";
            this.litrai.ReadOnly = true;
            this.litrai.Width = 54;
            // 
            // likpr
            // 
            this.likpr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.likpr.HeaderText = "Lik. Pr";
            this.likpr.MinimumWidth = 2;
            this.likpr.Name = "likpr";
            this.likpr.ReadOnly = true;
            this.likpr.Width = 62;
            // 
            // likpab
            // 
            this.likpab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.likpab.HeaderText = "Lik. Pab";
            this.likpab.MinimumWidth = 2;
            this.likpab.Name = "likpab";
            this.likpab.ReadOnly = true;
            this.likpab.Width = 71;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(753, 13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 21);
            this.button6.TabIndex = 9;
            this.button6.Text = "Rodyti Pylimus";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(349, 635);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(91, 41);
            this.button7.TabIndex = 10;
            this.button7.Text = "Formuoti ataskaitą";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "asdasd",
            "asdasdasd",
            "as",
            "d",
            "asdasd",
            "12313",
            "asd"});
            this.comboBox1.Location = new System.Drawing.Point(193, 13);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.Text = "Visi";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Gainsboro;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button8.FlatAppearance.BorderSize = 3;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(241, 635);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(103, 41);
            this.button8.TabIndex = 12;
            this.button8.Text = "Pasirinkti Pylimų failą";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button9.Location = new System.Drawing.Point(11, 636);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(107, 40);
            this.button9.TabIndex = 12;
            this.button9.Text = "Print";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(526, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Naujas Vartotojas";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(634, 11);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(113, 22);
            this.button10.TabIndex = 14;
            this.button10.Text = "Redaguoti Vartotoją";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1198, 691);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Kuras";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn card;
        private System.Windows.Forms.DataGridViewTextBoxColumn surpass;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn suma;
        private System.Windows.Forms.DataGridViewTextBoxColumn apmoketa;
        private System.Windows.Forms.DataGridViewTextBoxColumn virsytas_limitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn limit;
        private System.Windows.Forms.DataGridViewTextBoxColumn vidurkis;
        private System.Windows.Forms.DataGridViewTextBoxColumn km;
        private System.Windows.Forms.DataGridViewTextBoxColumn kmGPs;
        private System.Windows.Forms.DataGridViewTextBoxColumn litrai;
        private System.Windows.Forms.DataGridViewTextBoxColumn likpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn likpab;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button10;
    }
}

