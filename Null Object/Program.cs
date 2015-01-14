using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null_Object
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractCustomer> customerList = new List<AbstractCustomer>();
            customerList.Add(CustomerFactory.getCustomer("Stroustrup"));
            customerList.Add(CustomerFactory.getCustomer("Ritchie"));
            customerList.Add(CustomerFactory.getCustomer("Torvalds"));
            customerList.Add(CustomerFactory.getCustomer("Musk"));
            customerList.Add(CustomerFactory.getCustomer("Jobs"));
            customerList.Add(CustomerFactory.getCustomer("Gates"));

            Console.WriteLine("Customers \n");
            foreach (var customer in customerList)
            {
                Console.WriteLine("[ {0} ]\n", customer.getName());
            }

            Console.Read();
        }
    }

    public abstract class AbstractCustomer
    {
        protected string _name;
        public abstract bool isNil();
        public abstract string getName();
    }

    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            _name = name;
        }

        public override string getName()
        {
            return _name;
        }

        public override bool isNil()
        {
            return false;
        }

        
    }
    public class NullCustomer : AbstractCustomer
    {
        public override string getName()
        {
            return "Not available in customer database";
        }

        public override bool isNil()
        {
            return true;
        }
    }
    public class CustomerFactory
    {
        private static string[] names = {"Jobs", "Musk", "Gates", "Ritchie", "Stroustrup"};

        public static AbstractCustomer getCustomer(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }
}
