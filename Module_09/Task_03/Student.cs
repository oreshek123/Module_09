using System;

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
            base.FillPropertiesRandomly();
            this.StudentFaculty = (Faculty)Rnd.Next(1, 4);
            this.StudentCource = (Cource)Rnd.Next(1, 5);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Факультет : {this.StudentFaculty}\nКурс : {this.StudentCource}\n");

        }
    }

}
