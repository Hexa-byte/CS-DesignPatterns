using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject sub = new Subject();

            new Subject.HexaObserver(sub);
            new Subject.OctalObserver(sub);
            new Subject.BinaryObserver(sub);

            Console.WriteLine("First State change: 15");
            sub.setState(15);
            Console.WriteLine("Second state change: 33");
            sub.setState(33);

            Console.Read();
        }
    }

    public abstract class Observer
    {
        protected Subject _subject;
        public abstract void update();
    }

    public class Subject
    {
        private List<Observer> _observers = new List<Observer>();
        private int _state;

        public int getState()
        {
            return _state;
        }

        public void setState(int state)
        {
            _state = state;
            notifyAllObservers();
        }

        public void attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach(var observer in _observers)
            {
                observer.update();
            }
        }

        public class BinaryObserver : Observer
        {
            public BinaryObserver(Subject subject)
            {
                _subject = subject;
                _subject.attach(this);

            }
            public override void update()
            {
                Console.WriteLine("Binary String: " + Convert.ToString(_subject.getState(), 2));
            }
        }

        public class OctalObserver : Observer
        {
            public OctalObserver(Subject subject)
            {
                _subject = subject;
                _subject.attach(this);
            }

            public override void update()
            {
                Console.WriteLine("Octal String: " + Convert.ToString(_subject.getState(), 8));
            }
        }

        public class HexaObserver : Observer
        {
            public HexaObserver(Subject subject)
            {
                _subject = subject;
                _subject.attach(this);
            }

            public override void update()
            {
                Console.WriteLine("Hex String: " + _subject.getState().ToString("X"));
            }
        }
    }
}
