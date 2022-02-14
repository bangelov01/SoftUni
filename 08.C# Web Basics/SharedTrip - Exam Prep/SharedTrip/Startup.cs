namespace SharedTrip
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SharedTrip.Contracts;
    using SharedTrip.Data;
    using SharedTrip.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<ApplicationDbContext>()
                .Add<IValidatorService, ValidatorService>()
                .Add<IUserService, UserService>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<ITripService, TripService>();

            await server.Start();
        }
    }
}
