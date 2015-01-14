using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Racing();
            game.play();
            Console.WriteLine();

            game = new Basketball();
            game.play();
            Console.WriteLine();

            game = new Football();
            game.play();

            Console.Read();
        }
    }

    public abstract class Game
    {
        public abstract void initialize();
        public abstract void startPlay();
        public abstract void endPlay();

        public void play()
        {
            initialize();
            startPlay();
            endPlay();
        }
    }

    public class Racing : Game
    {
        public override void initialize()
        {
 	        Console.WriteLine("Racing Game start");
        }

        public override void startPlay()
        {
 	        Console.WriteLine("Race started. Good luck!");
        }

        public override void endPlay()
        {
 	        Console.WriteLine("Race Finished! You win!");
        }
    }

    public class Football : Game
    {
        public override void initialize()
        {
            Console.WriteLine("Football Game start");
        }

        public override void startPlay()
        {
            Console.WriteLine("Football started. Good luck!");
        }

        public override void endPlay()
        {
            Console.WriteLine("Football Finished! You win!");
        }
    }

    public class Basketball : Game
    {
        public override void initialize()
        {
            Console.WriteLine("Basketball Game start");
        }

        public override void startPlay()
        {
            Console.WriteLine("Basketball started. Good luck!");
        }

        public override void endPlay()
        {
            Console.WriteLine("Basketball Finished! You win!");
        }
    }
}
