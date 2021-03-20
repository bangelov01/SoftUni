using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string commandSuffix = "Command";
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == $"{commandType}{commandSuffix}");

            if (type == null)
            {
                throw new ArgumentException("Command type is invalid!");
            }

            return (ICommand)Activator.CreateInstance(type);
        }
    }
}
