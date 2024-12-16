﻿using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI.Modal
{
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Standard { get; set; }
        [Required]
        public string EmailAddress { get; set; }
    }
}
