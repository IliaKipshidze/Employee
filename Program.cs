using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myArr = new ArrayList();
            try
            {
                myArr.Add(new Employee("ilia", "kipshidze", "98988766655", 2002, 200, 10));
                myArr.Add(new Employee("Nugzar", "Javakhidze", "96876987687", 2007, 890, 20));
                myArr.Add(new Employee("Tekla", "Qveliashvili", "87969876871", 1992, 450, 15));
                myArr.Add(new Employee("Tea", "gogsadze", "56768654512", 1972, 2050, 25));
                myArr.Add(new Employee("Tekla", "Neparidze", "65465467306", 1974, 1100, 3));
                myArr.Sort();
                Console.WriteLine("age increasing");
                foreach (var v in myArr)
                {
                    Employee a = (Employee)v;
                    a.print();
                }
                myArr.Sort(new SortByRatingDecreasing());
                Console.WriteLine("Rating Decreasing");
                foreach (var v in myArr)
                {
                    Employee a = (Employee)v;
                    a.print();
                }
                myArr.Sort(new SortBySalaryIncreasing());
                Console.WriteLine("Salary Increasing");
                foreach (var v in myArr)
                {
                    Employee a = (Employee)v;
                    a.print();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
