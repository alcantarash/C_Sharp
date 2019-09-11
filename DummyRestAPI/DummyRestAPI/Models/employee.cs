using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyRestAPI.Models
{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int age { get; set; }

        //public Employee(string Name, int Salary, int Age)
        //{
        //    this.Name = Name;
        //    this.Salary = Salary;
        //    this.Age = Age;
        //}
    }
}
