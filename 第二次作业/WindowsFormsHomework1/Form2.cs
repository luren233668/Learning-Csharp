using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsHomework1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            //初始化控件样式
            #region InitalizeStyle

            SetLabelStyle(label1);
            SetTextBoxStyle(textBox1);
            SetTextBoxStyle(textBox2);
            SetButtonStyle(button2);
            
            #endregion
            
            //初始化控件缩放
            #region  InitializeResize
 
            x = Width;
            y = Height;
            SetTag(this);
 
            #endregion
        }

        //设置控件样式
        #region SetStyle

        private void SetLabelStyle(Label label)
        {
            label.BackColor = Color.Transparent;
        }

        private void SetTextBoxStyle(TextBox textBox)
        {
            textBox.Size = new Size(180, 30);
        }
        
        private void SetButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.Transparent;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button2_MouseHover(object sender, EventArgs eventArgs)
        {
            Button button = sender as Button;
            button.FlatAppearance.BorderSize = 1;
        }
        
        private void button2_MouseLeave(object sender, EventArgs eventArgs)
        {
            Button button = sender as Button;
            button.FlatAppearance.BorderSize = 0;
        }
        
        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            // 清空文本框内容
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "下限：")
            {
                textBox.Text = "";
            }
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            // 如果文本框为空，恢复提示文本
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "下限：";
            }
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            // 清空文本框内容
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "上限：")
            {
                textBox.Text = "";
            }
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            // 如果文本框为空，恢复提示文本
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "上限：";
            }
        }

        #endregion

        //处理输入并输出

        #region UseDataAndOut
        
        //合法性检验
        private bool ValidateInput(string lowerLimitText, string upperLimitText, out int lowerLimit, out int upperLimit)
        {
            // 初始化输出参数
            lowerLimit = 0;
            upperLimit = 0;

            // 检验是否为空
            if (string.IsNullOrWhiteSpace(lowerLimitText) || string.IsNullOrWhiteSpace(upperLimitText))
            {
                MessageBox.Show("请输入有效的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 检验是否为整数
            if (!int.TryParse(lowerLimitText, out lowerLimit) || !int.TryParse(upperLimitText, out upperLimit))
            {
                MessageBox.Show("请输入有效的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 检验是否为正数
            if (lowerLimit <= 0 || upperLimit <= 0)
            {
                MessageBox.Show("请输入正整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 检验上下限关系
            if (lowerLimit >= upperLimit)
            {
                MessageBox.Show("上限必须大于下限！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 合法性检验通过
            return true;
        }
        
        //生成素数列表
        private List<int> GeneratePrimeNumbers(int lowerLimit, int upperLimit)
        {
            List<int> primes = new List<int>();

            for (int i = lowerLimit; i <= upperLimit; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        //判断是否为素数
        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        
        #endregion
        
        //计算符合条件的素数
        private void button2_Click(object sender, EventArgs e)
        {
            // 调用合法性检验函数
            if (ValidateInput(textBox1.Text, textBox2.Text, out int lowerLimit, out int upperLimit))
            {
                // 合法性检验通过，可以继续处理
                // 生成素数并显示在文本框中
                var primeNumbers = GeneratePrimeNumbers(lowerLimit, upperLimit);
                // 将素数按每行10个的方式显示在文本框中
                DisplayPrimeNumbersInRows(primeNumbers, 10);
            }
        }
        
        private void DisplayPrimeNumbersInRows(List<int> primeNumbers, int numbersPerRow)
        {
            // 清空文本框
            richTextBox1.Clear();

            // 使用StringBuilder构建输出字符串
            StringBuilder outputBuilder = new StringBuilder();

            for (int i = 0; i < primeNumbers.Count; i++)
            {
                // 添加素数到StringBuilder
                outputBuilder.Append(primeNumbers[i]);

                // 添加分隔符（逗号和空格），除非是该行的最后一个数字
                if (i % numbersPerRow != numbersPerRow - 1 && i < primeNumbers.Count - 1)
                {
                    outputBuilder.Append(", ");
                }
                else
                {
                    // 在达到每行限制或是最后一个数字时，添加换行符
                    outputBuilder.AppendLine();
                }
            }

            // 将StringBuilder中的内容显示在文本框中
            richTextBox1.Text = outputBuilder.ToString();
        }
        
        //设置窗口缩放
        private void Form2_Resize(object sender, EventArgs e)
        {
            //重置窗口布局
            ReWinformLayout();
        }
        
        //实现控件大小随窗体大小等比例缩放
        #region ResizeUI
        
        private float x; //定义当前窗体的宽度
        private float y; //定义当前窗体的高度
 
        //获取并保留所有控件的属性
        private static void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }
 
        private static void SetControls(float newx, float newy, Control cons)
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
                    if (currentSize > 0)
                    {
                        con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    }
                    con.Focus();
                    if (con.Controls.Count > 0)
                    {
                        SetControls(newx, newy, con);
                    }
                }
        }
        
        private void ReWinformLayout()
        {
            var newx = Width / x;
            var newy = Height / y;
            SetControls(newx, newy, this);
 
        }
        
        #endregion
    }
}