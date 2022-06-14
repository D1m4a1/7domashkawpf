using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace _7domashkawpf
{
  
    class AllINfoWorkers: INotifyPropertyChanged
    {
        public string ID { get; set; } = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}";
        public DateTime Data { get; set; } = DateTime.Now;

        private string _fullname;
        private int _age;
        private int _hight;
        private string _birthday;
        private string _city;

        
        public string FullName
        {
            get{ return _fullname; }
            set
            {
                if (_fullname == value)
                    return;
                _fullname = value;
                OnPropertyChanged("FullName");
            }
        }
        public int Age
        {
            get { return _age; }
            set 
            { 
                if (_age == value)
                    return;
                _age = value;
                OnPropertyChanged("Age");
            }
        }
        public int Hight
        {
            get { return _hight; }
            set
            {
                if (_hight == value)
                    return;
                _hight = value;
                OnPropertyChanged("Hight");
            }
        }
        public  string Birthday
        {
            get { return _birthday; }
            set
            {
                if (_birthday == value)
                    return;
                _birthday = value;
                OnPropertyChanged("FullName");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value)
                    return;
                _city = value;
                OnPropertyChanged("FullName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
