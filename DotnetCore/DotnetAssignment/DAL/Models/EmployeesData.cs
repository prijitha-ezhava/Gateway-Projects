﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EmployeesData
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public bool IsManager { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
