using CollegeManagement.BusinessLayer.Interfaces;
using CollegeManagement.BusinessLayer.Services.Repository;
using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Services
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            return await _teacherRepository.CreateTeacher(teacher);
        }

        public async Task<bool> DeleteTeacherById(long teacherId)
        {
            return await _teacherRepository.DeleteTeacherById(teacherId);
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _teacherRepository.GetAllTeachers();
        }

        public async Task<Teacher> GetTeacherById(long teacherId)
        {
            return await _teacherRepository.GetTeacherById(teacherId);
        }

        public async Task<Teacher> SearchTeacherByName(string name)
        {
            return await _teacherRepository.SearchTeacherByName(name);
        }

        public async Task<Teacher> UpdateTeacher(TeacherViewModel model)
        {
            return await _teacherRepository.UpdateTeacher(model);
        }
    }
}
