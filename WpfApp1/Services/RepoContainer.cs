using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace WpfApp1.Services
{
    public static class RepoContainer
    {
        private static IUnityContainer _container;
        static RepoContainer()
        {
            _container = new UnityContainer();

            _container.RegisterType<IRequestRepository, RequestRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IPartsRepository, PartsRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICommentRepository, CommentRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IHomeTechModelRepository, HomeTechModelRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IHomeTechTypeRepository, HomeTechTypeRepository>(new ContainerControlledLifetimeManager());
        }
        public static IUnityContainer Container { get { return _container; } }
    }
}
