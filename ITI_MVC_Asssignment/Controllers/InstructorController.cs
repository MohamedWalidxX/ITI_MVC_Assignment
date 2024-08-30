using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;
using ITI_MVC_Asssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.Controllers
{
public class InstructorController : Controller
    {
        // GET: InstructorController
        public IActionResult Index()
        {
            using AppDbContext context = new AppDbContext();
            List<Instructor> instructors = context.Instructors.Where(i => i.Id == i.Id).ToList() ;
            return View(instructors);
        }
        public IActionResult New(){
            using AppDbContext context = new AppDbContext();
            List<Department> allDepartments = context.Departments.ToList();
            List<Course> allCourses = context.Courses.ToList();
            InstructorDepartmentCourse_ViewModel instructorDepartment = new InstructorDepartmentCourse_ViewModel(){
                AllDepartments = allDepartments,
                AllCourses = allCourses,
                Id = 0
            };
            return View("Edit", instructorDepartment);
        }
        public IActionResult Edit(int Id){
            using AppDbContext context = new AppDbContext();
            List<Department> allDepartments = context.Departments.ToList();
            List<Course> allCourses = context.Courses.ToList();
            if (Id == 0){
                return View(new InstructorDepartmentCourse_ViewModel(){AllDepartments = allDepartments, AllCourses = allCourses});
            }
            Instructor? targetInstructor = context.Instructors.FirstOrDefault(i => i.Id == Id);
            InstructorDepartmentCourse_ViewModel instructorDepartment = new InstructorDepartmentCourse_ViewModel(){
                Id = targetInstructor.Id,
                Name = targetInstructor.Name,
                Salary = targetInstructor.Salary,
                Image = targetInstructor.Image,
                DepartmentId = targetInstructor.DepartmentId,
                Address = targetInstructor.Address,
                AllDepartments = allDepartments,
                CourseId = targetInstructor.CourseId,
                AllCourses = allCourses
            };
            return View(instructorDepartment);
        }
        /// <summary>
        /// when the client click on save button on the Edit View from, This action will be called and 
        /// it will do one of three scenarios:
        ///     1- Do not accept the user information because its not complete
        ///     2- Accept the information and if its a new instructor with default Id = 0, then add new instructor
        ///     3- if its old instructor updating his information then do update operation
        /// 
        /// </summary>
        /// <param name="instructor"></param>
        /// 
        /// <returns>Instructor Index view</returns>
        public IActionResult SaveEdit(Instructor instructor){
            using AppDbContext context = new AppDbContext();
            if (instructor.Name == default || instructor.Address == default){
                return View("Edit", new InstructorDepartmentCourse_ViewModel(){
                    AllDepartments = context.Departments.ToList(),
                    AllCourses = context.Courses.ToList(),
                    Name = instructor.Name,
                    Salary = instructor.Salary,
                    Image = instructor.Image,
                    DepartmentId = instructor.DepartmentId,
                    CourseId = instructor.CourseId,
                    Address = instructor.Address
                });
            }
            if (instructor.Id == 0){
                context.Instructors.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");   
            }
            Instructor? targetInstructor = context.Instructors.FirstOrDefault(i => i.Id == instructor.Id);
            targetInstructor.Name = instructor.Name;
            targetInstructor.Address = instructor.Address;
            targetInstructor.DepartmentId = instructor.DepartmentId;
            targetInstructor.Image = instructor.Image;
            targetInstructor.Salary = instructor.Salary;
            targetInstructor.CourseId = instructor.CourseId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


