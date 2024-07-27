using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models
{
	public class Product
	{
		[Key]
		public int PId { get; set; }
		[Required]
		public string Title {get; set;}
		public string Description { get; set; }
		[Required]
		public string ISBN { get; set; }
		[Required]
		public string Author { get; set; }

		[Required]
		[Display(Name="List Price")]
		[Range(1,1000)]
		public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 0-50")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "Price for 100+ ")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

		public int CategoryID { get; set; }
        [ValidateNever]
        [ForeignKey("CategoryID")]
		public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}

