using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IComputerPart computer = new Computer();
            computer.accept(new ComputerPartDisplayVisitor());
            Console.Read();
        }
    }

    public interface IComputerPart
    {
        void accept(ComputerPartVisitor cpVisitor);
    }

    public interface ComputerPartVisitor
    {
        void visit(Computer computer);
        void visit(Mouse mouse);
        void visit(Keyboard keyboard);
        void visit(Monitor monitor);
    }

    public class Keyboard : IComputerPart
    {
        public void accept(ComputerPartVisitor cpVisitor)
        {
            cpVisitor.visit(this);
        }
    }

    public class Monitor : IComputerPart
    {
        public void accept(ComputerPartVisitor cpVisitor)
        {
            cpVisitor.visit(this);
        }
    }

    public class Mouse : IComputerPart
    {
        public void accept(ComputerPartVisitor cpVisitor)
        {
            cpVisitor.visit(this);
        }
    }

    public class Computer : IComputerPart
    {
        private IComputerPart[] _parts;

        public Computer()
        {
            _parts = new IComputerPart[] {new Mouse(), new Keyboard(), new Monitor()};
        }

        public void accept(ComputerPartVisitor cpVisitor)
        {
            for (int i = 0; i < _parts.Length; i++)
            {
                _parts[i].accept(cpVisitor);
            }
        }
    }

    public class ComputerPartDisplayVisitor : ComputerPartVisitor
    {
        public void visit(Computer computer)
        {
            Console.WriteLine("Running Cpu");
        }

        public void visit(Mouse mouse)
        {
            Console.WriteLine("Moving Mouse");
        }

        public void visit(Keyboard keyboard)
        {
            Console.WriteLine("Keyboard loading drivers");
        }

        public void visit(Monitor Monitor)
        {
            Console.WriteLine("Displaying Monitor");
        }
    }

}
