using System.Linq;
using _11_лаба;

string[] Months = {"January","February","March","April",
        "May","June","July","August","September",
        "October","November","December"};


var myLength = 7;
IEnumerable<string> MonthsWithLength = Months.Where(x => x.Length == myLength);
Console.WriteLine($"Month() with {myLength} leters: ");
Show(MonthsWithLength);


IEnumerable<string> MonthsWithLetter = Months.Where(n => n.IndexOf('u') > -1 && n.Length > 4);
Console.WriteLine("\nMonths with letter 'u' and more than 4 letters");
Show(MonthsWithLetter);


IEnumerable<string> MonthsOfWinterAndSummer = Months.Take(2)
    .Concat(Months.Skip(11).Take(1))
    .Concat(Months.Skip(5).Take(3));
Console.WriteLine("\nMonth of Winter and Summer");
Show(MonthsOfWinterAndSummer);


IEnumerable<string> MonthsOrder = Months.OrderBy(n => n);
Console.WriteLine("\nMonth with Ordering");
Show(MonthsOrder);


List<Student> students = new List<Student>();
students.Add(new Student("Никита", "Трупяра", new DateTime(2003,08,26), "ФИТ" ,2, 7.2));
students.Add(new Student("Надежда", "Некромант", new DateTime(2002, 10, 29), "ФИТ", 2, 8.123));
students.Add(new Student("Диана", "Радивил", new DateTime(2002, 08, 29), "ФИТ", 1, 7.8753));
students.Add(new Student("Данила", "Радивил", new DateTime(2003, 08, 20), "ФИТ", 1, 5.9999));
students.Add(new Student("Владислав", "Иксверказ", new DateTime(2000, 1, 1), "ТОВ", 2, 5.011));
students.Add(new Student("Александр", "Валдис", new DateTime(2002, 08, 15), "ТОВ", 2, 9.0));
students.Add(new Student("Вадим", "Колесо", new DateTime(2003, 06, 30), "ТОВ", 1, 5.55));
students.Add(new Student("Илья", "Отчислен", new DateTime(2003, 07, 1), "ТОВ", 1, 0.00));




IEnumerable<string> studFacultyOrder = from s in students
                                       where s.Faculty == "ТОВ"
                                       orderby s.Name
                                       select s.Name;
Console.WriteLine("\nТОВ Students with Ordering");
Show(studFacultyOrder);

IEnumerable<string> studFacultyGroup = students.Where(n => n.Faculty == "ФИТ" && n.Group == 1).Select(n => n.Name);
Console.WriteLine("\nФИТ Students of first Group");
Show(studFacultyGroup);


Student youngestStud = students.OrderByDescending(n => n.DateOfBirth).Take(1).ToArray()[0];     // .First();
Console.WriteLine("\nYoungest Student");
Console.WriteLine(youngestStud.Name + " | " + youngestStud.DateOfBirth);

Student studWithName = students.First(n=>n.SurName == "Радивил");
Console.WriteLine("\nFirst student with this SurName (\"Радивил\")");
Console.WriteLine($"Name: {studWithName.Name} | Faculty: {studWithName.Faculty} | Group: {studWithName.Group}");


int CounterStudents = students.Where(n => n.Faculty == "ФИТ").Count();
Console.WriteLine("\nThere are " + CounterStudents + " FIT Students");


var names = students.Where(n => n.Age > 18)
                    .Select(n => n.Name)
                    .Union(
                     students
                    .Where(s => s.Mark > 6)
                    .Select(n => n.Name));
Show("\nMy request\n>18\\/Mark>6");
Show(names);

//int[] key = { 1, 2, 5, 7 };
//var st = names.Join(
//                    key,
//                    str => str,
//                    integer => integer,
//                    (str, integer) => new
//                    {
//                        Name = str,
//                        Id = integer,
//                    });


 

static void Show<T>(IEnumerable<T> s)
{
    foreach (var item in s)
    {
        Console.Write(item + " | ");
    }
    Console.WriteLine();
}