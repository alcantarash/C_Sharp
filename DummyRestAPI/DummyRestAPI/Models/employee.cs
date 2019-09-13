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


        //public Employee(string name, int salary, int age)
        //{
        //    this.name = name;
        //    this.salary = salary;
        //    this.age = age;                
        //}
    }
}
