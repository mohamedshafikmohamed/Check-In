using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Check_In.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string Name  { get; set; }
        [Required]
        [EmailAddress]
        public string Email  { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public int Age { get; set; }
        
      
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Position { get; set; }
        public IFormFile Army_Certificate { get; set; }
        public IFormFile Criminal_Case_Newspaper { get; set; }
        public IFormFile University_Certificate { get; set; }
        public IFormFile birth_Certificate { get; set; }

    }
}
