namespace _5_лаба
{
    interface IIntelligentCreature
    {
        string Name { get; }
        int YearOfBirth { get; }
    }
    interface ICanDrive : IIntelligentCreature
    {
        void Driving(ICarManagement DriveYourCar);
    }

    //..........//ЧЕЛОВЕК УМЕЕТ ВОДИТЬ//..........//
    public class Human : ICanDrive
    {
        public override string ToString()
        {
            string res = "Объект класса " + GetType().Name +"\n";
            res += "Имя человека: " + Name;
            if (TransName != null)
                res += "\nУправляет трансформером " + TransName;
            return res;
        }

        public string Name { get; }
        public int YearOfBirth { get; private set; }
        public string TransName { get; private set; }
        public Human(string name,int yearOfBirth)
        {
            this.Name = name;
            this.YearOfBirth = yearOfBirth;
        }
        public void Driving(ICarManagement DriveYourCar)
        {
            //Можно при надобнности добавить еще полей
            if (DriveYourCar is Transformer)
            { 
                Transformer trans = DriveYourCar as Transformer;
                TransName = trans.Name;
            }
            DriveYourCar.PoweringEngine(new Engine());
        }
    }


}
