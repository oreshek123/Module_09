using System;
using System.Collections.Generic;
using System.Threading;
using Module_09.Task_03;
using Module_09.Task_04;
namespace Module_09
{
    class Program
    {
        private static void Task_03()
        {
            int defCountOfPersons = 5;
            Console.WriteLine("Введите количество человек чтобы сгенерировать рандомно. P.S. минимум 5)");
            int.TryParse(Console.ReadLine(), out defCountOfPersons);
            List<Person> persons = GeneratePersons(defCountOfPersons);

            int choise = 0;
            start:
            Console.WriteLine("1 - Вывести всю информацию\n2 - Найти людей старше заданного диапозона");
            int.TryParse(Console.ReadLine(), out choise);
            switch (choise)
            {
                case 1:
                    {
                        persons.ForEach(f => f.ShowInfo());
                        break;
                    }
                case 2:
                    {
                        int age = 0;
                        Console.WriteLine("Введите возраст не больше 100 лет");
                        int.TryParse(Console.ReadLine(), out age);
                        int countOfFoundPersons = 0;
                        if (age < 100 && age != 0)
                        {
                            foreach (Person p in persons)
                            {
                                if (p.GetAge() >= age)
                                {
                                    p.ShowInfo();
                                    countOfFoundPersons++;
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Всего было найдено : {0} человек", countOfFoundPersons);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    }
            }
            Console.WriteLine("Нажмите enter чтобы выйти или другую клавищу чтобы вернуться в начало");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                goto start;
            }
        }
        private static void Task_04()
        {
            Random rnd = new Random();
            Console.WriteLine("Идет генерация рандомных данных...");
            List<Commodity> commodities = new List<Commodity>();
            for (int i = 0; i < 5; i++)
            {
                switch (rnd.Next(0, 2))
                {
                    case 0:
                        {
                            Set s = new Set();
                            s.GenerateRandomData();
                            commodities.Add(s);
                            break;
                        }
                    case 1:
                        {
                            Batch b = new Batch();
                            b.GenerateRandomData();
                            commodities.Add(b);
                            break;
                        }
                }
            }
            int choise = 0;
            start:
            Console.WriteLine("1 - Show all Database Info\n2 - Найти просроченные продукты");
            int.TryParse(Console.ReadLine(), out choise);
            switch (choise)
            {
                case 1:
                    {
                        commodities.ForEach(f => f.ShowInfo());
                        break;
                    }
                case 2:
                    {
                        int count = 0;
                        foreach (Commodity c in commodities)
                        {
                            if (c.IsOverdue())
                            {
                                count++;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" {(count != 0 ? "Всего просроченных товаров в базе данных - " + count : "В базе нет просроченных продуктов!")}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
            }
            Console.WriteLine("Нажмите enter чтобы выйти или другую клавищу чтобы вернуться в начало");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.Clear();
                goto start;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                start:
                Console.WriteLine("3 - Проверить задание под №3\n4 - Проверить задание под №4\n5 - Выход");
                int choise = 0;
                int.TryParse(Console.ReadLine(), out choise);
                switch (choise)
                {
                    case 3:
                        {
                            Task_03();
                            Console.WriteLine("Нажмите пробел чтобы выйти или другую клавищу чтобы вернуться в начало");
                            if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                            {
                                Console.Clear();
                                goto start;
                            }

                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            Task_04();
                            Console.WriteLine("Нажмите пробел чтобы выйти или другую клавищу чтобы вернуться в начало");
                            if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                            {
                                Console.Clear();
                                goto start;
                            }

                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вы что-то тыкнули не то , мы уже рабоатем над этим , попробуйте ещё раз пожалуйста");
                            Thread.Sleep(2000);
                            Console.Clear();
                            goto start;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
        public static List<Person> GeneratePersons(int countOfPersons)
        {
            Random rnd = new Random();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < countOfPersons; i++)
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        Enrollee enrollee = new Enrollee();
                        enrollee.FillPropertiesRandomly();
                        persons.Add(enrollee);
                        break;
                    case 1:
                        Student student = new Student();
                        student.FillPropertiesRandomly();
                        persons.Add(student);
                        break;
                    case 2:
                        Professor professor = new Professor();
                        professor.FillPropertiesRandomly();
                        persons.Add(professor);
                        break;
                }
                Thread.Sleep(30);
            }
            return persons;
        }
    }
}