using System;
using System.Collections.ObjectModel;
using ControllsMVVM.DataAccess;
using System.Windows.Input;
using System.Windows.Media;
using ControllsMVVM.Model;
using ControllsMVVM.CommandBase;

namespace ControllsMVVM.ViewModel
{
    class PersonListViewModel 
    {
        readonly PersonRespository _personRepository;
        RelayCommand _removecommand;
        RelayCommand _addcommand;
        private ObservableCollection<Person> _AllPersons;
        public ObservableCollection<Person> AllPersons
        {
            get
            {
                return _AllPersons;
            }
            set
            {
                _AllPersons = value;
              
            }
        }

        private int _valueAfterRemoval;
        public int ValueAfterRemoval
        {
            get
            {
                return _valueAfterRemoval;
            }
            set
            {
                _valueAfterRemoval = value;
              
            }
        }
      
        public PersonListViewModel(PersonRespository personRepository)
        {
            if (personRepository == null)
            {
                throw new ArgumentNullException("personRepository");
            }
            _personRepository = personRepository;
            this._AllPersons = new ObservableCollection<Person>(_personRepository.GetPersons());
            ValueAfterRemoval = -1;
        }
      

        public ICommand RemoveCommand
        {
            get
            {
                if (_removecommand == null)
                {
                    //_removecommand = new RelayCommand(param => this.RemoveCommandCommandExecute(), param => this.RemoveCommandCommandCanExecute);
                    _removecommand = new RelayCommand(new Action<object>(RemoveCommandCommandExecute), param => this.RemoveCommandCommandCanExecute);
                }
                return _removecommand;
            }
        }


        public ICommand AddCommand
        {
            get
            {
                if (_addcommand == null)
                {
                    //_removecommand = new RelayCommand(param => this.RemoveCommandCommandExecute(), param => this.RemoveCommandCommandCanExecute);
                    _addcommand = new RelayCommand(new Action<object>(AddCommandCommandExecute), param => this.AddCommandCommandCanExecute);
                }
                return _addcommand;
            }
        }




        void AddCommandCommandExecute(object obj)
        {
            Person p = (Person)obj;
            p = (Person)obj;           
            this.AllPersons.Add(p);            
          
        }

        bool AddCommandCommandCanExecute
        {
            get
            {
                if (this.AllPersons.Count > 20)
                {
                    return false;
                }
                return true;
            }
        }



        void RemoveCommandCommandExecute(object obj)
        {
            Person p = (Person)obj;
            //First step: copy the actual list to a temporary one 
            ObservableCollection<Person> tempCollection = new ObservableCollection<Person>(this._AllPersons);
            //Then, iterate on the temporary one: 
            foreach (Person exaq in tempCollection)
            {
                if (exaq.LastName.Equals(p.LastName))
                {
                    //And remove from the real list! 
                    this._AllPersons.Remove(exaq);
                }
            }
            ValueAfterRemoval = -1;
        }

        bool RemoveCommandCommandCanExecute
        {
            get
            {
                if (this.AllPersons.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }
        
    }
}
