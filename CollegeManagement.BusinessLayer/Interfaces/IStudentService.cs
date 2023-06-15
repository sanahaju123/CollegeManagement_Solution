using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateStudent(Student student);
        Task<Student> GetStudentById(long studentId);
        Task<Student> SearchStudentByName(string name);
        Task<bool> DeleteStudentById(long studentId);
        Task<Student> UpdateStudent(StudentViewModel model);
        Task<IEnumerable<Student>> GetAllStudents();
    }
}
