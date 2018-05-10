using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RandomNameGenerator;


namespace Module_09.Task_04
{
    /// <summary>
    /// Абастрактный класс описывающий Товар
    /// </summary>
    public abstract class Commodity
    {
        /// <summary>
        /// Название Товара
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Цена Товара
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Рандом для генерации данных
        /// </summary>
        protected Random Rnd = new Random();

        /// <summary>
        /// Вывод всей информации об объекте
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Наименование товара - {ProductName}\nЦена - {Price}");
        }

        /// <summary>
        /// Генерация рандомных данных
        /// </summary>
        public virtual void GenerateRandomData()
        {
            this.ProductName = NameGenerator.GenerateFirstName((Gender)Rnd.Next(0, 2));
            this.Price = Rnd.NextDouble() * Rnd.Next(1000, 100000);
            Thread.Sleep(30);
        }

        /// <summary>
        /// Проверка товара на просроченность
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOverdue() => false;
    }
}
