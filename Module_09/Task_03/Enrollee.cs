using System;
using RandomNameGenerator;

namespace Module_09.Task_03
{
    /// <summary>
    /// это класс абитуриента
    /// </summary>
    /// 
    public class Enrollee : Person
    {
        /// <summary>
        /// Факультет на который хочет поступить Абитуриент
        /// </summary>
        public Faculty EnroleeFaculty { get; set; }

        /// <summary>
        /// Метод позволяющий сгенерировать данные рандомно
        /// </summary>
        public override void FillPropertiesRandomly()
        {

            //int randYear = Rnd.Next(DateTime.Now.Year - 100, DateTime.Now.Year - 18);
            //int randMonth = Rnd.Next(1, 12);
            //int randDay = Rnd.Next(1, DateTime.DaysInMonth(randYear, randMonth));
            //this.Birthday = DateTime.Parse($"{randYear}-{randMonth}-{randDay}");
            base.FillPropertiesRandomly();
            this.EnroleeFaculty = (Faculty) Rnd.Next(1, 4);
            this.PersonName = NameGenerator.GenerateFirstName((Gender)Rnd.Next(0, 1)).ToLower();
        }
    }

}
