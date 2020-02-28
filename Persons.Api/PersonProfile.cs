using AutoMapper;
using Persons.Abstractions.Data;
using Persons.Abstractions.Dto;

namespace Persons.Api.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDetail>();
        }
    }
}