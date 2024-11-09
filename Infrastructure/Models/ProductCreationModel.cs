using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RikaApp.Models
{
    public class ProductCreationModel
    {
        public ProductCreationModel()
        {
            
            SizeNames = new List<string> { "S", "M", "L", "XL" };
            ColorNames = new List<string> { "Red", "Blue", "Green", "Yellow", "Black", "White", "Purple", "Orange", "Pink", "Gray" };
        }
        [Required]
        public string Title { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? Ingress { get; set; }

        public string? Manufacturer { get; set; }

        public string? PrimaryImage { get; set; }

        public List<string>? SizeNames { get; set; }

        public List<string>? ColorNames { get; set; }

        public int? Stock { get; set; }
    }
}
