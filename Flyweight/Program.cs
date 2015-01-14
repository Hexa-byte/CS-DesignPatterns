using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        private static string[] colors =
        { "Green", "Pink", "Blue", "Red", "White", "Black", "Magenta" };

        static void Main(string[] args)
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle = (Circle) ShapeFactory.getCircle(getRandomColor());
                circle.setRadius(100);
                circle.setX(getRandomX());
                circle.setY(getRandomY());
                circle.draw();
            }
            Console.Read();
        }

        private static string getRandomColor()
        {
            return colors[(int)(new Random().Next(1, colors.Length))];
        }
        private static int getRandomX()
        {
            return (new Random().Next() * 13);
        }
        private static int getRandomY()
        {
            return (new Random().Next() * 17);
        }
    }

    public interface IShape
    {
        void draw();
    }

    public class Circle : IShape
    {
        private string _color;
        private int _x, _y, _radius;

        public Circle(string color)
        {
            _color = color;
        }
        public void setRadius(int radius)
        {
            _radius = radius;
        }
        public void setY(int y)
        {
            _y = y;
        }
        public void setX(int x)
        {
            _x = x;
        }
        public void draw()
        {
            Console.WriteLine("Drawing Circle \n" +
                              "Color: " + _color + " | x-coord: " +
                                _x + " | y-coord: " + _y + " | radius: "+ _radius);
        }
    }

    public class ShapeFactory
    {
        private static Hashtable circleMap = new Hashtable();

        public static IShape getCircle(string color)
        {
            Circle circle = (Circle) circleMap[color];

            if (circle == null)
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            }

            return circle;
        }
    }

}
