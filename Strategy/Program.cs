using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new OperationAdd());
            Console.WriteLine("80 + 20 = {0}", context.executeStrategy(80, 20));

            context = new Context(new OperationStrategy());
            Console.WriteLine("80 - 20 = {0}", context.executeStrategy(80, 20));

            context = new Context(new OperationMultiply());
            Console.WriteLine("80 * 20 = {0}", context.executeStrategy(80,20));

            context = new Context(new OperationDivide());
            Console.WriteLine("80 / 20 = {0}", context.executeStrategy(80, 20));
            Console.Read();
        }
    }

    public interface Strategy
    {
        int doOperation(int num1, int num2);
    }

    public class OperationAdd : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class OperationMultiply : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }
    public class OperationDivide : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            return 0;
        }
    }

    public class OperationStrategy : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }

    public class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }

        public int executeStrategy(int num1, int num2)
        {
            return _strategy.doOperation(num1, num2);
        }
    }
}
