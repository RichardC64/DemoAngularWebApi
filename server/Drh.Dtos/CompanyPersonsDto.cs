using System.Collections.Generic;

namespace Drh.Dtos
{
    public class CompanyPersonsDto
    {
        public CompanyPersonsDto(int id, string name, IEnumerable<PersonDto> persons, int totalCount)
        {
            Id = id;
            Name = name;
            Persons = persons;
            TotalCount = totalCount;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PersonDto> Persons { get; }
        public int TotalCount { get; set; }
    }
}