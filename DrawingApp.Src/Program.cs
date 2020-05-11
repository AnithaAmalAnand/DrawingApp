using System;
using DrawingApp.Factories;
using DrawingApp.Interfaces;
using DrawingApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DrawingApp
{
    public class Program
    {
        private static IServiceProvider _provider;
        public static void Main()
        {
            _provider = BuildDependencies().BuildServiceProvider();

            var shapesProcessor = _provider.GetService<IShapesProcessor>();
            shapesProcessor.Process();
        }

        private static IServiceCollection BuildDependencies()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(opt => opt.AddConsole().SetMinimumLevel(LogLevel.Debug));
            serviceCollection.AddScoped<ILoggerFactory, LoggerFactory>();
            serviceCollection.AddScoped<IShapesProcessor, ShapesProcessor>();
            serviceCollection.AddScoped<IShapeObjectFactory, ShapeObjectFactory>();
            serviceCollection.AddSingleton<IConsoleBuffer, ConsoleBuffer>();
            serviceCollection.AddSingleton<IConsole, ConsoleImpl>();
            return serviceCollection;
        }

    }
}
