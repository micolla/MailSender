using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MailSender.Lib
{
    public class MailSheduler
    {
        List<Task> Tasks;
        DispatcherTimer timer;

        public event Action<SentState> MailIsSend;

        public MailSheduler(List<Task> tasks)
        {
            Tasks = tasks;
        }
        public MailSheduler()
        {
            Tasks = new List<Task>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromDays(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var list = from t in Tasks
                       where t.IsTime()
                       select t;
            SentState resultState;
            foreach (var item in list)
            {
                resultState = item.DoTask();
                MailIsSend?.Invoke(resultState);
            }
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

    }
}
