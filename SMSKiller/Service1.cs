using System;
using System.ServiceProcess;
using System.Timers;

namespace SMSKiller
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += OnTimerOnElapsed;
            timer.Interval = 15000;
            timer.Enabled = true;
        }

        private void OnTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (IsWithinOfficeHours())
            {
                var smsAgentHostService = new ServiceController("CcmExec");
                if (smsAgentHostService.Status != ServiceControllerStatus.Stopped)
                {
                    smsAgentHostService.Stop();
                }
            }
        }

        private static bool IsWithinOfficeHours()
        {
            var now = DateTime.Now;

            var isWeekDay = now.DayOfWeek == DayOfWeek.Monday
                            || now.DayOfWeek == DayOfWeek.Tuesday
                            || now.DayOfWeek == DayOfWeek.Wednesday
                            || now.DayOfWeek == DayOfWeek.Thursday
                            || now.DayOfWeek == DayOfWeek.Friday;

            var isWorkHours = now.Hour >= 7 && now.Hour <= 19;

            return isWeekDay && isWorkHours;
        }

        protected override void OnStop()
        {
        }
    }
}
