using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;

namespace ProductApiItk.Data
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
