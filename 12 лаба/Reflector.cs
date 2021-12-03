using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _12_лаба
{
    internal static class Reflector
    {
        public static Type YourType;
        public static StringBuilder Info { get; private set; } = new StringBuilder();
        public static string AssemlyName()
        {
            string Name = YourType.Assembly.FullName;
            Info.Append(Name + "\n");
            return Name;
        }



        public static bool IsPublicConstructorExist()
        {
            var constructors = YourType.GetConstructors();
            bool result = constructors.Length > 0;
            if (result)
            {
                Info.Append("This class has public constructor(s)\n");
            }
            else
            {
                Info.Append("This class doesn't have public constructor(s)\n");
            }
            return result;
        }
        public static IEnumerable<string> GetMethods()
        {
            MethodInfo[] metInfo = YourType.GetMethods();
            IEnumerable<string>? s = null;
            Info.Append("Public methods:\n");
            for (int i = 0; i < metInfo.Length; i++)
            {
                Info.Append($"{metInfo[i].Name} | ");
                s = metInfo.Select(s => s.Name);
            }
            if (metInfo.Length == 0)
                Info.Append("This class doesn't have public methods");
            Info.Append("\n");
            return s;
        }
        public static (IEnumerable<string>, IEnumerable<string>) GetPropertiesAndFields()
        {
            PropertyInfo[] properties = YourType.GetProperties();
            FieldInfo[] fields = YourType.GetFields();

            Info.Append("Public properties:\n");
            IEnumerable<string> result_1 = properties.Select(s => s.Name);
            for (int i = 0; i < properties.Length; i++)
            {
                Info.Append($"{properties[i].Name} | ");
            }
            if (result_1.Count() < 1)
                Info.Append("There are no public properties\n");

            Info.Append("Public fields:\n");
            IEnumerable<string> result_2 = result_1 = fields.Select(s => s.Name);
            for (int i = 0; i < fields.Length; i++)
            {
                Info.Append($"{fields[i].Name} | ");
            }
            if (result_2.Count() < 1)
                Info.Append("There are no public fields\n");

            var tuple = (properties: result_1, fields: result_2);
            return tuple;
        }
        public static IEnumerable<string> GetInterfaces()
        {
            Type[] types = YourType.GetInterfaces();

            IEnumerable<string>? result = null;
            Info.Append("Intefaces:\n");
            for (int i = 0; i < types.Length; i++)
            {
                result = types.Select(s => s.Name);
                Info.Append(types[i].Name + " | ");
            }
            if (types.Length == 0)
                Info.Append("This class doesn't have public Interfaces");
            Info.Append("\n");

            return result;
        }
        
        public static IEnumerable<string> GetMethodsWithParams(Type type)
        {
            var metods = YourType.GetMethods().Where(met => met.GetParameters().FirstOrDefault()?.GetType() == type);

            IEnumerable<string>? result = default;

            if (metods.Count() > 0)
            {
                result = metods.Select(n => n.Name);
                Console.WriteLine($"Methods of {YourType}");

                foreach (var item in result)
                    Console.Write(item + " | ");
            }
            Console.WriteLine();
            return result;
        }

        public static object Invoke(object instance, string FuncName, params object?[]? args)
        {
            var result = instance.GetType()?.GetMethod(FuncName)?.Invoke(instance, args);
            if (instance.GetType().GetMethod(FuncName) == null)
                Console.WriteLine("Method not found");

            return result;
        }


        public static T Create<T>(params object?[]? args)
        {
            var a = Activator.CreateInstance(typeof(T), args);
            return (T)a;
        }
        public static void WriteInfoInFile(string file)
        {
            using FileStream fs = new FileStream(file, FileMode.OpenOrCreate);

            using (StreamWriter sr = new StreamWriter(fs))
            {
                sr.WriteLine(Info);
            }

        }

        //public static void Load()
        //{
        //    Assembly asm = Assembly.LoadFrom(@"D:\Programming\Лабы\oop\10 лаба\bin\Debug\net6.0\10 лаба.dll");
        //    Type type = asm.GetType("Student");
        //    Console.WriteLine(asm.FullName);
        //    //foreach(var item in type.GetMembers())
        //    //{
        //    //    Console.WriteLine(item.Name + " | ");
        //    //}

        //    //MethodInfo method = type.GetMethod("this.ToString");
        //    //Reflector.Invoke(Activator.CreateInstance(type.GetType(), "tesla"),"PoweringEngine");
           
        //}
    }

    //Create<T>
    //var c = typeof(T).GetConstructor(args.Select(a=>a.GetType()).ToArray());
    //var b = c.Invoke(args);       //тоже работает))
}
