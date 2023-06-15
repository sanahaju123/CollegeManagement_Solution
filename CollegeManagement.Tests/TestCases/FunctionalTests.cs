
using CollegeManagement.BusinessLayer.Interfaces;
using CollegeManagement.BusinessLayer.Services;
using CollegeManagement.BusinessLayer.Services.Repository;
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
     public class FunctionalTests
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

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _studentService = new StudentService(studentservice.Object);
            _teacherService = new TeacherService(teacherservice.Object);
            _departmentService = new DepartmentService(departmentservice.Object);

            _output = output;

            _student = new Student
            {
               StudentId= 1,
               StudentName="Manav",
               DepartmentName=new Department {DepartmentName= "Science" }
            };
            _teacher = new Teacher
            {
                TeacherId = 1,
                TeacherName = "Kavita",
                DepartmentName = new Department { DepartmentName = "Commerce" }
            };
            _department = new Department
            {
                DepartmentId=1,
                DepartmentName="Arts"
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
        
       
        [Fact]
        public async Task<bool> Testfor_Create_Department()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                departmentservice.Setup(repos => repos.CreateDepartment(_department)).ReturnsAsync(_department);
                var result = await _departmentService.CreateDepartment(_department);
                //Assertion
                if (result != null)
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

        
        [Fact]
        public async Task<bool> Testfor_Update_Department()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateDepartment = new DepartmentViewModel()
            {
               DepartmentId=1,
               DepartmentName="Scienece"
            };

            //Action
            try
            {
                departmentservice.Setup(repos => repos.UpdateDepartment(_departmentViewModel)).ReturnsAsync(_department); 
                var result = await _departmentService.UpdateDepartment(_departmentViewModel);
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_GetAll_Departments()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                departmentservice.Setup(repos => repos.GetAllDepartments());
                var result = await _departmentService.GetAllDepartments();
                //Assertion
                if (result != null)
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

        
        [Fact]
        public async Task<bool> Testfor_GetDepartmentById()
        {
            //Arrange
            var res = false;
            int departmentId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                departmentservice.Setup(repos => repos.GetDepartmentById(departmentId)).ReturnsAsync(_department);
                var result = await _departmentService.GetDepartmentById(departmentId);
                //Assertion
                if (result != null)
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

        [Fact]
        public async Task<bool> Testfor_SearchDepartmentByName()
        {
            //Arrange
            var res = false;
            string departmentName = "Arts";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                departmentservice.Setup(repos => repos.SearchDepartmentByName(departmentName)).ReturnsAsync(_department);
                var result = await _departmentService.SearchDepartmentByName(departmentName);
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_DeleteDepartmentById()
        {
            //Arrange
            var res = false;
            int departmentId = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                departmentservice.Setup(repos => repos.DeleteDepartmentById(departmentId)).ReturnsAsync(response);
                var result = await _departmentService.DeleteDepartmentById(departmentId);
                //Assertion
                if (result != null)
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
        [Fact]
        public async Task<bool> Testfor_Create_Student()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                studentservice.Setup(repos => repos.CreateStudent(_student)).ReturnsAsync(_student);
                var result = await _studentService.CreateStudent(_student);
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_Update_Student()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateStudent = new StudentViewModel()
            {
                StudentId = 1,
                StudentName = "Scienece"
            };

            //Action
            try
            {
                studentservice.Setup(repos => repos.UpdateStudent(_studentViewModel)).ReturnsAsync(_student);
                var result = await _studentService.UpdateStudent(_studentViewModel);
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_GetAll_Students()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                studentservice.Setup(repos => repos.GetAllStudents());
                var result = await _studentService.GetAllStudents();
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_GetStudentById()
        {
            //Arrange
            var res = false;
            int studentId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                studentservice.Setup(repos => repos.GetStudentById(studentId)).ReturnsAsync(_student);
                var result = await _studentService.GetStudentById(studentId);
                //Assertion
                if (result != null)
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

        [Fact]
        public async Task<bool> Testfor_SearchStudentByName()
        {
            //Arrange
            var res = false;
            string studentName = "Arts";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                studentservice.Setup(repos => repos.SearchStudentByName(studentName)).ReturnsAsync(_student);
                var result = await _studentService.SearchStudentByName(studentName);
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_DeleteStudentById()
        {
            //Arrange
            var res = false;
            int studentId = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                studentservice.Setup(repos => repos.DeleteStudentById(studentId)).ReturnsAsync(response);
                var result = await _studentService.DeleteStudentById(studentId);
                //Assertion
                if (result != null)
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
        [Fact]
        public async Task<bool> Testfor_Create_Teacher()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                teacherservice.Setup(repos => repos.CreateTeacher(_teacher)).ReturnsAsync(_teacher);
                var result = await _teacherService.CreateTeacher(_teacher);
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_Update_Teacher()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateTeacher = new TeacherViewModel()
            {
                TeacherId = 1,
                TeacherName = "Scienece"
            };

            //Action
            try
            {
                teacherservice.Setup(repos => repos.UpdateTeacher(_teacherViewModel)).ReturnsAsync(_teacher);
                var result = await _teacherService.UpdateTeacher(_teacherViewModel);
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_GetAll_Teachers()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                teacherservice.Setup(repos => repos.GetAllTeachers());
                var result = await _teacherService.GetAllTeachers();
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_GetTeacherById()
        {
            //Arrange
            var res = false;
            int teacherId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                teacherservice.Setup(repos => repos.GetTeacherById(teacherId)).ReturnsAsync(_teacher);
                var result = await _teacherService.GetTeacherById(teacherId);
                //Assertion
                if (result != null)
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

        [Fact]
        public async Task<bool> Testfor_SearchTeacherByName()
        {
            //Arrange
            var res = false;
            string teacherName = "Arts";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                teacherservice.Setup(repos => repos.SearchTeacherByName(teacherName)).ReturnsAsync(_teacher);
                var result = await _teacherService.SearchTeacherByName(teacherName);
                //Assertion
                if (result != null)
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


        [Fact]
        public async Task<bool> Testfor_DeleteTeacherById()
        {
            //Arrange
            var res = false;
            int teacherId = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                teacherservice.Setup(repos => repos.DeleteTeacherById(teacherId)).ReturnsAsync(response);
                var result = await _teacherService.DeleteTeacherById(teacherId);
                //Assertion
                if (result != null)
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