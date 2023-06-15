using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(long teacherId);
        Task<Teacher> SearchTeacherByName(string name);
        Task<bool> DeleteTeacherById(long teacherId);
        Task<Teacher> UpdateTeacher(TeacherViewModel model);
        Task<IEnumerable<Teacher>> GetAllTeachers();
    }
}
