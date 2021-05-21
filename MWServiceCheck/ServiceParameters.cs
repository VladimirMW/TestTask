using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWServiceCheck
{
    //Класс параметров для сервисов WEB и Console
    public class ServiceParameters
    {
        public int ServiceType { get; set; } //Тип сервиса (WEB/Console)
        public string ServiceName { get; set; } //Название сервиса
        public string ServicePath { get; set; } //Адрес (для WEB), файл-флаг и путь к нему (для Console)
        public int AttemptsQuantity { get; set; } //Количество попыток, после которых считаем что сервис «завис»
        public int CheckInterval { get; set; } //Интервал проверки (различный для каждого сервиса)
        public int CorrectState { get; set; } //Статус (для WEB) который считается корректным ответом для сервиса, «Возраст» файла-флага в минутах (для Console)
    }

    //Для быстрой сериализации/десериализации создадим клас объединяющи параметры для обоих сервисов
    [Serializable]
    public class Services
    {
        public ServiceParameters WEBserviceParams = new ServiceParameters();
        public ServiceParameters ConsoleServiceParams = new ServiceParameters();
    }
}
