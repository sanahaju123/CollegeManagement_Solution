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
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            return await _studentRepository.CreateStudent(student);
        }

        public async Task<bool> DeleteStudentById(long studentId)
        {
            return await _studentRepository.DeleteStudentById(studentId);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(long studentId)
        {
            return await _studentRepository.GetStudentById(studentId);
        }

        public async Task<Student> SearchStudentByName(string name)
        {
            return await _studentRepository.SearchStudentByName(name);
        }

        public async Task<Student> UpdateStudent(StudentViewModel model)
        {
            return await _studentRepository.UpdateStudent(model);
        }
    }
}
