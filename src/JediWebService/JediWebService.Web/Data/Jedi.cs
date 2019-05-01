﻿using System.ComponentModel.DataAnnotations;

namespace JediWebService.Web.Data
{
    public class Jedi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
