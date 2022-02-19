namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using SMS.Contracts;
    using SMS.Data;
    using SMS.Services;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IProductService, ProductService>()
                    .Add<IUserService, UserService>()
                    .Add<IValidatorService, ValidatorService>()
                    .Add<SMSDbContext>())
                .Start();
    }
}