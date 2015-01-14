using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Top Design Pattern
namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            User Char = new User("Char");
            User Amuro = new User("Amuro");

            Char.sendMessage("Im am Char Aznable! It is my destiny to enforce discipline!");
            Amuro.sendMessage("You're just a sore loser!");

            Console.Read();
        }
    }

    public class ChatRoom
    {
        public static void showMessage(User user, string message)
        {
            Console.WriteLine(DateTime.Now.ToString() + " [ " + user.getName()
             + "] " + message);
        }
    }

    public class User
    {
        private string _name;

        public string getName()
        {
            return _name;
        }

        public void setName(string name)
        {
            _name = name;
        }

        public User(string name)
        {
            _name = name;
        }

        public void sendMessage(string message)
        {
            ChatRoom.showMessage(this, message);
        }
    }
}
