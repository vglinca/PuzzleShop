using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PuzzleShop.Api.Models.Images
{
    public class ImageUpdateModel
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}