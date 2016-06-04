using LightInject;

namespace Book.Repository.modules
{
    public class ModuleCompositionRoot: ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register(typeof(IGenericRepository<>), typeof(MongoRepository<>), new PerContainerLifetime());
        }
    }
}
