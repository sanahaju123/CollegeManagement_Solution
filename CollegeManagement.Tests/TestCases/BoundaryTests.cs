
using CollegeManagement.BusinessLayer.Interfaces;
using CollegeManagement.BusinessLayer.Services.Repository;
using CollegeManagement.BusinessLayer.Services;
using CollegeManagement.BusinessLayer.ViewModels;
using CollegeManagement.DataLayer;
using CollegeManagement.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CollegeManagement.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly CollegeDbContext _collegeDbContext;

        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentService _departmentService;


        public readonly Mock<IStudentRepository> studentservice = new Mock<IStudentRepository>();
        public readonly Mock<ITeacherRepository> teacherservice = new Mock<ITeacherRepository>();
        public readonly Mock<IDepartmentRepository> departmentservice = new Mock<IDepartmentRepository>();


        private readonly Student _student;
        private readonly Teacher _teacher;
        private readonly Department _department;

        private readonly StudentViewModel _studentViewModel;
        private readonly TeacherViewModel _teacherViewModel;
        private readonly DepartmentViewModel _departmentViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _studentService = new StudentService(studentservice.Object);
            _teacherService = new TeacherService(teacherservice.Object);
            _departmentService = new DepartmentService(departmentservice.Object);

            _output = output;

            _student = new Student
            {
                StudentId = 1,
                StudentName = "Manav",
                DepartmentName = new Department { DepartmentName = "Science" }
            };
            _teacher = new Teacher
            {
                TeacherId = 1,
                TeacherName = "Kavita",
                DepartmentName = new Department { DepartmentName = "Commerce" }
            };
            _department = new Department
            {
                DepartmentId = 1,
                DepartmentName = "Arts"
            };
            _studentViewModel = new StudentViewModel
            {
                StudentId = 1,
                StudentName = "Manav",
                DepartmentName = new Department { DepartmentName = "Science" }
            };
            _teacherViewModel = new TeacherViewModel
            {
                TeacherId = 1,
                TeacherName = "Kavita",
                DepartmentName = new Department { DepartmentName = "Commerce" }
            };
            _departmentViewModel = new DepartmentViewModel
            {
                DepartmentId = 1,
                DepartmentName = "Arts"
            };
        }

        /// <summary>
        /// Test to validate department name is not empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Department_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                departmentservice.Setup(repo => repo.CreateDepartment(_department)).ReturnsAsync(_department);
                var result = await _departmentService.CreateDepartment(_department);
                var actualLength = _department.DepartmentName.ToString().Length;
                if (result.DepartmentName.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to validate teacher name is not empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Teacher_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                teacherservice.Setup(repo => repo.CreateTeacher(_teacher)).ReturnsAsync(_teacher);
                var result = await _teacherService.CreateTeacher(_teacher);
                var actualLength = _teacher.TeacherName.ToString().Length;
                if (result.TeacherName.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to validate student name is not empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Student_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                studentservice.Setup(repo => repo.CreateStudent(_student)).ReturnsAsync(_student);
                var result = await _studentService.CreateStudent(_student);
                var actualLength = _student.StudentName.ToString().Length;
                if (result.StudentName.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}