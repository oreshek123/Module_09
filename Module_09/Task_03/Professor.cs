using System;
using RandomNameGenerator;

namespace Module_09.Task_03
{
    /// <summary>
    /// Класс описывающий преподователя
    /// </summary>
    public class Professor : Person
    {
        /// <summary>
        /// Год принятия на работу
        /// </summary>
        public int YearOfEmployment { get; set; }

        private int _experience;

        /// <summary>
        /// Стаж
        /// </summary>
        public int Experience
        {
            get => _experience = YearOfEmployment != 0 && YearOfEmployment < DateTime.Now.Year ? DateTime.Now.Year - YearOfEmployment : 0;
            set => _experience = value;
        }
        /// <summary>
        /// Метод позволяющий сгенерировать данные рандомно
        /// </summary>
        public override void FillPropertiesRandomly()
        {

            //int randYear = Rnd.Next(DateTime.Now.Year - 100, DateTime.Now.Year - 18);
            //int randMonth = Rnd.Next(1, 12);
            //int randDay = Rnd.Next(1, DateTime.DaysInMonth(randYear, randMonth));
            //this.Birthday = DateTime.Parse($"{randYear}-{randMonth}-{randDay}");
            //this.PersonName = NameGenerator.GenerateFirstName((Gender)Rnd.Next(0, 1)).ToLower();
            base.FillPropertiesRandomly();
            this.YearOfEmployment = Rnd.Next(DateTime.Now.Year - 40, DateTime.Now.Year);
        }
    }
}
