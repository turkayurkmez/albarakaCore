namespace POCDependencyLifeCycle.Services
{
    public class UseInjectedService
    {
        public ISingletonGuid Singleton { get; set; }
        public IScopedGuid Scoped { get; set; }
        public ITransientGuid Transient { get; set; }

        public UseInjectedService(ISingletonGuid singleton, IScopedGuid scoped, ITransientGuid transient)
        {
            Singleton = singleton;
            Scoped = scoped;
            Transient = transient;
        }
    }
}
