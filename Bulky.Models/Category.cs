using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Bulky.Models
{
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }
		[Required]
		[MaxLength(100)]
		[DisplayName("Category Name")]
		public string Name { get; set; }
        [DisplayName("Display Order")]
		[Range(1,100)]
        public int DisplayOrder { get; set; }


	}
}

