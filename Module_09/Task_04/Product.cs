using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module_09.Task_04
{
    /// <summary>
    /// Класс описывающий продукт
    /// </summary>
    public class Product : Commodity
    {
        
        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime DateOfManufacture { get; set; }

        /// <summary>
        /// Срок годности в месяцах
        /// </summary>
        public int ShelfLifeInMonths { get; set; }
        public override void GenerateRandomData()
        {
            base.GenerateRandomData();
            ShelfLifeInMonths = Rnd.Next(30);
            int randYear = Rnd.Next(DateTime.Now.Year - 3, DateTime.Now.Year);
            int randMonth = Rnd.Next(1, 12);
            int randDay = Rnd.Next(1, DateTime.DaysInMonth(randYear, randMonth));
            DateOfManufacture = DateTime.Parse($"{randYear}-{randMonth}-{randDay}");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Дата изготовления : {DateOfManufacture}\nСрок годности в месяцах : {ShelfLifeInMonths}\n");
        }

        /// <summary>
        ///  Проверка товара на просроченность
        /// </summary>
        /// <returns>Если просрочен</returns>
        public override bool IsOverdue()
        {
            if (DateTime.Compare(DateTime.Parse(DateOfManufacture.AddMonths(ShelfLifeInMonths).ToShortDateString()),
                    DateTime.Parse(DateTime.Now.ToShortDateString())) >= 0)
            {
                this.ShowInfo();
                return true;
            }
            return false;
        }
    }
}
