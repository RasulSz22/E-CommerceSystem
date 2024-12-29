using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Pagenation
{
    public class Pagenation<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }

        //public PagedResult(List<T> items, int count, int pageIndex, int pageSize)
        //{
        //    Items = items;
        //    TotalCount = count;
        //    TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        //    CurrentPage = pageIndex;
        //    PageSize = pageSize;
        //}
        //public PagedResult()
        //{

        //}
    }
}
