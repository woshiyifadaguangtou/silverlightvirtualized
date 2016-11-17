using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightApplication1
{
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string property)
        {
            var hander = PropertyChanged;
            if (hander != null)
                    hander(this, new PropertyChangedEventArgs(property));
            
        }

        string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        int age;

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
        string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public string PhoneNO
        {
            get
            {
                return phoneNO;
            }

            set
            {
                phoneNO = value;
               // OnPropertyChanged("PhoneNO");
            }
        }

        public string Byds
        {
            get
            {
                return byds;
            }

            set
            {
                byds = value;
            }
        }

        public int Scds
        {
            get
            {
                return scds;
            }

            set
            {
                scds = value;
            }
        }

        public decimal Dj
        {
            get
            {
                return dj;
            }

            set
            {
                dj = value;
            }
        }

        public string Skfsname
        {
            get
            {
                return skfsname;
            }

            set
            {
                skfsname = value;
            }
        }

        public string Yhname
        {
            get
            {
                return yhname;
            }

            set
            {
                yhname = value;
            }
        }

        string phoneNO;

        string byds;

        int scds;

        decimal dj;

        string skfsname;

        string yhname;
    }
}
