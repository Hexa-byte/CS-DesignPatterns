using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public static class AntiMagicString
    {
        public const string Red = "Red";
        public const string StringCircle = "Circle";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle();

            Shape redCircle = new RedShapeDecorator(new Circle());

            Shape redRectangle = new RedShapeDecorator(new Rectangle());
            Console.WriteLine("Circle with norm border");
            circle.draw();

            Console.WriteLine("\nCircle with red border");
            redCircle.draw();

            Console.WriteLine("\nRectangle with red border");
            redRectangle.draw();

            Console.Read();
        }
    }

    public interface Shape
    {
        void draw();
    }

    public class Circle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Shape: " + AntiMagicString.StringCircle);
        }
    }

    public class Rectangle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Shape: Rectangle");
        }
    }

    public abstract class ShapeDecorator : Shape
    {
        protected readonly Shape decoratedShape;

        public ShapeDecorator(Shape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }

        public void draw()
        {
            decoratedShape.draw();
        }
    }

    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(Shape decoratedShape) : base(decoratedShape)
        {

        }

        public void draw()
        {
            decoratedShape.draw();
            setRedBorder(decoratedShape);
        }

        private void setRedBorder(Shape decoratedShape)
        {
            Console.WriteLine("Border Color:" + AntiMagicString.Red);
        }
    }
}
