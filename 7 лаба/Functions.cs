using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    static class Functions
    {
        public static void Divide()
        {
            int s = 0;
            if (s == 0) throw new ExTestDivZero("Ошибка!!! Попытка деления на 0");
            int v = 8 / s;
        }


        public static void WriteData()
        {
            Transformer nik = new Transformer("nik", "model-S", 1);
            if (nik.Name == "" || nik.Model == "" || nik.YearOfBirth < 0)
            {
                throw new ExTestWrongData("Ошибка!!!! Некорректно введенные данные");
            }
        }


        public static void ReadFile(string path)
        {
            if (path == "") throw new ExTestReadFile("Ошибка!!! Путь до файла отсутствует");
            Army C = ArmyControl.InitFromFile("Дельта", path);
        }

        public static void UseAssert()
        {
            int size = -1;//не может быть отриц
            Debug.Assert(size < 0, "Размер не может быть отрицательным");
        }

    }
}
