using MailSender.Lib.Entity;
using MailSender.Lib.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace MailSender.Lib
{
    public class MailSheduler
    {
        List<MailTask> Tasks;
        DispatcherTimer timer;

        public event Action<SentState> MailIsSend;

        public MailSheduler()
        {
            Tasks = new List<MailTask>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        /// <summary>
        /// Работа по расписанию, обработка задач
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            var list = from t in Tasks
                       where t.IsActual
                       where t.IsTime()
                       select t;
            SentState resultState;
            foreach (var item in list)
            {
                resultState = item.DoTask();
                MailIsSend?.Invoke(resultState);
            }
            Tasks.RemoveAll((r) => !r.IsActual);
        }
        /// <summary>
        /// Добавить задачу в рассмотрение
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(SheduledTask task)
        {
            Tasks.Add(task.ToTask());
        }

    }
}
