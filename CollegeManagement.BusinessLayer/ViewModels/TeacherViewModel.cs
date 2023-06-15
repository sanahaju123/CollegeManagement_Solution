using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeManagement.BusinessLayer.ViewModels
{
    public class TeacherViewModel
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Department DepartmentName { get; set; }
    }
}
