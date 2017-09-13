using System.Collections.Generic;

namespace Drh.Entities.Infra
{
    public class PagedResult<T>
    {
        public PagedResult(IEnumerable<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
        public IEnumerable<T> Items { get;  }
        public int TotalCount { get; set; }
    }
}