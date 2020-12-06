using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Leson5
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set;}

        public bool Locked { get; set; }
        public Employee() { }
        
        public Employee (string name, DateTime birthday, Gender gender, Department department, bool locked)
        {
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Department = department;
            Locked = locked;
        }
    }
    public class EmployeeV2 : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                NotifyPropertyChanged();
            }
        }

        //public string Name { get; set; }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                NotifyPropertyChanged();
            }
        }
        private Gender _gender;
        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                NotifyPropertyChanged();
            }
        }
        private Department _department;
        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                NotifyPropertyChanged();
            }

        }

        private bool _locked;
        public bool Locked
        {
            get => _locked;
            set
            {
                _locked = value;
                NotifyPropertyChanged();
            }
        }
        public EmployeeV2() { }

        public EmployeeV2(string name, DateTime birthday, Gender gender, Department department, bool locked)
        {
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Department = department;
            Locked = locked;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
