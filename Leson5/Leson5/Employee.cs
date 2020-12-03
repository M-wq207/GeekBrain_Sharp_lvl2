using System;
using System.Collections.Generic;
using System.Linq;
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
        public Employee() { }
        public Employee (string name, DateTime birthday, Gender gender, Department department)
        {
            Name = name;
            Birthday = birthday;
            Gender = gender;
            Department = department;
        }
    }
}
