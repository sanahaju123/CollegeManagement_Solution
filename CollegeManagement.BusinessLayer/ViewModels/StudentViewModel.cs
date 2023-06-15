using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeManagement.BusinessLayer.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public Department DepartmentName { get; set; }
    }
}
