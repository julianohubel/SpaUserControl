using SpaUserControlDataContex.domain.Contracts.Reopositories;
using SpaUserControlDataContex.Infrastructure.Data;
using SpaUserControlDataContex.Infrastructure.Repositories;
using Unity;
using Unity.Lifetime;

namespace SpaUserControl.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<SpaUserControlDataContext, SpaUserControlDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository,UserRepository>(new HierarchicalLifetimeManager());

        }

    }
}
