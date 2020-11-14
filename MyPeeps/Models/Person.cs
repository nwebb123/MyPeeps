using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyPeeps.Models
{
    public class Person 
    {
        public int Id { get; set; }
       
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public string ImagePath { get; set; }

        public byte[] ImageData { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public int Phone { get; set; }

        public DateTimeOffset Created { get; set; }




    }
}
