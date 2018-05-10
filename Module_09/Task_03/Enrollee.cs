using System;
using GeneratorName;

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
            base.FillPropertiesRandomly();
            this.EnroleeFaculty = (Faculty) Rnd.Next(1, 4);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Факультет на который хочет поступить Абитуриент : {this.EnroleeFaculty}\n");
        }
    }

}
