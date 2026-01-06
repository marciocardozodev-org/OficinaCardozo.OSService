// Program.cs - PADRÃO LAMBDA COM CreateHostBuilder
using Microsoft.OpenApi.Models;

namespace OficinaCardozo.API;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices((context, services) =>
                {
                    // ✅ Serviços mínimos
                    services.AddControllers();
                    services.AddEndpointsApiExplorer();
                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "Oficina Cardozo API - Lambda",
                            Version = "v1"
                        });
                    });
                });

                webBuilder.Configure((context, app) =>
                {
                    // ✅ Log para CloudWatch
                    Console.WriteLine("=== LAMBDA COM CreateHostBuilder INICIANDO ===");
                    Console.WriteLine($"Environment: {context.HostingEnvironment.EnvironmentName}");

                    // ✅ Swagger SEMPRE disponível
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Oficina Cardozo API v1");
                        c.RoutePrefix = string.Empty; // Swagger na raiz
                    });

                    // ✅ Middleware pipeline
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });

                    Console.WriteLine("=== LAMBDA COM CreateHostBuilder PRONTO ===");
                });
            });
}
