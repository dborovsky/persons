using Persons.Abstractions.Data;
using Persons.Abstractions.Dto;

namespace Persons.Abstractions.Commands
{
    public class SavePersonCommand : ICommand<CommandResponce>
    {
        public string Name { get; set; }
        public PersonDetail Person { get; protected set; }
        public SavePersonCommand(PersonDetail person)
        {
            Person = person;
        }
    }
}
