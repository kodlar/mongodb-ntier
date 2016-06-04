using LightInject;

namespace Book.Services.modules
{
    public class ModuleCompositionRoot:ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IBookService,BookService>(new PerScopeLifetime());
        }
    }
}
