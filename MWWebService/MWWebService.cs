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

namespace MWWebService
{
    public partial class MWWebService : ServiceBase
    {
        private int eventId = 1;

        public MWWebService()
        {
            InitializeComponent();
            //Инициализируем журнал службы
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("SourceWebMW"))
            {
                EventLog.CreateEventSource(
                    "SourceWebMW", "MWWebServiceLog");
            }
            eventLog1.Source = "SourceWebMW";
            eventLog1.Log = "MWWebServiceLog";
        }

        protected override void OnStart(string[] args)
        {
            //Инициализируем таймер запуска процесса проверки
            eventLog1.WriteEntry("In OnStart.");
            Timer timer = new Timer();
            timer.Interval = 120000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            //Здесь будет мониторинг.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }

        protected override void OnStop()
        {
            //Отслеживаем остановку службы 
            eventLog1.WriteEntry("In OnStop.");
        }

        protected override void OnContinue()
        {
            //Отслеживаем запуск службы 
            eventLog1.WriteEntry("In OnContinue.");
        }
    }
}
