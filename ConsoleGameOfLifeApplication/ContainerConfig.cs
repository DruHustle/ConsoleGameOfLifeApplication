using Autofac;
using ConsoleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<GameConsole>().As<IGameConsole>();
            builder.RegisterType<ReadInput>().As<IReadInput> ();
            builder.RegisterType<PrintOutput>().As<IPrintOutput>();
            builder.RegisterType<GameCount>().As<IGameCount>();
            builder.RegisterType<GameCreate>().As<IGameCreate>();
            builder.RegisterType<GameDraw>().As<IGameDraw>();
            builder.RegisterType<GameUpdate>().As<IGameUpdate>();
            builder.RegisterType<UserInput>().As<IUserInput>();
            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
