using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    public class ExceptionTest : Exception
    {
        public string Result { get; protected set; }
        public string ResLog { get; protected set; }

        public ExceptionTest():base()
        {
        }
        public ExceptionTest(string mes) : base(mes)
        {
        }
        public virtual string FullInfo()
        {
            Result = $"{this.Message}\nОшибка произошла в: \n{this.StackTrace}\nЧто же теперь делать?\n";
            return Result;
        }
        public virtual string LogInfo()
        {

            ResLog = $"Время ошибки: {DateTime.Now}\nСообщение об ошибке: {this.Message}\nОшибка произошла в: {this.TargetSite}\n\n" +
                $"{new String('-',40)}\n";
            
            return ResLog;
        }
    }

    public class ExTestDivZero : ExceptionTest
    {
        public ExTestDivZero() : base()
        {
        }
        public ExTestDivZero(string message) : base(message)
        {
        }
        public override string FullInfo()
        {
            base.FullInfo();
            Result += "\nНе дели на нуль!!!";
            return Result;
        }
    }

    public class ExTestWrongData : ExceptionTest
    {
        public ExTestWrongData() : base()
        {
        }
        public ExTestWrongData(string message) : base(message)
        {
        }
        public override string FullInfo()
        {
            base.FullInfo();
            Result += "\nПроверить введённые данные";
            return Result;
        }
    }
    public class ExTestReadFile : ExceptionTest
    {
        public ExTestReadFile() : base()
        {
        }
        public ExTestReadFile(string message) : base(message)
        {
        }
        public override string FullInfo()
        {
            base.FullInfo();
            Result += "\nПопробуй ещё раз";
            return Result;
        }
    }
}
