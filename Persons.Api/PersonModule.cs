using Nancy;
using Persons.Abstractions.Queries;
using Persons.Abstractions.Data;
using Persons.Abstractions.Commands;
using AutoMapper;

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
/*
            Post("/persons/", parameters =>
            {
                //var command = new SavePersonCommand();  //new FindPersonQuery(parameters.id);
                //var handler = PersonQueryHandlerFactory.Build(query, _repo);
                //return handler.Get();
            });
            */
        }
    }
}