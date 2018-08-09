using SpaUserControlDataContex.domain.Contracts.Reopositories;
using SpaUserControlDataContex.domain.Model;
using SpaUserControlDataContex.Infrastructure.Repositories;
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

            try
            {
                var user = new User("juliano", "juliano_hubel@hotmail.com");
                
                user.SetPassWord("123456", "123456");
                user.Validate();
                using (IUserRepository userRep = new UserRepository())
                {
                    userRep.Create(user);
                }


                using (IUserRepository userRep = new UserRepository())
                {
                    var usr = userRep.Get("juliano_hubel@hotmail.com");
                    Console.WriteLine(usr.Name);
                }
                
                Console.ReadKey();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

          



        }
    }
}
