using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.Helper
{
    public class PaginationList<T>
    {
        public int Total { get; set; }
        public int Size { get; set; }
        public int Index { get; set; }
        public int Pages { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();


        public PaginationList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Total = count;
            Size = pageSize;
            Index = pageNumber;
            Pages = (int)Math.Ceiling(count / (double)pageSize);
            Data = items.AsEnumerable();
        }

        public static async Task<PaginationList<T>> CreateAsync(IQueryable<T> source,
            int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginationList<T>(items, count, pageNumber, pageSize);
        }
    }
}
