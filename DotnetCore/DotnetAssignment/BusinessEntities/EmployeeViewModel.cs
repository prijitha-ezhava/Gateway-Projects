using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    public class EmployeeViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        [DisplayName("Is Manager")]
        public bool IsManager { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
