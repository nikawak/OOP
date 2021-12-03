using System;
using System.Xml;
using System.Xml.Linq;
using _14_лаба;

CustomSerializer.Binary("binary_serialize.txt", new Car("Tesla X"));
Console.WriteLine("Binary (de)serializer:\n\n"+CustomDeserializer.Binary<Car>("binary_serialize.txt"));

Console.WriteLine(new String('-',30));

CustomSerializer.XML("xml_serialize.xml", new Student[] { new Student("Jungle", 16, 4.001), new Student("Nikawak", 18, 9.67) });
Console.WriteLine("Xml (de)serializer:\n");
foreach (var st in CustomDeserializer.XML<Student[]>("xml_serialize.xml"))
{
    Console.WriteLine(st);
    Console.WriteLine(new String('-', 30));
}


CustomSerializer.Json("json_serialize.json", new Student[]{ new Student("Jungle", 16, 4.001), new Student("Nikawak", 18, 9.67)});
Console.WriteLine("Json (de)serializer:\n");
foreach (var st in CustomDeserializer.Json<Student[]>("json_serialize.json"))
{
    Console.WriteLine(st);
    Console.WriteLine(new String('-', 30));
}

File.Copy("xml_serialize.xml", "xml_selectors.xml",true);

XmlDocument xml = new XmlDocument();
xml.Load("xml_selectors.xml");
XmlElement doc = xml.DocumentElement;


var nodes = doc.SelectNodes("Student");
for(int i=0;i<nodes.Count;i++)
{
    Console.WriteLine(nodes[i]["Name"].InnerXml);
}

var elem = doc?.SelectSingleNode("Student[Name='Jungle']");
Console.WriteLine(elem?.InnerXml);





Car[] cars = new Car[]
{
    new Car("Tesla X", 4),
    new Car("БЕЛАЗ", 16),
    new Car("Ламборгини Урус", 5)
};
cars[1].EnginePower = 20300;


XDocument xDoc = new XDocument();
XElement xcars = new XElement("Cars");

foreach (var car in cars)
{
    XElement xcar = new XElement("Car");
    XAttribute xbrand = new XAttribute("brand", car.Model);
    XElement xwheels = new XElement("Wheels", car.Wheels);
    XElement xenginePower = new XElement("EnginePower", car.EnginePower);

    xcar.Add(xbrand,xwheels,xenginePower);
    xcars.Add(xcar);
}

xDoc.Add(xcars);
xDoc.Save("cars.xml");

