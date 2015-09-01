using System;
using System.Web;
using Miam.ApplicationsServices.Account;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Miam.Web.App_Start;
using Miam.Web.HttpServices;
using Miam.Web.Services;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Miam.Web.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //MiamDbContext
            kernel.Load(new MiamDBContextNinjectModule());

            //repositories
            kernel.Bind<IEntityRepository<Restaurant>>().To<EfEntityRepository<Restaurant>>().InRequestScope();
            kernel.Bind<IEntityRepository<Writer>>().To<EfEntityRepository<Writer>>().InRequestScope();
            kernel.Bind<IEntityRepository<ApplicationUser>>().To<EfEntityRepository<ApplicationUser>>().InRequestScope();
            kernel.Bind<IEntityRepository<Review>>().To<EfEntityRepository<Review>>().InRequestScope();

            //services
            kernel.Bind<IHttpContextService>().To<HttpContextService>().InRequestScope();
            kernel.Bind<IUserAccountService>().To<UserUserAccountService>().InRequestScope();

            //database
            kernel.Bind<IApplicationDatabaseHelper>().To<EfApplicationDatabaseHelper>().InRequestScope();
        }        
    }
}
