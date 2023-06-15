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
    public class TeacherRepository:ITeacherRepository
    {
        private readonly CollegeDbContext _collegeDbContext;
        public TeacherRepository(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            try
            {
                var result = await _collegeDbContext.Teachers.AddAsync(teacher);
                await _collegeDbContext.SaveChangesAsync();
                return teacher;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteTeacherById(long teacherId)
        {
            try
            {
                _collegeDbContext.Remove(_collegeDbContext.Teachers.Single(a => a.TeacherId == teacherId));
                _collegeDbContext.SaveChanges();
                return true;
             }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            try
            {
                var result = _collegeDbContext.Teachers.
                OrderByDescending(x => x.TeacherId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Teacher> GetTeacherById(long teacherId)
        {
            try
            {
                return await _collegeDbContext.Teachers.FindAsync(teacherId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Teacher> SearchTeacherByName(string name)
        {
            try
            {
                return await _collegeDbContext.Teachers.FindAsync(name);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Teacher> UpdateTeacher(TeacherViewModel model)
        {
            var teacher = await _collegeDbContext.Teachers.FindAsync(model.TeacherId);
            try
            {
                teacher.TeacherName = model.TeacherName;
                teacher.DepartmentName = model.DepartmentName;

                _collegeDbContext.Teachers.Update(teacher);
                await _collegeDbContext.SaveChangesAsync();
                return teacher;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
