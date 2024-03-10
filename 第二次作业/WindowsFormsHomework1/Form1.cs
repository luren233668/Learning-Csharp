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
            
            #region   初始化控件缩放
 
            x = Width;
            y = Height;
            SetTag(this);
 
            #endregion
        }
        
        private void SetButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
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
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }

        private float x; //定义当前窗体的宽度
        private float y; //定义当前窗体的高度
 
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0) SetTag(con);
            }
        }
 
        private void SetControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    var mytag = con.Tag.ToString().Split(';');
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(Convert.ToSingle(mytag[0]) * newx); //宽度
                    con.Height = Convert.ToInt32(Convert.ToSingle(mytag[1]) * newy); //高度
                    con.Left = Convert.ToInt32(Convert.ToSingle(mytag[2]) * newx); //左边距
                    con.Top = Convert.ToInt32(Convert.ToSingle(mytag[3]) * newy); //顶边距
                    var currentSize = Convert.ToSingle(mytag[4]) * newy; //字体大小                   
                    if (currentSize > 0) con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    con.Focus();
                    if (con.Controls.Count > 0) SetControls(newx, newy, con);
                }
        }
        
        private void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            SetControls(newx, newy, this);
 
        }
    }
}