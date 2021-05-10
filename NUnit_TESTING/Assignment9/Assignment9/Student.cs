using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9
{
    public class Student
    {
        public int Id;
        public string FirstName;
        public string LastName;

        public virtual List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    Id = 101,
                    FirstName = "Prijitha",
                    LastName = "Ezhava"
                },
                new Student
                {
                    Id = 102,
                    FirstName = "Raghav",
                    LastName = "Singh"
                },
                new Student
                {
                    Id = 103,
                    FirstName = "Nidhi",
                    LastName = "Fulpagar"
                }
            };
            return students;
        }
    }
}
