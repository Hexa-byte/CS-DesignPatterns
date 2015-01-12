using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSandbox
{
    public interface IShape
    {
        void Draw();
    }

    public interface IColor
    {
        void Fill();
    }

    public abstract class AbstractFactory
    {
        public abstract IColor getColor(string color);
        public abstract IShape getShape(string shape);
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Square::draw() method");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Circle::draw() method");
        }
    }

    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Red::fill() method.");
        }
    }
    public class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Green::fill() method.");
        }
    }

    public class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Blue::fill() method.");
        }
    }
    internal class ShapeFactory : AbstractFactory
    {
        private const string Circle = "Circle", Square = "Square", Rectangle = "Rectangle";
        // get objects of type shape
        public override IShape getShape(string shapeType)
        {
            
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType.Equals(Circle))
            {
                return new Circle();
            }
            if (shapeType.Equals(Square))
            {
                return new Square();
            }
            if (shapeType.Equals(Rectangle))
            {
                return new Rectangle();
            }
            return null;
        }

        public override IColor getColor(string color)
        {
            return null;
        }
    }

    public class ColorFactory : AbstractFactory
    {
        private const string Red = "Red", Blue = "Blue", Green = "Green";
        public override IShape getShape(string shapeType)
        {
            return null;
        }

        public override IColor getColor(string color)
        {
            if (color == null)
            {
                return null;
            }
            if (color.Equals(Red))
            {
                return new Red();
            }
            if (color.Equals(Blue))
            {
                return new Blue();
            }
            if (color.Equals(Green))
            {
                return new Green();
            }
            return null;
        }
    }

    public class FactoryProducer
    {
        public static AbstractFactory getFactory(string choice)
        {
            if (choice.Equals("Shape"))
            {
                return new ShapeFactory();
            }
            if (choice.Equals("Color"))
            {
                return new ColorFactory();
            }
            return null;
        }
    }

    class FactoryProgram
    {
        static void Main(string[] args)
        {
            // run factory pattern
            GetFactory();
            Console.Read();
            Console.Clear();
            Console.Clear();

            // run abstract factory pattern
            Console.WriteLine();
            GetAbstractFactory();
            Console.Read();

            Console.Read();
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        public static void GetAbstractFactory()
        {

            AbstractFactory shapeFactory = FactoryProducer.getFactory("Shape");
            IShape shape1 = shapeFactory.getShape("Circle");
            IShape shape2 = shapeFactory.getShape("Square");
            IShape shape3 = shapeFactory.getShape("Rectangle");

            shape1.Draw();
            shape2.Draw();
            shape3.Draw();

            AbstractFactory colorFactory = FactoryProducer.getFactory("Color");
            IColor color1 = colorFactory.getColor("Red");
            IColor color2 = colorFactory.getColor("Blue");
            IColor color3 = colorFactory.getColor("Green");

            color1.Fill();
            color2.Fill();
            color3.Fill();
        }

        public static void GetFactory()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            IShape shape1 = shapeFactory.getShape("Circle");
            IShape shape2 = shapeFactory.getShape("Square");
            IShape shape3 = shapeFactory.getShape("Rectangle");

            shape1.Draw();
            shape2.Draw();
            shape3.Draw();
        }
    }
}
