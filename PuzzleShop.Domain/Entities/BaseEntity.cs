using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }        
    }
}