using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Employee
{
    class Employee : IEnumerable, IEnumerator, IComparable, IComparer<Employee>, IEquatable<Employee>
    {
        enum E { name, surname, ID, birth, age, salary, rating };
        object[] Data;
        int position = -1;
        public int Rating { get { return (int)Data[(int)E.rating]; } }
        public int Salary { get { return (int)Data[(int)E.salary]; } }
        public object Current
        {
            get
            {
                return Data[position];
            }
        }

        public Employee(string n, string sur, string ID, int b, int sal, int r)
        {
            if (ID.Length != 11) throw new Exception($"Wrong ID with {n}, it should contain only 11 digits, but it is {ID.Length} now");
            if (sal <= 0) throw new Exception($"Wrong salary with {n}, it can't be less than or equal to zero");
            if (b >= 2021) throw new Exception($"Wrong birth date with {n}, it can't be grater than or equal to 2021");
            if (r > 100 || r < 0) throw new Exception($"Wrong rating with {n}, it can't be grater than 100, or less than 0");

            Data = new object[7] { n, sur, ID, b, 2021 - b, sal, r };
        }
        public void print()
        {
            Console.WriteLine($"name: {Data[(int)E.name]} / surname: {Data[(int)E.surname]} / ID: {Data[(int)E.ID]}" +
                $" / birth year: {Data[(int)E.birth]} / age: {Data[(int)E.age]} / salary: {Data[(int)E.salary]}" +
                $" / rating: {Data[(int)E.rating]}");
        }

        //IEnumerable
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                yield return Data[i];
            }
        }

        //IEnumerator
        public bool MoveNext()
        {
            return (++position < Data.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        //IComparable
        public int CompareTo(object obj)
        {
            Employee e = obj as Employee;
            string n1 = this.Data[(int)E.age].ToString();
            string n2 = e.Data[(int)E.age].ToString();
            return n1.CompareTo(n2);
        }
        //IComparer
        public int Compare(Employee x, Employee y)
        {
            return x.CompareTo(y);
        }

        public bool Equals(Employee other)
        {
            return this.Data[(int)E.name].ToString().Equals(other.Data[(int)E.name].ToString()) &&
                this.Data[(int)E.surname].ToString().Equals(other.Data[(int)E.surname].ToString());
        }
    }

    class SortByRatingDecreasing : IComparer
    {
        int IComparer.Compare(object xx, object yy)
        {
            Employee x = (Employee)xx;
            Employee y = (Employee)yy;
            if (x.Rating == y.Rating) return 0;
            else if (x.Rating < y.Rating) return 1;
            else return -1;
        }
    }

    class SortBySalaryIncreasing: IComparer
    {
        int IComparer.Compare(object xx, object yy)
        {
            Employee x = (Employee)xx;
            Employee y = (Employee)yy;
            if (x.Salary == y.Salary) return 0;
            else if (x.Salary > y.Salary) return 1;
            else return -1;
        }
    }
}
