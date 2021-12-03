using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_лаба
{
    public class Student : IComparable
    {
        public decimal AvgMark { get; }

        public string? Name { get; }

        public Student(string name, decimal avgMark)
        {
            AvgMark = avgMark;
            Name = name;
        }
        int IComparable.CompareTo(object o)
        {
            var stud = o as Student;
            return AvgMark.CompareTo(stud?.AvgMark);
        }

    }

    class MyStudentList<T>:List<T>
    {
        public List<T> list = new List<T>();
        public MyStudentList() : base()
        {
            
        }          
        public void ShowStud()
        {
            foreach (T item in list)
            {
                Student ItemStud = item as Student;
                Console.WriteLine($"Student: {ItemStud.Name} || Average mark: {ItemStud.AvgMark}");
            }
        }
    }

}
