using System;
using System.Reflection;
using RandomNameGenerator;

namespace Module_09.Task_03
{
    //Не Персона а Person)
    /// <summary>
    /// Абстрактный класс человека
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        public string PersonName { get; set; }
        
        /// <summary>
        /// Дата его рождения в формате  -  "Год-месяц-день"
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Поле которое наследуют наследники для заполнения рандомных данных 
        /// </summary>
        protected Random Rnd = new Random();

        public int Age
        {
            get => GetAge();
            set => value = Age;
        }
        
        /// <summary>
        /// Показать всю информацию об человеке
        /// </summary>
        public void ShowInfo()
        {
            foreach (PropertyInfo info in MemberwiseClone().GetType().GetProperties())
                Console.WriteLine($"{info.Name} = {info.GetValue(this, null)}");
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
            this.PersonName = NameGenerator.GenerateFirstName((Gender)Rnd.Next(0, 1)).ToLower();
        }

    }
    public enum Faculty
    {
        SchoolOfTheology = 1, FacultyOfLetters = 2, FacultyOfSocialStudies = 3
    }
}
