using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHomework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            SetButtonStyle(button1);
            SetLabelStyle(label1);
            SetLabelStyle(label2);
            SetLabelStyle(label3);
            SetLabelStyle(label4);
            SetLabelStyle(label5);
        }
        
        private void SetButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.Transparent;
            button.BackColor = Color.Transparent;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button1_MouseHover(object sender, EventArgs eventArgs)
        {
            Button button = sender as Button;
            button.FlatAppearance.BorderSize = 1;
        }
        
        private void button1_MouseLeave(object sender, EventArgs eventArgs)
        {
            Button button = sender as Button;
            button.FlatAppearance.BorderSize = 0;
        }

        private void SetLabelStyle(Label label)
        {
            label.ForeColor = Color.Transparent;
            label.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var intArray = new int[6];
            
            for (int i = 0; i < 6; i++)
            {
                intArray[i] = random.Next(100);
            }

            label1.Text = "数组为：\n" + string.Join(" ", intArray);
            
            Array.Sort(intArray);
            label2.Text = "最大值为： " + intArray[5].ToString();
            label3.Text = "最小值为： " + intArray[0].ToString();

            int sum = 0;
            foreach (var i in intArray)
            {
                sum += i;
            }

            label4.Text = "平均值为： " + (sum / 6.0).ToString("f2");
            label5.Text = "和为： " + sum;
        }
    }
}