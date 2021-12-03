using _12_лаба;

try
{
    Reflector.YourType = typeof(int);
    Reflector.AssemlyName();
    Reflector.IsPublicConstructorExist();
    Reflector.GetMethods();
    Reflector.GetInterfaces();
    Reflector.GetPropertiesAndFields();

    Reflector.WriteInfoInFile("info.txt");

    

    //new object[]{}
    var methods = Reflector.GetMethodsWithParams(typeof(double));

    var instance = Reflector.Create<string>('↓', 20);
    Console.WriteLine(instance);

    Person person = new();
    Reflector.Invoke(person, "Working", new Random().Next(101));

    //Reflector.Load();

    Console.WriteLine("Все методы отработали корректно");

}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

class Person
{
    public void Working(int num)
    {
        Console.WriteLine("Person is working... Your number: " + num);
    }
}