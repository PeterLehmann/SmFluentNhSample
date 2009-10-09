using StructureMap;

namespace BookShelf.Registries
{
    public sealed class Bootstrapper : IBootstrapper
    {
        private static bool _hasStarted;

        public void BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x =>
                {
                    x.AddRegistry(new CoreRegistry());
                    x.AddRegistry(new NHibernateRegistry());
                });
        }

        public static void Restart()
        {
            if (_hasStarted)
            {
                ObjectFactory.ResetDefaults();
            }

            else
            {
                Bootstrap();
                _hasStarted = true;
            }
        }

        public static void Bootstrap()
        {
            new Bootstrapper().BootstrapStructureMap();
        }
    }
}
