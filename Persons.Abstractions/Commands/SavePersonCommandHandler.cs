using Persons.Abstractions.Data;
using System;

namespace Persons.Abstractions.Commands
{
    public class SavePersonCommandHandler : ICommandHandler<SavePersonCommand, CommandResponce>
    {
        private readonly SavePersonCommand _command;
        public SavePersonCommandHandler(SavePersonCommand comm)
        {
            _command = comm;
        }

        public CommandResponce Execute()
        {
            var responce = new CommandResponce
            {
                Success = false
            };

            try
            {
                var person = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = _command.Person.Name,
                    BirthDay = _command.Person.BirthDay
                };
                MockPersonDatabase.Persons.Add(person);

                responce.ID = person.Id;
                responce.Success = true;
                responce.Message = "Person saved.";
            }
            catch
            { }

            return responce;
        }
    }
}
