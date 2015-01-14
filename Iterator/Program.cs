using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Top fave Design Pattern
namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            NameRepo repo = new NameRepo();

            for (Iterator iterator = repo.getIterator(); iterator.hasNext();)
            {
                var name = (string) iterator.next();
                Console.WriteLine("Name: " + name);
            }

            Console.Read();
        }
    }
    public interface Iterator
    {
        bool hasNext();
        Object next();
    }

    public interface Container
    {
        Iterator getIterator();
    }

    public class NameRepo : Container
    {
        public Iterator getIterator()
        {
            return new NameIterator();
        }

        private class NameIterator : Iterator
        {
            public string[] names = { "Robert", "John", "Julie", "Lora" };
            private int index;

            public bool hasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }

            public Object next()
            {
                if (this.hasNext())
                {
                    return names[index++];
                }
                return null;
            }
        }
    }
}
