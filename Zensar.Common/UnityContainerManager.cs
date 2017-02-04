using System.Configuration;
// ReSharper disable once RedundantUsingDirective
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Zensar.Common
{
    public class UnityContainerManager
    {
        readonly IUnityContainer _unityContainer = new UnityContainer();

        private static UnityContainerManager _container;

        private UnityContainerManager()
        {
            UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (section != null)
            {
                section.Configure(_unityContainer);
            }

        }

        public static IUnityContainer Instance
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainerManager();
                }
                return _container._unityContainer;
            }
        }
    }
}
