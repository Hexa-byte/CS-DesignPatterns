using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeMaker maker = new ShapeMaker();
            
            maker.drawRectangle();
            maker.drawSquare();
            maker.drawStar();

            Console.Read();
        }

        interface Shape
        {
            void Draw();
        }

        public class Square : Shape
        {
            public void Draw()
            {
                Console.WriteLine("Drawing a square...Done");
            }
        }

        public class Rectangle : Shape
        {
            public void Draw()
            {
                Console.WriteLine("Drawing a Rectangle...Done");
            }
        }

        public class Star : Shape
        {
            public void Draw()
            {
                Console.WriteLine("Drawing a Star...Done");
            }
        }

        public class ShapeMaker
        {
            private Shape square;
            private Shape rectangle;
            private Shape star;

            public ShapeMaker()
            {
                square = new Square();
                rectangle = new Rectangle();
                star = new Star();
            }

            public void drawSquare()
            {
                square.Draw();
            }

            public void drawRectangle()
            {
                rectangle.Draw();
            }

            public void drawStar()
            {
                star.Draw();
            }
        }
    }
}
