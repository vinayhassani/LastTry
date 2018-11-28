using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWay
{
    public class Employee : INotifyPropertyChanged
    {
        private string _id;
        private string _firstName;
        private string _address;

        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                //   NotifyPropertyChanged("ID");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                //   NotifyPropertyChanged("FirstName");
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                //  NotifyPropertyChanged("Address");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
