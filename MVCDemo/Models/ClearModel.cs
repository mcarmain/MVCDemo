using MVCDemo.Properties;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{

    public class ClearModel
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Clear Y/N ?")]
        public string Clear { get; set; }
    }
}