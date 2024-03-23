using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Homework1
{
    public class AlarmClock
    {
        // 闹铃时间的列表
        public List<DateTime> AlarmList { get; set; }
        
        //声明两个事件
        public event EventHandler Tick;
        public event EventHandler Alarm;

        //设置计时器
        private readonly Timer _timer;

        public AlarmClock()
        {
            _timer = new Timer();
            _timer.Interval = 1000; // 设置定时器的间隔为1秒（1000毫秒）
            _timer.Tick += Timer_Tick;

            AlarmList = new List<DateTime>();
        }
        protected virtual void OnTick(EventArgs e)
        {
            Tick?.Invoke(this, e);
        }

        protected virtual void OnAlarm(EventArgs e)
        {
            Alarm?.Invoke(this, e);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
                // 触发 Tick 事件
                OnTick(EventArgs.Empty);

                // 如果当前时间等于闹钟时间，则触发 Alarm 事件
                try
                {
                    var alarmTime = AlarmList.First();
                    if (DateTime.Now.Year == alarmTime.Year &&
                        DateTime.Now.Month == alarmTime.Month &&
                        DateTime.Now.Day == alarmTime.Day &&
                        DateTime.Now.Hour == alarmTime.Hour &&
                        DateTime.Now.Minute == alarmTime.Minute &&
                        DateTime.Now.Second == alarmTime.Second)
                    {
                        OnAlarm(EventArgs.Empty);
                    }
                }
                catch (Exception exception)
                {
                    
                }
        }
        
        public void Start()
        {
            _timer.Start();
        }
    }
}