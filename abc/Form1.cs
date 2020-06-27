using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        struct Employee
        {
            public string FIO;
            public string Post;
            public string birthdate;
            public int Experience;
            public string ychst;
            public Employee(string f, string p, string d,string c, int e)
            { FIO = f;Post = p; birthdate = d; ychst = c; Experience = e; }
        }
        Employee[] worker = new Employee[10];
        int cout = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Преподаватель");
            comboBox1.Items.Add("Ст.Преподаватель");
            comboBox1.Items.Add("Доцент");
            comboBox1.Items.Add("Профессор");
            comboBox2.Items.Add("Без уч.степени");
            comboBox2.Items.Add("Кандидат наук");
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "ФИО";
            dataGridView1.Columns[1].HeaderText = "Должность";
            dataGridView1.Columns[2].HeaderText = "Дата рождения";
            dataGridView1.Columns[3].HeaderText = "Ученая степень";
            dataGridView1.Columns[4].HeaderText = "Стаж";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].HeaderText = "ФИО";
            dataGridView2.Columns[1].HeaderText = "Должность";
            dataGridView2.Columns[2].HeaderText = "Дата рождения";
            dataGridView2.Columns[3].HeaderText = "Ученая степень";
            dataGridView2.Columns[4].HeaderText = "Стаж";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                worker[cout].FIO = textBox1.Text;
                worker[cout].Post = comboBox1.Text;
                worker[cout].birthdate = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                worker[cout].Experience = Convert.ToInt32(textBox2.Text);
                worker[cout].ychst = comboBox2.Text;
                dataGridView1.Rows.Add(worker[cout].FIO, worker[cout].Post, worker[cout].birthdate, worker[cout].ychst, worker[cout].Experience.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked == false && radioButton2.Checked == false) || (textBox3.Text == ""))
            {
                MessageBox.Show("Выбирите критерий и заполните поле");

            }
            else
            {
                if (radioButton1.Checked)
                {
                    dataGridView2.Rows.Clear();
                    int select1 = Convert.ToInt32(textBox3.Text);
                    foreach (Employee wSel in worker)
                    {
                        if (wSel.Experience >= select1)
                        {
                            dataGridView2.Rows.Add(wSel.FIO, wSel.Post, wSel.birthdate, wSel.ychst, wSel.Experience.ToString());
                        }
                    }
                }
                if (radioButton2.Checked)
                {
                    dataGridView2.Rows.Clear();
                    string select2 = textBox3.Text;
                    foreach (Employee wSel in worker)
                    {
                        if (wSel.Post == select2)
                        {
                            dataGridView2.Rows.Add(wSel.FIO, wSel.Post, wSel.birthdate, wSel.ychst, wSel.Experience);
                        }
                    }
                }
                if (dataGridView2.Rows[0].Cells[0].Value == null) { MessageBox.Show("Данные не удовлетворяют условию"); }
               
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
