using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee { firstName = "Sample", lastName = "Student" , Id = 34259};
            employee.SayName();
            Console.ReadLine();

            //calling interface
            Employee employee2 = new Employee { firstName = "Goingto", lastName = "Leavehere" , Id = 24691};
            employee2.Quit();
            Console.ReadLine();

            bool employeeMatch = employee == employee2;
            Console.WriteLine(employeeMatch);
            Console.ReadLine();

        }
    }
}
