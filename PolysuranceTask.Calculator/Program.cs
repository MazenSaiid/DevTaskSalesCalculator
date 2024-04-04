using PolysuranceTask.Calculator.Services;

namespace PolysuranceTask.Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string discountJson = @"
        [{
	        ""key"": ""SALE10"",
	        ""value"": 0.1
        },
        {
	        ""key"": ""SALE20"",
	        ""value"": 0.2
        },
        {
	        ""key"":""SALE30"",
	        ""value"": 0.3
        }]";

            string ordersJson = @"
        [{
	        ""orderId"": 1,
	        ""discount"": ""SALE10"",
	        ""items"":
	        [{
		        ""sku"": 1001,
		        ""quantity"": 3
	        },
	        {
		        ""sku"": 1004,
		        ""quantity"": 1
	        }]
        },
        {
	        ""orderId"": 2,
	        ""items"":
	        [{
		        ""sku"": 1003,
		        ""quantity"": 1
	        }]
        },
        {
	        ""orderId"": 3,
	        ""discount"": ""SALE30"",
	        ""items"":
	        [{
		        ""sku"": 1003,
		        ""quantity"": 1
	        },
	        {
		        ""sku"": 1001,
		        ""quantity"": 4
	        },
	        {
		        ""sku"": 1002,
		        ""quantity"": 2
	        }]
        },
        {
	        ""orderId"": 4,
	        ""discount"": ""SALE10"",
	        ""items"":
	        [{
		        ""sku"": 1001,
		        ""quantity"": 7
	        }]
        },
        {
	        ""orderId"": 5,
	        ""discount"": ""SALE20"",
	        ""items"":
	        [{
		        ""sku"": 1003,
		        ""quantity"": 1
	        }]
        }]";

            string productsJson = @"
        [{
	        ""sku"": 1001,
	        ""price"": 14.99
        },
        {
	        ""sku"": 1002,
	        ""price"": 156.99
        },
        {
	        ""sku"": 1003,
	        ""price"": 1099.99
        },
        {
	        ""sku"": 1004,
	        ""price"": 64.99
        }]";

            SalesCalculator calculator = new SalesCalculator();
			calculator.CalculateSales(discountJson,ordersJson,productsJson);

        }
    }
}
