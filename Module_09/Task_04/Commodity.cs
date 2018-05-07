using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module_09.Task_04
{
    /// <summary>
    /// Абастрактный класс описывающий Товар
    /// </summary>
    public abstract class Commodity
    {
        public string ProductName { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime DateOfManufacture { get; set; }

        /// <summary>
        /// Срок годности в месяцах
        /// </summary>
        public int ShelfLifeInMonths { get; set; }
        
        /// <summary>
        /// Вывод всей информации об объекте
        /// </summary>
        public void ShowInfo()
        {
            foreach (PropertyInfo info in MemberwiseClone().GetType().GetProperties())
                Console.WriteLine($"{info.Name} = {info.GetValue(this, null)}");
        }
    }
}
