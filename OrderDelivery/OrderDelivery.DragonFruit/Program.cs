using System;

namespace OrderDelivery.DragonFruit
{
    public class Program
    {
        /// <summary>
        /// Order food -- from the command line!
        /// </summary>
        /// <param name="restaurant">The restaurant to order from</param>
        /// <param name="menuItem">Which menu item to order</param>
        public static void Main(string restaurant, string menuItem, OrderService service)
        {
            Console.WriteLine($"Ordering {menuItem} from {restaurant} using {service}");
        }
    }

    public enum OrderService
    {
        Grab,
        LineMan
    }
}