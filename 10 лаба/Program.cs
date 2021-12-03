using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _10_лаба
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var nik = new Student("Nikita", 7.34947M);
            var nad = new Student("Nadeya", 8.102345M);
            var rad = new Student("Radick", 1.020304M);
            var vl = new Student("Vladik", 0M);

            //Console.WriteLine(nik.(IComparable)CompareTo(nad));

            Queue<Student> Isit = new();


            Isit.Enqueue(vl);
            Isit.Enqueue(new Student("Valdic", 6.9901M));
            Isit.Enqueue(nik);
            Isit.Enqueue(nad);
            Isit.Enqueue(rad);
            

            Console.WriteLine($"Show all Queue");
            foreach(var item in Isit)
            {
                Console.WriteLine($"Student: {item.Name} || Average mark: {item.AvgMark}");
            }
            Console.WriteLine();

            Space();
            Console.WriteLine($"\nQueue\nDeleting first student {Isit.Peek().Name}");
            Isit.Dequeue();

            Console.WriteLine($"Searching student {vl.Name} || {Isit.Contains(vl)}");
            Console.WriteLine($"Searching student {nik.Name} || {Isit.Contains(nik)}");
            
            ////////////////////////////
           
            Dictionary<int, Student> studentsD = new(Isit.Count);
           
            for (int i = 0; i < studentsD.Count; i++)
            {
                studentsD.Add(i+1, Isit.Dequeue());
            };
            Console.WriteLine();

            ////////////////////////////

            MyStudentList<Student> stud = new() {nik, nad, rad, vl };
            Space();
            Console.WriteLine("\nMyStudentList\nFind student with AVG > 7:");
            stud.list = stud.FindAll(x => x.AvgMark>7);
            stud.ShowStud();
            Console.WriteLine();

            ////////////////////////////

            ObservableCollection<Student> obs = new ObservableCollection<Student>();
            Space();
            Console.WriteLine("\nObservableCollection with Events");
            obs.CollectionChanged += MyChanging;
            foreach(var item in stud)
            {
                obs.Add(item);
            }
            obs.Remove(nik);
                

        }



        public static void MyChanging(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Student? user1 = e?.NewItems?[0] as Student;
                    Console.WriteLine($"Sender(Student) Adding {user1?.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Student? user2 = e?.OldItems?[0] as Student;
                    Console.WriteLine($"Sender(Student) Removing {user2?.Name}");
                    break;
            }
        }


        
        public static void Space()
        {
            Console.WriteLine(new String('=', 45));
        }
       
    }
}
