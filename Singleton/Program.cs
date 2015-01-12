using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class SingletonObject
    {
        /// <summary>
        /// Singleton DP Object
        /// </summary>
        private static SingletonObject instance = new SingletonObject();

        private SingletonObject() { }

        public static SingletonObject getInstance()
        {
            return instance;
        }

        public void showMessage()
        {
            Console.WriteLine("Hola Mundo!");
        }
    }
    class Program
    {
        /// <summary>
        /// Singleton DP Demonstration
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*
             
                //You would normally do this but method is private                
                SingleObject singleObject = new SingleObject();            
            */

            // Returns the instance var
            SingletonObject so = SingletonObject.getInstance();
            so.showMessage();
        }
    }
}
