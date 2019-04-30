using System.ComponentModel.DataAnnotations;

namespace SwWebServiceRabbit.Web.Data
{
    public class Toon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Order Order { get; set; }
    }
}
