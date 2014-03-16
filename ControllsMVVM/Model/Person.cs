
using System.ComponentModel;

namespace ControllsMVVM.Model
{
    public class Person : INotifyPropertyChanged
    {
        private  string _firstname;
        private  string _lastname;

       
        public Person(string firstname, string lastname)
        {
            _firstname = firstname;
            _lastname = lastname;
        }

       
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

    }
}
