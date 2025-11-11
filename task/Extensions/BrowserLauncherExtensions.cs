using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using task.core.Interfaces.Services;

namespace task.infraestructure.Extensions
{
    public static class BrowserLauncherExtensions
    {
        public static WebApplication UseScalarBrowserLauncher(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                _ = Task.Run(async () =>
                {
                    await Task.Delay(3000);

                    try
                    {
                        var httpsUrl = app.Urls.FirstOrDefault(u => u.StartsWith("https"))
                                      ?? app.Urls.FirstOrDefault()
                                      ?? "https://localhost:7234";

                        var scalarUrl = $"{httpsUrl}/scalar/v1";

                        var process = Process.Start(new ProcessStartInfo
                        {
                            FileName = scalarUrl,
                            UseShellExecute = true
                        });

                        if (process != null)
                        {

                            var logService = app.Services.GetService<ILogService>();
                            if (logService != null)
                            {
                                await logService.LogSuccessAsync($"Navegador abierto en: {scalarUrl}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("⚠️ No se pudo iniciar el proceso del navegador\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        var logService = app.Services.GetService<ILogService>();
                        if (logService != null)
                        {
                            await logService.LogErrorAsync("Error al abrir navegador automáticamente", ex);
                        }
                    }
                });
            }

            return app;
        }

        public static WebApplication UseBrowserLauncher(
            this WebApplication app,
            string url)
        {
            if (app.Environment.IsDevelopment())
            {

                _ = Task.Run(async () =>
                {
                    await Task.Delay(2000);

                    try
                    {

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });


                        var logService = app.Services.GetService<ILogService>();
                        if (logService != null)
                        {
                            await logService.LogSuccessAsync($"Navegador abierto en: {url}");
                        }
                    }
                    catch (Exception ex)
                    {
                        var logService = app.Services.GetService<ILogService>();
                        if (logService != null)
                        {
                            await logService.LogErrorAsync($"Error al abrir navegador en {url}", ex);
                        }
                    }
                });
            }

            return app;
        }
    }
}