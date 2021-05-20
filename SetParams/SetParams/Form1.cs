using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace SetParams
{    
    public partial class FormServiceParams : Form
    {  
        public static Services _servises = new Services();

        public FormServiceParams()
        {
            InitializeComponent();
            InitializeServiceParams();
            InitializeElements();
        }

        public static void InitializeServiceParams()
        {
            string sFilePath = "C:\\\\Temp\\Settings.xml";
            if(File.Exists(sFilePath))
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
        }

        public void InitializeElements()
        {
            comboBoxServiceType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxServiceType.SelectedItem = "WEB";
            textBoxAttemptsQuantity.Text = _servises.WEBserviceParams.AttemptsQuantity.ToString();
            textBoxCheckInterval.Text = _servises.WEBserviceParams.CheckInterval.ToString();
            textBoxCorrectState.Text = _servises.WEBserviceParams.CorrectState.ToString();
            textBoxServiceName.Text = _servises.WEBserviceParams.ServiceName;
            textBoxServicePath.Text = _servises.WEBserviceParams.ServicePath;
        }

        //Разрешаем ввод только символов textBoxAttemptsQuantity
        private void textBoxAttemptsQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;            
        }

        //Разрешаем ввод только символов textBoxCheckInterval
        private void textBoxCheckInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;            
        }

        //Разрешаем ввод только символов textBoxCorrectState
        private void textBoxCorrectState_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void comboBoxServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadParamToForm();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            saveParamsFromForm();
            //Добавить перезапуск сервиса
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveParamsFromForm();
            //Добавить перезапуск сервиса
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadParamToForm();
        }
        //Сохраняем новые параметры в объек и файл
        private void saveParamsFromForm()
        {
            if(comboBoxServiceType.SelectedItem.ToString() == "WEB")
            {
                _servises.WEBserviceParams.AttemptsQuantity = int.Parse(textBoxAttemptsQuantity.Text);
                _servises.WEBserviceParams.CheckInterval = int.Parse(textBoxCheckInterval.Text);
                _servises.WEBserviceParams.CorrectState = int.Parse(textBoxCorrectState.Text);
                _servises.WEBserviceParams.ServiceName = textBoxServiceName.Text;
                _servises.WEBserviceParams.ServicePath = textBoxServicePath.Text;
            }
            else
            {
                _servises.ConsoleServiceParams.AttemptsQuantity = int.Parse(textBoxAttemptsQuantity.Text);
                _servises.ConsoleServiceParams.CheckInterval = int.Parse(textBoxCheckInterval.Text);
                _servises.ConsoleServiceParams.CorrectState = int.Parse(textBoxCorrectState.Text);
                _servises.ConsoleServiceParams.ServiceName = textBoxServiceName.Text;
                _servises.ConsoleServiceParams.ServicePath = textBoxServicePath.Text;
            }          
        }        

        private void LoadParamToForm()
        {
            if (comboBoxServiceType.SelectedItem.ToString() == "WEB")
            {
                textBoxAttemptsQuantity.Text = _servises.WEBserviceParams.AttemptsQuantity.ToString();
                textBoxCheckInterval.Text = _servises.WEBserviceParams.CheckInterval.ToString();
                textBoxCorrectState.Text = _servises.WEBserviceParams.CorrectState.ToString();
                textBoxServiceName.Text = _servises.WEBserviceParams.ServiceName;
                textBoxServicePath.Text = _servises.WEBserviceParams.ServicePath;
            }
            else
            {
                textBoxAttemptsQuantity.Text = _servises.ConsoleServiceParams.AttemptsQuantity.ToString();
                textBoxCheckInterval.Text = _servises.ConsoleServiceParams.CheckInterval.ToString();
                textBoxCorrectState.Text = _servises.ConsoleServiceParams.CorrectState.ToString();
                textBoxServiceName.Text = _servises.ConsoleServiceParams.ServiceName;
                textBoxServicePath.Text = _servises.ConsoleServiceParams.ServicePath;
            }
        }

        private void FormServiceParams_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sFilePath = "C:\\\\Temp\\Settings.xml";
            // передаем в конструктор тип класса
            XmlSerializer xmlFormater = new XmlSerializer(typeof(Services));
            // получаем поток, и сериализуем обьект
            using (FileStream fs = new FileStream(sFilePath, FileMode.OpenOrCreate))
                xmlFormater.Serialize(fs, _servises);
        }        
    }    
}
