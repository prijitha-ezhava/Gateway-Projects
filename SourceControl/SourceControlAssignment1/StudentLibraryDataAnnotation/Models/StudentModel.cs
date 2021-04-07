using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentLibraryDataAnnotation.Custom_Annotation;

namespace StudentLibraryDataAnnotation.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please Enter Name!")]
        [Display(Name = "Student Name")]
        [StringLength(10, MinimumLength =5)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email Address!")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Number!")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10), MinLength(3)]
        public int Contact { get; set; }

        [Required(ErrorMessage ="Please Enter The Book Title")]
        [Display(Name = "Title Of Book")]
        [DataType(DataType.Text)]
        [MaxLength(10), MinLength(3)]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Please Enter Date Of Issue!")]
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        [DateRange("01/01/2000", ErrorMessage = "Date Must be in a range between 01/01/2000 to 26/11/2020")]
        [Display(Name = "Date Of Issue")]
        public DateTime DateOfIssue { get; set; }
    }

    public class  StudentsdbContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
    }
}

