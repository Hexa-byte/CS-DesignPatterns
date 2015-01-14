using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal class Program
    {
        public static Expression GetMaleExpression()
        {
            Expression Zac = new TerminalExpression("Zac");
            Expression Jean = new TerminalExpression("Jean");
            return new OrExpression(Zac, Jean);
        }

        public static Expression getMarriedWomanExpression()
        {
            Expression Mary = new TerminalExpression("Mary");
            Expression Married = new TerminalExpression("Married");
            return new AndExpression(Married, Mary);
        }

        private static void Main(string[] args)
        {
            Expression isMale = GetMaleExpression();
            Expression isMarriedWoman = getMarriedWomanExpression();

            Console.WriteLine("Jean is male? " + isMale.interpret("Jean"));
            Console.WriteLine("Mary is a married woman?: " + isMarriedWoman.interpret("Married Mary"));
            Console.Read();
        }
    }

    public interface Expression
    {
        bool interpret(string context);
    }

    public class TerminalExpression : Expression
    {
        private string _data;

        public TerminalExpression(string data)
        {
            _data = data;
        }

        public bool interpret(string context)
        {
            if (context.Contains(_data))
            {
                return true;
            }
            return false;
        }
    }

    public class OrExpression : Expression
    {
        private Expression _xp1 = null;
        private Expression _xp2 = null;

        public OrExpression(Expression xp1, Expression xp2)
        {
            _xp1 = xp1;
            _xp2 = xp2;
        }

        public bool interpret(string context)
        {
            return _xp1.interpret(context) || _xp2.interpret(context);
        }
    }

    public class AndExpression : Expression
    {
        private Expression _xp1 = null;
        private Expression _xp2 = null;

        public AndExpression(Expression xp1, Expression xp2)
        {
            _xp1 = xp1;
            _xp2 = xp2;
        }

        public bool interpret(string context)
        {
            return _xp1.interpret(context) && _xp2.interpret(context);
        }
    }
}
