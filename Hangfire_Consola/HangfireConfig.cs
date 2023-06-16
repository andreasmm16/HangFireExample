using Hangfire;
using Hangfire.SQLite;
using Microsoft.Extensions.DependencyInjection;
using SQLite;
using System;
using System.Data.SQLite;
using System.IO;

public class HangfireConfig
{
    public static void ConfigureHangfire()
    {
        var dbFilePath = "hangfire.db"; // Ruta y nombre de archivo de la base de datos SQLite

        var connectionString = $"Data Source={dbFilePath}";

        // Crear la base de datos si no existe
        CreateHangfireDatabase(dbFilePath);

        GlobalConfiguration.Configuration.UseSQLiteStorage(connectionString);

        using (var serviceProvider = new ServiceCollection()
            .AddHangfire(config =>
            {
                config.UseSQLiteStorage(connectionString);
            })
            .BuildServiceProvider())
        {
            var backgroundJobClient = serviceProvider.GetService<IBackgroundJobClient>();

            RecurringJob.AddOrUpdate("recurringJob", () => Console.WriteLine("Trabajo en segundo plano"), "* * * * * *");

            using (new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server iniciado. Presiona cualquier tecla para salir.");
                Console.ReadKey();
            }
        }
    }

    private static void CreateHangfireDatabase(string dbFilePath)
    {
        if (!File.Exists(dbFilePath))
        {
            SQLiteConnection.
        }
    }
}
