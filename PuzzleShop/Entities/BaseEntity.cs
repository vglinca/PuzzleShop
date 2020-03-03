using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }        
    }
}