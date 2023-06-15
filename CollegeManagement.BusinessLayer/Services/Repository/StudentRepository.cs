using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.DataLayer;
using CollegeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.BusinessLayer.Services.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public StudentRepository(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            try
            {
                var result = await _collegeDbContext.Students.AddAsync(student);
                await _collegeDbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteStudentById(long studentId)
        {
            try
            {
                _collegeDbContext.Remove(_collegeDbContext.Students.Single(a => a.StudentId == studentId));
                _collegeDbContext.SaveChanges();
                return true;
             }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            try
            {
                var result = _collegeDbContext.Students.
                OrderByDescending(x => x.StudentId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Student> GetStudentById(long studentId)
        {
            try
            {
                return await _collegeDbContext.Students.FindAsync(studentId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Student> SearchStudentByName(string name)
        {
            try
            {
                return await _collegeDbContext.Students.FindAsync(name);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Student> UpdateStudent(StudentViewModel model)
        {
            var student = await _collegeDbContext.Students.FindAsync(model.StudentId);
            try
            {
                student.StudentId = model.StudentId;
                student.StudentName = model.StudentName;
                student.DepartmentName = model.DepartmentName;

                _collegeDbContext.Students.Update(student);
                await _collegeDbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
