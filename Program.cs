using System;

namespace Delegates
{
    delegate int Oper(int x);

    class Program
    {
        private delegate void Back(int x);
        private delegate int OperBack(int x, Back callback);
        static int Abs(int x)
        {
            return x < 0 ? -x : x;
        }

        static int Sqr(int x)
        {
            return x * x;
        }

        static int Cube(int x)
        {
            return x * x * x;
        }
        static void OperationMenu()
        {
            Console.WriteLine("Hello, man");
            Console.WriteLine("1. Abs");
            Console.WriteLine("2. Sqr");
            Console.WriteLine("3. Cube");
            Console.WriteLine("Можно выбрать и две -- пиши две цифры (Пример: 13 - Abs, Cube)");
        }
        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Print w/o \\n");
            Console.WriteLine("2. PrintLine");
            Console.WriteLine("3. SuperPrint(-= =-)");
        }
        static void Main(string[] args)
        {
            OperationMenu();
            Console.WriteLine("Ваш выбор : ");
            Int16 choice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите Ваше число : ");
            Int32 number = Convert.ToInt32(Console.ReadLine());
            OperBack oper;

            switch (choice)
            {
                case 1:
                    {
                        PrintMenu();
                        Console.WriteLine("Ваш выбор : ");
                        Int16 choicePrint = Convert.ToInt16(Console.ReadLine());
                        oper = AbsBack;
                        switch (choicePrint)
                        {
                            case 1: oper(number, Print); break;
                            case 2: oper(number, PrintLine); break;
                            case 3: oper(number, SuperPrint); break;
                            default: throw new ArgumentOutOfRangeException("Argument out of range");
                        }
                        break;
                    }

                case 2:
                    {
                        PrintMenu();
                        Console.WriteLine("Ваш выбор : ");
                        Int16 choicePrint = Convert.ToInt16(Console.ReadLine());
                        oper = SqrBack;

                        switch (choicePrint)
                        {
                            case 1: oper(number, Print); break;
                            case 2: oper(number, PrintLine); break;
                            case 3: oper(number, SuperPrint); break;
                            default: throw new ArgumentOutOfRangeException("Argument out of range");
                        }
                        break;
                    }
                case 3:
                    {
                        PrintMenu();
                        Console.WriteLine("Ваш выбор : ");
                        Int16 choicePrint = Convert.ToInt16(Console.ReadLine());
                        oper = CubeBack;
                        switch (choicePrint)
                        {
                            case 1: oper(number, Print); break;
                            case 2: oper(number, PrintLine); break;
                            case 3: oper(number, SuperPrint); break;
                            default: throw new ArgumentOutOfRangeException("Argument out of range");
                        }
                        break;
                    }
                case 12:
                    {
                        PrintMenu();
                        Console.WriteLine("Ваш выбор : ");
                        Int16 choicePrint = Convert.ToInt16(Console.ReadLine());
                        oper = AbsBack;
                        oper += SqrBack;
                        switch (choicePrint)
                        {
                            case 1: oper(number, Print); break;
                            case 2: oper(number, PrintLine); break;
                            case 3: oper(number, SuperPrint); break;
                            default: throw new ArgumentOutOfRangeException("Argument out of range");
                        }
                        break;
                    }
                case 13:
                    {
                        PrintMenu();
                        Console.WriteLine("Ваш выбор : ");
                        Int16 choicePrint = Convert.ToInt16(Console.ReadLine());
                        oper = AbsBack;
                        oper += CubeBack;
                        switch (choicePrint)
                        {
                            case 1: oper(number, Print); break;
                            case 2: oper(number, PrintLine); break;
                            case 3: oper(number, SuperPrint); break;
                            default: throw new ArgumentOutOfRangeException("Argument out of range");
                        }
                        break;
                    }
                case 23:
                    {
                        PrintMenu();
                        Console.WriteLine("Ваш выбор : ");
                        Int16 choicePrint = Convert.ToInt16(Console.ReadLine());
                        oper = SqrBack;
                        oper += CubeBack;
                        switch (choicePrint)
                        {
                            case 1: oper(number, Print); break;
                            case 2: oper(number, PrintLine); break;
                            case 3: oper(number, SuperPrint); break;
                            default: throw new ArgumentOutOfRangeException("Argument out of range");
                        }
                        break;
                    }
                default: throw new ArgumentOutOfRangeException("Argument out of range");
            }
        }

        static int CubeBack(int x, Back callback)
        {
            x = Cube(x);
            callback(x);
            return x;
        }
        static int AbsBack(int x, Back callback) // это будет OperBack
        {
            x = Abs(x);
            callback(x);
            return x;
        }
        static int SqrBack(int x, Back callback) // это будет OperBack
        {
            x = Sqr(x);
            callback(x);
            return x;
        }
        static void PrintLine(int x) // это будет Back
        {
            Console.WriteLine($"Answer : {x}");
        }
        static void Print(int x) // это будет Back
        {
            Console.Write($"Answer : {x}");
        }
        static void SuperPrint(int x)
        {
            Console.WriteLine($"Answer");
            Console.WriteLine($"-=({x})=-");
        }
        static void Main3(string[] args)
        {
            Back back = Print;
           
            OperBack operBack = new(AbsBack);
            operBack += SqrBack;
            int y = operBack(-10, back);                // через делегат back
            operBack(-10, PrintLine);                   // через прямое
            operBack(-20, Print);                       // указание метода Print
            operBack(-30, z => Console.WriteLine(z));   // через лямбда
            Console.WriteLine("-----------------");
            OperBack oper = new(CubeBack);
            oper(-10, SuperPrint);

        }


        static void Main2(string[] args)
        {
            Console.WriteLine("Delegates");
            int x = -10;
            Oper oper = new Oper(Abs);
            oper += Sqr;
            Console.WriteLine($"{x}, {oper(x)}");
        }
    }
}