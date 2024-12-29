using E_CommerceSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DTOs.CategoryDTO
{
    public class CategoryGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> ChildrenIds { get; set; }
        public List<int> ProductIds { get; set; }
        public CategoryGetDTO()
        {
            ChildrenIds = new List<int>();
            ProductIds = new List<int>();
        }

    }
}

