using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassAssignment
{
    public class Employee: Person, IQuittable
    {
        public override void SayName()
        {
            Console.WriteLine("Name: " + firstName + " " + lastName);
        }

        public void Quit()
        {
            Console.WriteLine(firstName + " "+ lastName + " has now quit and will be removed from the system.");
        }

        public static bool operator== (Employee employee1, Employee employee2)
        {
            bool employeeMatch = employee1.Id == employee2.Id ? true : false;
            return employeeMatch;
        }

        public static bool operator!= (Employee employee1, Employee employee2)
        {
            bool employeeNotMatch = employee1.Id != employee2.Id ? true : false;
            return employeeNotMatch;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public int Id { get; set; }

    }
}
