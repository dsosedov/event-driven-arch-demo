using System.ComponentModel.DataAnnotations;

namespace SithWebService.Web.Data
{
    public class Sith
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
