using StructureMap;

namespace Endpoint2.Bootstrap
{
    public class Bootstrapper
    {
        private static readonly object SyncRoot = new object();
        private static volatile Bootstrapper instance;

        private Bootstrapper()
        {
        }

        public IContainer Container { get; private set; }

        public void Run()
        {
            Container = new Container(x => x.Scan(s =>
            {
                s.LookForRegistries();
            }));
        }

        public class ComponentRegistry : Registry
        {
            public ComponentRegistry()
            {
               
            }
        }

        public static Bootstrapper Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Bootstrapper();
                    }
                }

                return instance;
            }
        }
    }
}

