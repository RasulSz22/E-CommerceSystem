using E_CommerceSystem.Entities.Common;

namespace E_CommerceSystem.Entities.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public List<Product> Products { get; set; }
        public Category()
        {
            Children = new List<Category>();
        }
    }
}



