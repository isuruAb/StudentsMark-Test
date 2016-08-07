namespace MvcGeekAcademy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullNAme { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(12)]
        public string ContactNo { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Range(0,100)]
        public int FinalMarks { get; set; }
    }
}
