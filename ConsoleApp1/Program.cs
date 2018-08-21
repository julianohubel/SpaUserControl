using SpaUserControl.domain.Contracts.Services;
using SpaUserControl.Startup;
using SpaUserControlDataContex.domain.Contracts.Reopositories;
using SpaUserControlDataContex.domain.Model;
using SpaUserControlDataContex.Infrastructure.Data;
using SpaUserControlDataContex.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IUserService>();

            try
            {

                //service.Register("Juliano", "juliano.hubel@chleba.net", "123Mudar", "123Mudar");
                SpaUserControlDataContext context = new SpaUserControlDataContext();

               var user = context.users.Where(u => u.Email == "juliano_hubel@hotmail.com").FirstOrDefault();

                Console.WriteLine(user.Email);

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
