using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);

            Console.WriteLine(context.getState().description());

            StopState stopState = new StopState();
            stopState.doAction(context);

            Console.WriteLine(context.getState().description());

            Console.Read();
        }
    }

    public interface State
    {
        void doAction(Context context);
        string description();
    }

    public class StartState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }

        public string description()
        {
            return "Start State";
        }
    }

    public class StopState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }

        public string description()
        {
            return "Stop State";
        }
    }

    public class Context
    {
        public State _state;
        public Context()
        {
            _state = null;
        }

        public void setState(State state)
        {
            _state = state;
        }

        public State getState()
        {
            return _state;
        }
    }
}
