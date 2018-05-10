using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_09.Task_04
{
    /// <summary>
    /// Класс описывающий комплект
    /// </summary>
    public class Set : Commodity
    {
        /// <summary>
        /// Коллекция Продуктов
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Установка полной стоимости цены
        /// </summary>
        private bool SetPrice()
        {
            if (Products.Count <= 0)
            {
                Console.WriteLine("В данной партии нет продуктов!");
                return false;
            }
            this.Price = Products.Select(s => s.Price).ToList().Average() * Products.Count;
            return true;
        }

        /// <summary>
        /// Проверка на просроченность товара
        /// </summary>
        /// <returns>bool</returns>
        public override bool IsOverdue()
        {
            if (Products.Count > 0 && Products.Any(a => a.IsOverdue()))
            {
                Products.Where(w => w.IsOverdue()).ToList().ForEach(f => f.ShowInfo());
                return true;
            }
            return false;
        }

        public override void GenerateRandomData()
        {
            base.GenerateRandomData();
            for (int i = 0; i < Rnd.Next(1000); i++)
            {
                Product p = new Product();
                p.GenerateRandomData();
                Products.Add(p);
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"SetName = {this.ProductName}\n" +
                              $"Price for Set = {(SetPrice() ? Price.ToString(CultureInfo.InvariantCulture) : "0")}");
            Console.WriteLine("-----------------------------------------------------");
            if (Products.Count > 0)
            {
                Console.WriteLine("==================Products of Set==================");
                Products.ForEach(f => f.ShowInfo());
                Console.WriteLine("=====================================================");
            }
            else
                Console.WriteLine("There is no products in the Batch");

        }
    }
}
