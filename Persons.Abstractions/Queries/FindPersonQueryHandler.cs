using Persons.Abstractions.Data;
using AutoMapper;
using Persons.Abstractions.Dto;

namespace Persons.Abstractions.Queries
{
    public class FindPersonQueryHandler : IQueryHandler<FindPersonQuery, PersonDetail>
    {
        private FindPersonQuery _query;
        private IRepository _repo;
        private IMapper _mapper;

        public FindPersonQueryHandler(FindPersonQuery query, 
            IRepository repo,
            IMapper mapper)
        {
            _query = query;
            _repo = repo;
            _mapper = mapper;
        }
        public PersonDetail Get()
        {
            var person = _repo.Find(_query.Id);
            var personDto =  _mapper.Map<Person, PersonDetail>(person);
            return personDto; 
        }
    }
}
