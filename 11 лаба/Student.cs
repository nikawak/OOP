using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_лаба
{
    internal class Student
    {
        public string Name { get; private set; }
        public string SurName { get; private set; }
        public string Faculty { get; private set; }
        public int Group { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int Age { get; private set; }
        public double Mark { get; private set; }
        private void SetAge()
        {
            Age = DateTime.Now.Year - DateOfBirth.Year - 1;
            if (DateTime.Now.DayOfYear > DateOfBirth.DayOfYear)
            {
                Age++;
            }
        }
        public Student(string name, string surname, DateTime dateOfBirth, string faculty, int group, double mark)
        {
            Name = name;
            SurName = surname;
            Faculty = faculty;
            Group = group;
            DateOfBirth = dateOfBirth;
            Mark = mark;
        }
    }
}
