using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape blueCircle = new Circle(140, 160, 140, new BlueCircle());
            Shape greenCircle = new Circle(200, 150, 29, new BlueCircle());

            blueCircle.draw();
            greenCircle.draw();

            Console.Read();
        }

        public interface IDrawAPI
        {
            void drawCircle(int radius, int x, int y);
        }

        public class BlueCircle : IDrawAPI
        {
            public void drawCircle(int radius, int x, int y)
            {
                Console.WriteLine("Drawing Circle... color: blue | " +
                                  "radius: " + radius + " | x-coord: " + 
                                  x + " | y-coord: " + y);
            }
        }

        public class GreenCircle : IDrawAPI
        {
            public void drawCircle(int radius, int x, int y)
            {
                Console.WriteLine("Drawing Circle... color: green | " +
                                  "radius: " + radius + " | x-coord: " +
                                  x + " | y-coord: " + y);
            }
        }

        public abstract class Shape
        {
            protected IDrawAPI _drawAPI;

            protected Shape(IDrawAPI drawApi)
            {
                _drawAPI = drawApi;
            }

            public abstract void draw();
        }

        public class Circle : Shape
        {
            private int radius, x, y;
            public Circle(int radius, int x, int y, IDrawAPI drawAPI) : base(drawAPI)
            {
                this.radius = radius;
                this.x = x;
                this.y = y;
            }
            public override void draw()
            {
                _drawAPI.drawCircle(radius, x, y);
            }
        }
    }
}
