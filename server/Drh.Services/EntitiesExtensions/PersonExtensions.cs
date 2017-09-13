using Drh.Dtos;
using Drh.Entities;

namespace Drh.Services.EntitiesExtensions
{
    public static class PersonExtensions
    {
        public static PersonDto ToPersonDto(this Person item)
        {
            return new PersonDto
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
        }
    }
}