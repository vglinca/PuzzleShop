using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }        
    }
}