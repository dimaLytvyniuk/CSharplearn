using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace ExcuseManager
{
    [DataContract(Namespace = "ExcuseManager")]
    class Excuse : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime lastUsed = DateTime.MinValue;
        private string dateWarning;

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Results { get; set; }

        [DataMember]
        public string LastUsed
        {
            get
            {
                return lastUsed.ToString();
            }
            set
            {
                DateTime d;
                bool dateIsValid = DateTime.TryParse(value, out d);
                if (dateIsValid)
                {
                    lastUsed = d;
                    dateWarning = "";
                }
                else
                {
                    dateWarning = "Incorrect data: " + value;
                }
                OnPropertyChanged("DateWarning");
            }
        }


        public string DateWarning
        {
            get
            {
                return dateWarning;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
