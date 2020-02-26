using Persons.Abstractions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var item = MockPersonDatabase
                    .Persons
                    .FirstOrDefault(p => p.Id == _command.Person.Id);

                if (item == null)
                {
                    item = new Person
                    {
                        Id = Guid.NewGuid(),
                        Name = _command.Person.Name,
                        Age = _command.Person.Age
                    };
                    MockPersonDatabase.Persons.Add(item);
                }
                else
                {
                    item.Name = _command.Person.Name;
                    item.Age = _command.Person.Age;
                }

                responce.ID = item.Id;
                responce.Success = true;
                responce.Message = "Person saved.";
            }
            catch
            { }

            return responce;
        }
    }
}
