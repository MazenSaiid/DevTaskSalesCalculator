using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolysuranceTask.Calculator.Services
{
    public class SalesCalculator
    {
        public void CalculateSales(string discountJson, string ordersJson, string productsJson)
        {
            List<Discount> discounts = JsonConvert.DeserializeObject<List<Discount>>(discountJson);
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(ordersJson);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsJson);


            double totalBeforeDiscount = 0;
            double totalAfterDiscount = 0;
            double totalDiscountAmount =0;
            int discountCount = 0;


            foreach (var order in orders)
            {
                double orderTotal = 0;
                foreach (var item in order.Items)
                {
                    var product = products.FirstOrDefault(x => x.Sku == item.Sku);
                    if (product is not null)
                    {
                        orderTotal += product.Price * item.Quantity; 
                    }
                }

                //Total Amount Before Discount 

                totalBeforeDiscount += orderTotal;

                //Total Amount After Discount 

                if(!string.IsNullOrEmpty(order.Discount))
                {
                    var discount = discounts.FirstOrDefault(x=>x.Key == order.Discount);

                    if (discount is not null)
                    {
                        double discountAmount = orderTotal * discount.Value;
                        totalAfterDiscount += orderTotal - discountAmount;
                        totalDiscountAmount += discountAmount;
                        discountCount++;
                    }
                }
                else
                {
                    //No Discount Offered
                    totalAfterDiscount += orderTotal;
                }
            }
            double totalLostMoney = totalDiscountAmount;
            double averageDiscountPercentage = discountCount > 0 ? (totalDiscountAmount / totalBeforeDiscount) * 100 : 0;


            Console.WriteLine($"Total sales before discount: {totalBeforeDiscount}");
            Console.WriteLine($"Total sales after discount: {totalAfterDiscount}");
            Console.WriteLine($"Total amount of money lost via customer using Discount Codes: {totalLostMoney}");
            Console.WriteLine($"Average discount per customer as a percentage: {averageDiscountPercentage}%");
        }
    }
}
