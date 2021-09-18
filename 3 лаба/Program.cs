using System;


namespace _3_лаба
{
    class Student
    {
        private readonly long ID; //компилятор дал подсказку сделать readonly
        public long getID
        {
            get
            {
                return ID;
            }
        }

        private static byte counterObjects;
        public byte counterObj
        {
            get
            {
                return counterObjects;
            }
        }

        private string name;
        private string surName;
        private string lastName;

        private DateTime dateOfBirthday;
        private string adress;
        private long phoneNumber;
        private string faculty;
        private byte course;
        private byte group;


        public Student()
        {
            Random rand = new Random();
            this.ID = rand.Next(9999999);
            counterObjects++;
        }
        public Student(string name) : this()
        {
            //////////////////////
            ///надо разобраться///
            //////////////////////
        }


        public byte age()
        {
            var age = DateTime.Now.Year - dateOfBirthday.Year;
            if (DateTime.Now.DayOfYear < dateOfBirthday.DayOfYear)
            { 
                age--;
            }
            return (byte)age;
        }
        public void printInfo(byte group, string faculty)
        {
            if (this.faculty == faculty)
            {
                if (this.group == group)
                {
                    Console.WriteLine($"Студент: {this.surName} {this.name} {this.lastName}");
                    Console.WriteLine($"Проживающий по адресу: {this.adress}");
                    Console.WriteLine($"Возраст: {this.age()} лет, тел. 8(029){this.phoneNumber}");
                    Console.WriteLine($"{this.course} курс {this.faculty} {this.group} группа");
                    Console.WriteLine("------------------------------------------------");
                }
            }
        }
        public void printInfo(string faculty)
        {
            if (this.faculty == faculty)
            {
                Console.WriteLine($"Студент: {this.surName} {this.name} {this.lastName}");
                Console.WriteLine($"Проживающий по адресу: {this.adress}");
                Console.WriteLine($"Возраст: {this.age()} лет, тел. 8(029){this.phoneNumber}");
                Console.WriteLine($"{this.course} курс {this.faculty} {this.group} группа");
                Console.WriteLine("------------------------------------------------");
            }
        }
        public void insert(string surName, string name,
        string lastName,    DateTime dateOfBirthday,
        string adress,      long phoneNumber,
        string faculty,     byte course,
            byte group)
        {
            this.name = name;
            this.surName = surName;
            this.lastName = lastName;

            this.dateOfBirthday = dateOfBirthday;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
            this.faculty = faculty;
            this.course = course;
            this.group = group;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {

            //byte n = byte.Parse(Console.ReadLine());
            const int size = 11;
            Student[] stud = new Student[size];
            for (int i = 0; i < size; i++)
            {
                stud[i] = new Student();
            }

            //ФИО, дата рождения, адрес, телефон, факультет, курс, группа
            stud[0].insert("Врублевский", "Никита", "Андреевич", new DateTime(2003, 8, 26), "Петровщина", 3257196, "ФИТ", 2, 2);
            stud[1].insert("Валдайцев", "Александр", "Денисович", new DateTime(2002, 8, 20), "Петровщина", 7772244, "ФИТ", 2, 5);
            stud[2].insert("Врублевская", "Надежда", "Дмитриевна", new DateTime(2002, 10, 30), "Уручье", 9802541, "ФИТ", 2, 2);
            stud[3].insert("Радивил", "Данила", "Дебилович", new DateTime(2003, 8, 20), "Малиновка", 3674580, "ФИТ", 2, 5);
            stud[4].insert("Шелашень", "Илья", "Дебилович", new DateTime(2003, 7, 1), "Якуба Коласа", 8493674, "ФИТ", 2, 2);
            stud[5].insert("Закревский", "Влад", "Дебилович", new DateTime(2002, 2, 17), "Зеленая ветка", 7394954, "ТОВ", 2, 2);
            stud[6].insert("чупапи", "муня", "ня", new DateTime(2003, 8, 26), "Мусорка", 3257196, "ТОВ", 2, 2);
            stud[7].insert("александр", "диктор", "канала", new DateTime(2001, 8, 20), "Кунцовщина", 7772244, "ТОВ", 2, 2);
            stud[8].insert("мастерская", "натсроение", "я", new DateTime(2002, 10, 30), "Уручье", 9802541, "ТОВ", 2, 2);
            stud[9].insert("родион", "дэн", "ричардсон", new DateTime(2003, 8, 20), "Малиновка", 3674580, "ФИТ", 2, 5);
            stud[10].insert("лиза", "воронько", "Дебиловна", new DateTime(2003, 7, 1), "Якуба Коласа", 8493674, "ФИТ", 2, 2);

            for (int i = 0; i < size; i++)
            {
                //stud[i].printInfo(2, "ФИТ");
            }
            for (int i = 0; i < size; i++)
            {
                //stud[i].printInfo("ТОВ");
            }

            var student = new Student();
            Console.WriteLine(student.getID);
            Console.WriteLine(student.counterObj);
            
            
        }
    }

}
