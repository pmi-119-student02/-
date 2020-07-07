using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace летняя_практика
{
    public partial class Form1 : Form
    {
        private  List<float> x, y;
        private float sumx, sumxy, sumy, sumx2, sumpr;
        private float a, b;

        private void button1_Click(object sender, EventArgs e)

        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                x.Add((float)Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value));
                y.Add((float)Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));
            }

            sumx = 0; 
            sumy = 0; 
            sumxy = 0; 
            sumx2 = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sumx += x[i];
                sumy += y[i];
                sumxy += x[i] * y[i];
                sumx2 += x[i] * x[i];
            }
            a = (x.Count * sumxy - sumx * sumy) /(x.Count * sumx2 - sumx * sumx);
            b = (sumy - a * sumx) / x.Count;
            for (int i = 0; i < x.Count; i++)
            {
                sumpr += ((y[i] - (a * x[i] + b)) * (y[i] - (a * x[i] + b)));
                    }
            textBox1.Text = Convert.ToString(sumpr);
            label1.Text = "y = " + a + "x + " + b;
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            x = new List<float>();
            y = new List<float>();
            dataGridView1.ColumnCount = 2;
            label1.Text = null;
            textBox1.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x.Clear(); 
            y.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 2;
            label1.Text = null;
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
