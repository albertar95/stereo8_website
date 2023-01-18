using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SyncDbs
{
    partial class SyncDbService : ServiceBase
    {
        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer DayCounterTimer;
        public SyncDbService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new System.Timers.Timer(600000); // 10 minutes
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private void OnDayTimedEvent(object? sender, ElapsedEventArgs e)
        {
            aTimer = new System.Timers.Timer(600000); // 10 minutes
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            if(DateTime.Now.Hour >= 17 && DateTime.Now.Hour < 18)
            {
                using (AppActions appActions = new AppActions())
                {
                    appActions.Execute();
                }
                DateTime t1 = DateTime.Today.AddDays(1).AddHours(16).AddMinutes(51);
                var diff = Math.Ceiling((t1 - DateTime.Now).TotalMilliseconds);
                DayCounterTimer = new System.Timers.Timer(diff); // 1 day
                DayCounterTimer.Elapsed += new ElapsedEventHandler(OnDayTimedEvent);
                DayCounterTimer.Enabled = true;
                var timer = (System.Timers.Timer)sender;
                timer.Dispose();
            }
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            DayCounterTimer.Stop();
        }
    }
}
