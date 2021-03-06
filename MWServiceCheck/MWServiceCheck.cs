using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace MWServiceCheck
{
    public partial class MWServiceCheck : ServiceBase
    {
        private int eventId = 1;
        private int WebServiceFail = 0;
        private int ConsoleServiceFail = 0;

        public static Services _servises = new Services();

        public MWServiceCheck()
        {
            InitializeComponent();
            //Инициализируем журнал службы
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("SourceMW"))
            {
                EventLog.CreateEventSource(
                    "SourceMW", "MWServiceCheckLog");
            }
            eventLog1.Source = "SourceMW";
            eventLog1.Log = "MWServiceCheckLog";
            InitializeServiceParams();
        }
        
        public void InitializeServiceParams()
        {
            string sFilePath = "C:\\\\Temp\\Settings.xml";
            if (File.Exists(sFilePath))
            {
                // получаем поток, и десериализуем обьект
                XmlSerializer xmlFormater = new XmlSerializer(typeof(Services));
                using (FileStream fs = new FileStream(sFilePath, FileMode.Open))
                    _servises = (Services)xmlFormater.Deserialize(fs);
            }
            else
            {
                //Инициализируем значения по умолчанию

                //Для Web Сервиса
                _servises.WEBserviceParams.ServiceType = 1;
                _servises.WEBserviceParams.ServiceName = "MyWEBservice";
                _servises.WEBserviceParams.ServicePath = "https://www.google.com/";
                _servises.WEBserviceParams.AttemptsQuantity = 3;
                _servises.WEBserviceParams.CheckInterval = 1;
                _servises.WEBserviceParams.CorrectState = 200;

                //Для Console Сервиса
                _servises.ConsoleServiceParams.ServiceType = 2;
                _servises.ConsoleServiceParams.ServiceName = "MyConsoleservice";
                _servises.ConsoleServiceParams.ServicePath = "C:\\\\Temp\\TestFile.mw";
                _servises.ConsoleServiceParams.AttemptsQuantity = 3;
                _servises.ConsoleServiceParams.CheckInterval = 1;
                _servises.ConsoleServiceParams.CorrectState = 2;
            }
            string serviceParam = $"{_servises.WEBserviceParams.ServiceName}; {_servises.WEBserviceParams.CheckInterval}";
            eventLog1.WriteEntry(serviceParam);
            serviceParam = $"{_servises.ConsoleServiceParams.ServiceName}; {_servises.ConsoleServiceParams.CheckInterval}";
            eventLog1.WriteEntry(serviceParam);
        }

        //Перезапуск Web сервиса
        private void RestartWebService()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(10000); //Задержка на ожидание сервиса
            ServiceController service = new ServiceController(_servises.WEBserviceParams.ServiceName);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        //Перезапуск Console сервиса
        private void RestartConsoleService()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(10000); //Задержка на ожидание сервиса
            ServiceController service = new ServiceController(_servises.ConsoleServiceParams.ServiceName);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        protected override void OnStart(string[] args)
        {
            //Инициализируем таймер переодического обнобления параметров сервиса, на случай, если файл настроек изменен вручную
            Timer timerUpdate= new Timer(); //Таймер проверки Web сервиса
            timerUpdate.Interval = 60000; //раз в 60 секунд
            timerUpdate.Elapsed += new ElapsedEventHandler(this.OnUpdateParams);
            timerUpdate.Start();
            //Инициализируем таймера запуска процессов проверки
            eventLog1.WriteEntry("Запускает процесса проверки Web службы.");
            //Запуск процесса проверки Web службы
            Timer timerWebServiceControll = new Timer(); //Таймер проверки Web сервиса
            timerWebServiceControll.Interval = _servises.WEBserviceParams.CheckInterval * 60000; //1000 = 1 seconds 1 минута 60000
            timerWebServiceControll.Elapsed += new ElapsedEventHandler(this.OnWebServiceControll);
            timerWebServiceControll.Start();

            //Запуск процесса проверки Console службы
            eventLog1.WriteEntry("Запускает процесса проверки Console службы.");
            Timer timerConsoleServiceControll = new Timer(); //Таймер проверки Web сервиса
            timerWebServiceControll.Interval = _servises.ConsoleServiceParams.CheckInterval * 60000; //1000 = 1 seconds 1 минута 60000
            timerWebServiceControll.Elapsed += new ElapsedEventHandler(this.OnConsoleServiceControll);
            timerWebServiceControll.Start();
        }

        //Обновление параметров сервиса
        public void OnUpdateParams(object sender, ElapsedEventArgs args)
        {
            InitializeServiceParams();
        }

            //Мониторинг Web сервиса
            public void OnWebServiceControll(object sender, ElapsedEventArgs args)
        {
            //Здесь будет мониторинг.
            eventLog1.WriteEntry("Monitoring Web сервиса запущен", EventLogEntryType.Information, eventId++);
            HttpClient WebClient = new HttpClient();
            int checkResult = (int) WebClient.GetAsync(_servises.WEBserviceParams.ServicePath).Result.StatusCode;

            if (checkResult != _servises.WEBserviceParams.CorrectState)
            {
                WebServiceFail++;
                eventLog1.WriteEntry($"{checkResult} != {_servises.WEBserviceParams.CorrectState}, {WebServiceFail} раз", EventLogEntryType.Information, eventId++);
            }    
                

            if(WebServiceFail >= _servises.WEBserviceParams.AttemptsQuantity)
            {
                eventLog1.WriteEntry($"Перезапуск Web сервиса", EventLogEntryType.Information, eventId++);
                WebServiceFail = 0;
                RestartWebService();
            }                
        }

        //Мониторинг Console сервиса
        public void OnConsoleServiceControll(object sender, ElapsedEventArgs args)
        {
            //Здесь будет мониторинг.
            eventLog1.WriteEntry("Monitoring Console сервиса запущен", EventLogEntryType.Information, eventId++);
            DateTime lastModified = System.IO.File.GetLastWriteTime(_servises.ConsoleServiceParams.ServicePath);
            TimeSpan timeDiff = DateTime.Now.Subtract(lastModified);
            int dTimeDiff = int.Parse(timeDiff.ToString("mm"));

            if (dTimeDiff >= _servises.ConsoleServiceParams.CorrectState)
            {
                ConsoleServiceFail++;
                eventLog1.WriteEntry($"{dTimeDiff} >= {_servises.ConsoleServiceParams.CorrectState}, {ConsoleServiceFail} раз", EventLogEntryType.Information, eventId++);
            }    
                

            if (ConsoleServiceFail >= _servises.ConsoleServiceParams.AttemptsQuantity)
            {
                eventLog1.WriteEntry($"Перезапуск Console сервиса", EventLogEntryType.Information, eventId++);
                ConsoleServiceFail = 0;
                RestartConsoleService();
            }
                
        }

        protected override void OnStop()
        {
            //Отслеживаем остановку службы 
            eventLog1.WriteEntry("Служба мониторинка остановлена.");
        }

        protected override void OnContinue()
        {
            //Отслеживаем запуск службы 
            eventLog1.WriteEntry("Служба мониторинка запущена.");
            //При перезапуске перечитываем параметры сервиса
            InitializeServiceParams();
        }
    }
}
