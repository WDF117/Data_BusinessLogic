using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Data_BusinessLogic.Services
{
    public static class RepoContainer
    {
        private static IUnityContainer _container;
        static RepoContainer()
        {
            _container = new UnityContainer();

        }
        public static IUnityContainer Container { get { return _container; } }
    }
}
