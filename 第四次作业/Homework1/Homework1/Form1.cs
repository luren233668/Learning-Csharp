using System;
using System.Windows.Forms;

namespace Homework1
{
    public partial class Form1 : Form
    {
        //保存闹铃时间和列表
        private AlarmClock _alarmClock;
        
        public Form1()
        {
            InitializeComponent();
            
            _alarmClock = new AlarmClock();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置DateTimePicker的格式为时间格式
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            
            //设置时间选择的自定义格式
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            
            //设置时间为当前时间
            dateTimePicker1.Value = DateTime.Now;
            
            //显示上下箭头
            dateTimePicker1.ShowUpDown = true;
            
            // 订阅 Tick 事件
            _alarmClock.Tick += (sender1, args) =>
            {
                label2.Text = "Tick...";
                
                // 更新 Label 控件显示当前时间
                UpdateCurrentTime();
            };

            // 订阅 Alarm 事件
            _alarmClock.Alarm += (sender1, args) =>
            {
                // 从闹钟列表中移除对应的闹钟
                RemoveAlarm();
                
                MessageBox.Show("Alarm!");
            };
            
            _alarmClock.Start();
        }

        private void RemoveAlarm()
        {
            // 从闹钟列表中移除对应的闹钟
            _alarmClock.AlarmList.RemoveAt(0);
            listBoxAlarms.Items.RemoveAt(0);
        }

        private void UpdateCurrentTime()
        {
            // 获取当前时间并更新 Label 控件的文本
            var currentTime = DateTime.Now.ToString("HH:mm:ss");
            label1.Text = "当前时间：" + currentTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取用户选择的日期和时间
            var selectedDateTime = dateTimePicker1.Value;

            // 增加闹钟
            if (selectedDateTime > DateTime.Now)
            {
                _alarmClock.AlarmList.Add(selectedDateTime);
                _alarmClock.AlarmList.Sort();
                MessageBox.Show("闹钟已设置为：" + selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                
                // 添加闹钟显示在 ListBox 控件中
                listBoxAlarms.Items.Add("闹钟时间：" + selectedDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                listBoxAlarms.Sorted = true;
            }
            else
            {
                MessageBox.Show("闹钟设置无效");
            }
        }
        
    }
}