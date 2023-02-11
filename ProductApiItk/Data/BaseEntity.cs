using System.ComponentModel.DataAnnotations;

namespace ProductApiItk.Data
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
