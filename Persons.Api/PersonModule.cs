using Nancy;
using Nancy.ModelBinding;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Data;
using Persons.Abstractions.Commands;
using AutoMapper;
using Persons.Abstractions.Dto;
using System;

namespace Persons.Api
{
    public class PersonModule : NancyModule
    {
        private IRepository _repo;
        private IMapper _mapper;
        
        public PersonModule(IRepository repo, IMapper mapper) : base("/api/v1")
        {
            _repo = repo;
            _mapper = mapper;

            Get("/persons/{id}", parameters =>
            {
                var query = new FindPersonQuery(parameters.id);
                var handler = PersonQueryHandlerFactory.Build(query, _repo, _mapper);
                return handler.Get(); 
            });

            Post("/persons/", parameters =>
            {
                var per = this.Bind<PersonNew>();
                PersonDetail person = new PersonDetail { Name = per.Name, BirthDay = DateTime.Parse(per.BirthDay) };
                var command = new SavePersonCommand(person);
                var handler = PersonCommandHandlerFactory.Build(command);
                var responce = handler.Execute();

                if (responce.Success)
                    return responce;
                return HttpStatusCode.BadRequest; 
            });
        }
    }
}