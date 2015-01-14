using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractLogger logChain = getChainOfLoggers();

            logChain.logMessage(AbstractLogger.INFO, "Renaming a file for uber cool program.");

            logChain.logMessage(AbstractLogger.DEBUG, "Writing a message to the console to output current text");

            logChain.logMessage(AbstractLogger.ERROR, "ERROR, something broke!!");

            Console.Read();
        }
        private static AbstractLogger getChainOfLoggers()
        {
            AbstractLogger errorLog = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger fileLog = new FileLogger(AbstractLogger.INFO);
            AbstractLogger debugLog = new ConsoleLogger(AbstractLogger.DEBUG);

            fileLog.setNextLogger(errorLog);
            errorLog.setNextLogger(debugLog);

            return fileLog;
        }
    }

    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;

        protected int level;

        protected AbstractLogger _nextLogger;

        public void setNextLogger(AbstractLogger nextLogger)
        {
            _nextLogger = nextLogger;
        }

        public void logMessage(int level, string message)
        {
            if (this.level <= level)
            {
                write(message);
            }
            if (_nextLogger != null)
            {
                _nextLogger.logMessage(level, message);
            }
        }

        protected abstract void write(string message);
    }

    public class ConsoleLogger : AbstractLogger{

        public ConsoleLogger(int level)
        {
            this.level = level;
        }

        protected override void write(string message)
        {
            Console.WriteLine("Console logger message: {0}", message);
        }
    }
    public class ErrorLogger : AbstractLogger
    {

        public ErrorLogger(int level)
        {
            this.level = level;
        }

        protected override void write(string message)
        {
            Console.WriteLine("Error log message: {0}", message);
        }
    }
    public class FileLogger : AbstractLogger
    {

        public FileLogger(int level)
        {
            this.level = level;
        }

        protected override void write(string message)
        {
            Console.WriteLine("File info message: {0}", message);
        }
    }
}
