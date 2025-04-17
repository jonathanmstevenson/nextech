using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
    }
}