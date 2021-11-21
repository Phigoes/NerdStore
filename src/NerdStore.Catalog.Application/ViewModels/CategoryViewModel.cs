using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalog.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public int CodeNumber { get; set; }
    }
}