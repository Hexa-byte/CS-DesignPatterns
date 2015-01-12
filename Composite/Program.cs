using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee CEO = new Employee("Logan Smith", "CEO", 1000000);
            Employee CIO = new Employee("Timothy Norris", "CIO", 1000000);
            Employee CTO = new Employee("Elon Musk", "CTO", 1000000);

            Employee Marketer = new Employee("Laura Burns", "Marketing", 1000000);
            Employee Developer = new Employee("Mr X", "DevOps", 1000000);
            Employee Janitor = new Employee("Yonnie Yonson", "Yanitor", 500000);

            CEO.add(CTO);
            CEO.add(CIO);
            CEO.add(Marketer);
            CEO.add(Developer);
            CEO.add(Developer);

            CIO.add(Marketer);
            CIO.add(Developer);
            CIO.add(Janitor);

            CTO.add(Developer);

            Console.WriteLine(CEO.bio());
            foreach (Employee superior in CEO.getEmployees())
            {
                Console.WriteLine(superior.bio());
                foreach (Employee e in superior.getEmployees())
                {
                    Console.WriteLine(e.bio());
                }
            }
            Console.ReadLine();
        }
    }

    public class Employee
    {
        private string name;
        private string dept;
        private int salary;
        private readonly List<Employee> _employees;

        public Employee(string name, string dept, int sal)
        {
            this.name = name;
            this.dept = dept;
            this.salary = sal;
            _employees = new List<Employee>();
        }

        public void add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void remove(Employee employee)
        {
            _employees.Remove(employee);
        }

        public List<Employee> getEmployees()
        {
            return _employees;
        }

        public string bio()
        {
            return ("Emloyee Chart" +
                    "Name : " + name + "| Department : | " + dept +
                    "Salary : " + salary);
        }
    }
}
