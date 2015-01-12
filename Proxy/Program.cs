using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    // EXTRA!!!
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new Proxy();
            proxy.Request();

            Console.Read();
        }
    }

    interface Subject
    {
        void Request();
    }

    class TargetSubject : Subject
    {
        public void Request()
        {
            Console.WriteLine("Request Received");
        }
    }

    class Proxy : Subject
    {
        private TargetSubject target;

        public void Request()
        {
            if (target == null)
            {
                target = new TargetSubject();
            }

            target.Request();
        }
    }
}
