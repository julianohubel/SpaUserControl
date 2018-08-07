using SpaUserControl.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("j", "juliano_hubel@hotmail.com" );
            try
            {
                user.Validate();
                user.SetPassWord("12345", "123456");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
          

            Console.WriteLine(user.Name);
            Console.WriteLine(user.Password);
            Console.ReadKey();
        }
    }
}
