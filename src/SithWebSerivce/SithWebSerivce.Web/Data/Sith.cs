using System.ComponentModel.DataAnnotations;

namespace SithWebSerivce.Web.Data
{
    public class Sith
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
