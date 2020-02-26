using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Commands
{
    public static class PersonCommandHandlerFactory
    {
        public static ICommandHandler<SavePersonCommand, CommandResponce> Build(SavePersonCommand command)
        {
            return new SavePersonCommandHandler(command);
        }
    }
}
