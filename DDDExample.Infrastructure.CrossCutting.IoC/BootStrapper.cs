using DDDExample.Application.App;
using DDDExample.Application.Interfaces;
using DDDExample.Domain.Interfaces.Repositories;
using DDDExample.Domain.Interfaces.Services;
using DDDExample.Domain.Services;
using DDDExample.Infrastructure.Data.Repositories;
using SimpleInjector;

namespace DDDExample.Infrastructure.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register(typeof(IAppBase<>), typeof(AppBase<>));
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            container.Register<IUsuarioApp, UsuarioApp>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);

            container.Register<IPerfilApp, PerfilApp>(Lifestyle.Scoped);
            container.Register<IPerfilService, PerfilService>(Lifestyle.Scoped);
            container.Register<IPerfilRepository, PerfilRepository>(Lifestyle.Scoped);

            container.Register<IEmailApp, EmailApp>(Lifestyle.Scoped);
            container.Register<IEmailService, EmailService>(Lifestyle.Scoped);
        }
    }
}