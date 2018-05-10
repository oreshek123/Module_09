using System;
using System.Globalization;
using System.Reflection;
using GeneratorName;

namespace Module_09.Task_03
{
    /// <summary>
    /// Абстрактный класс человека
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        public string PersonName
        {
            get => _personName;
            set => _personName = value.Replace("<center><b><font size=7>", "").Replace("</font></b></center>", "").Replace("\n", "");
        }

        private string _personName;
        /// <summary>
        /// Дата его рождения в формате  -  "Год-месяц-день"
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Поле которое наследуют наследники для заполнения рандомных данных 
        /// </summary>
        protected Random Rnd = new Random();
        public Generator NameGenerator = new Generator();

        public int Age
        {
            get => GetAge();
            set => value = Age;
        }
        
        /// <summary>
        /// Показать всю информацию об человеке
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {PersonName}\nДата рождения : {Birthday}\nВозраст: {Age}");
        }

        public virtual int GetAge() => DateTime.Now.Year - Birthday.Year;

        /// <summary>
        /// Метод позволяющий сгенерировать данные рандомно
        /// </summary>
        public virtual void FillPropertiesRandomly()
        {
            int randYear = Rnd.Next(DateTime.Now.Year - 100, DateTime.Now.Year - 18);
            int randMonth = Rnd.Next(1, 12);
            int randDay = Rnd.Next(1, DateTime.DaysInMonth(randYear, randMonth));
            this.Birthday = DateTime.Parse($"{randYear}-{randMonth}-{randDay}");
            this.PersonName = NameGenerator.GenerateDefault((Gender)Rnd.Next(0, 1)).ToLower();
        }

    }
    public enum Faculty
    {
        SchoolOfTheology = 1, FacultyOfLetters = 2, FacultyOfSocialStudies = 3
    }
}
