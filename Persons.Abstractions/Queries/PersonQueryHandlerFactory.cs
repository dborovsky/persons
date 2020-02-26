using AutoMapper;
using Persons.Abstractions.Data;
using Persons.Abstractions.Dto;

namespace Persons.Abstractions.Queries
{
    public static class PersonQueryHandlerFactory
    {
        public static IQueryHandler<FindPersonQuery, PersonDetail> Build(FindPersonQuery query, IRepository repo, IMapper mapper)
        {
            return new FindPersonQueryHandler(query, repo, mapper);
        }
    }
}
