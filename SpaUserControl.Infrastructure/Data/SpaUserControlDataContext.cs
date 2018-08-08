using SpaUserControl.domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Infrastructure.Data
{
    public class SpaUserControlDataContext : DbContext
    {
        public SpaUserControlDataContext():base("SpaUserControlDataContext")
        {
            
        }

        public DbSet<User> users { get; set; }

    }
}
