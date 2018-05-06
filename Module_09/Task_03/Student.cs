using System;
using RandomNameGenerator;

namespace Module_09.Task_03
{
    /// <summary>
    /// Класс описывающий студента
    /// </summary>
    class Student : Person
    {
        public enum Cource
        {
            I=1,II=2,III=3,IV=4
        }
        /// <summary>
        /// Факультет студента
        /// </summary>
        public Faculty StudentFaculty { get; set; }

        /// <summary>
        /// Курс студента
        /// </summary>
        public Cource StudentCource { get; set; }

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
            this.StudentFaculty = (Faculty)Rnd.Next(1, 4);
            this.StudentCource = (Cource)Rnd.Next(1, 5);
        }
    }

}
