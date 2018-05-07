using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Module_09.Task_03;
using Module_09.Task_04;

namespace Module_09
{
    class Program
    {
        public void Task_03()
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
        static void Main(string[] args)
        {
            int choise = 0;
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
