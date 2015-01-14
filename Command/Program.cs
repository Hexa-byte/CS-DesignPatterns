using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock xStock = new Stock();

            BuyStock buyStockOrder = new BuyStock(xStock);
            SellStock sellStockOrder = new SellStock(xStock);

            Broker broker = new Broker();
            broker.takeOrder(buyStockOrder);
            broker.takeOrder(sellStockOrder);

            broker.placeOrders();

            Console.Read();
        }
    }

    public interface IOrder
    {
        void execute();
    }

    public class Stock
    {
        private string name = "ABC";
        private int quantity = 10;

        public void buy()
        {
            Console.WriteLine("Stock [ Name: " +name
                + " Quantity: " + quantity +" ] bought");
        }

        public void sell()
        {
            Console.WriteLine("Stock [ Name: " + name
                + " Quantity: " + quantity + " ] sold");
        }
    }

    public class BuyStock : IOrder
    {
        private Stock _xStock;

        public BuyStock(Stock xStock)
        {
            _xStock = xStock;
        }

        public void execute()
        {
            _xStock.buy();
        }
    }
    public class SellStock : IOrder
    {
        private Stock _xStock;

        public SellStock(Stock xStock)
        {
            _xStock = xStock;
        }

        public void execute()
        {
            _xStock.buy();
        }
    }

    public class Broker
    {
        private List<IOrder> _ordersList = new List<IOrder>();

        public void takeOrder(IOrder order)
        {
            _ordersList.Add(order);
        }

        public void placeOrders()
        {
            foreach (var order in _ordersList)
            {
                order.execute();
            }
            _ordersList.Clear();
        }
    }
}
