using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The {0} field must have minimun value of {1}")]
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public int StockQuantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The {0} field must have minimun value of {1}")]
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public int Height { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The {0} field must have minimun value of {1}")]
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public int Width { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The {0} field must have minimun value of {1}")]
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public int Depth { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
