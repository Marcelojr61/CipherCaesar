using System;
using System.Text.RegularExpressions;


namespace CifradeCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string newMessage = "";
            int ascII, controllerAscII;
            Regex charEsp = new Regex("^[0-9a-zA-Z ]*$");

            Console.WriteLine("Write if you wish Encrypt or Decrypt");
            string type = Console.ReadLine();
            Console.WriteLine("Write your message");
            string message = Console.ReadLine().ToLower();
            Console.WriteLine("Write the key Caeser");
            int key = Int32.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("the value cannot be null");
            }
            else 
            {
                for (int i = 0; i < message.Length; i++)
                {
                    controllerAscII = message[i];
                    string msgStr = Char.ConvertFromUtf32(message[i]);

                    if (!charEsp.IsMatch(msgStr)) { throw new ArgumentOutOfRangeException(); }

                    if (controllerAscII == 32 || controllerAscII >= 48 && controllerAscII <= 57)
                    {
                        ascII = controllerAscII;
                        newMessage += Char.ConvertFromUtf32(ascII);
                    }
                    else if (type == "Encrypt")
                    {
                        ascII = controllerAscII + key;
                        if (ascII > 'z')
                        {
                            ascII = ascII - 'z' + 'a' - 1;
                        }
                        newMessage += Char.ConvertFromUtf32(ascII);
                    }
                    else if (type == "Decrypt")
                    {
                        ascII = controllerAscII - key;
                        if (ascII < 'a')
                        {
                            ascII = ascII - 'a' + 'z' + 1;
                        }
                        newMessage += Char.ConvertFromUtf32(ascII);
                    }
                }
            }
            Console.WriteLine(newMessage);
            Console.ReadKey();
        }
    }
}
