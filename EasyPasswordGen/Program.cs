using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EasyPasswordGen
{
    class Program
    {
        static void Main()
        {
            try // example of usage 
            {
                Console.WriteLine("Lenght of password?: ");
                int lenghtPassword = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Availability of letters? true/false: ");
                bool checkLatter = Convert.ToBoolean(Console.ReadLine());
                
                string password = checkLatter? new string(GenSetOfChar().Where(x => char.IsLetter(x)).ToArray()) : "";
                
                Console.WriteLine("Upper case? true/false: ");
                bool checkReg = Convert.ToBoolean(Console.ReadLine());

                if (checkReg) password += new string(GenSetOfChar().Where(x => char.IsLetter(x)).ToArray()).ToUpper();
                
                Console.WriteLine("Symbols? true/false: ");
                bool checkSymph = Convert.ToBoolean(Console.ReadLine());
                
                if (checkSymph) password += new string(new string(GenSetOfChar().Where(x => char.IsSymbol(x)).ToArray()));
                
                Console.WriteLine("Digits? true/false: ");
                bool checkNumber = Convert.ToBoolean(Console.ReadLine());
                
                if (checkNumber) password += new string(new string(GenSetOfChar().Where(x => char.IsDigit(x)).ToArray()));
                
                
                Random rand = new Random();
                Console.WriteLine(Enumerable.Repeat(password, lenghtPassword).Select(x => x[rand.Next(x.Length)]).ToArray());
                
            } catch (Exception e) { Console.WriteLine("Something went wrong\n" + e); }
        }
        
        public static string GenSetOfChar() {
            Random rnd = new Random(); //just create random 
            using (SHA256 ts = SHA256.Create()) // just create 
                return Convert.ToBase64String(ts.ComputeHash(Encoding.UTF8.GetBytes(rnd.Next().ToString())));
            //just return hash function in string 
            //if you know how to make it simplier 
            //let me know please
        }
    }
}