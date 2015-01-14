using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator origin = new Originator();
            CareTaker taker = new CareTaker();

            origin.setState("State #1");
            origin.setState("State #2");
            taker.add(origin.saveStateToMemento());
            origin.setState("State #3");
            taker.add(origin.saveStateToMemento());
            origin.setState("State #4");

            // current state
            Console.WriteLine("Current state: " + origin.getState());
            origin.getStateFromMemento(taker.get(0));
            Console.WriteLine("First saved state: " + origin.getState());
            origin.getStateFromMemento(taker.get(1));
            Console.WriteLine("Second saved state: " + origin.getState());

            Console.Read();
        }
    }

    public class Memento
    {
        private string _state;

        public Memento(string state)
        {
            _state = state;
        }

        public string getState()
        {
            return _state;
        }
    }

    /// <summary>
    /// originating object that will save state to Memento class
    /// </summary>
    public class Originator
    {
        private string _state;

        public void setState(string state)
        {
            _state = state;
        }

        public string getState()
        {
            return _state;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(_state);
        }

        public void getStateFromMemento(Memento memento)
        {
            _state = memento.getState();
        }
    }

    public class CareTaker
    {
        private List<Memento> _mementoList = new List<Memento>();

        public void add(Memento state)
        {
            _mementoList.Add(state);
        }

        public Memento get(int index)
        {
            Memento memento_state;
            if (_mementoList.ElementAtOrDefault(index) != null)
            {
                memento_state = _mementoList[index];
            }

            else
            {
                memento_state = new Memento("Not a valid state");
            }

            return memento_state;
        }
    }
}
