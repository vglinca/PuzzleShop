using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }        
    }
}