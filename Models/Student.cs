using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsWebApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Midlename { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }

        public string Fio => Surname + ' ' + Name + ' ' + Midlename;
    }
}
