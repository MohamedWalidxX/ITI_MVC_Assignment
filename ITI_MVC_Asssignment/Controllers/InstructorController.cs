using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;
using ITI_MVC_Asssignment.Repository;
using ITI_MVC_Asssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.Controllers
{
public class InstructorController : Controller
    {
        public IInstructorRepository InstructorRepo { get; set; }
        public ICourseRepository CourseRepo { get; set; }

        public IDepartmentRepository DepartmentRepo { get; set; }

        public InstructorController(IInstructorRepository instructorRepository, ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            InstructorRepo = instructorRepository;
            CourseRepo = courseRepository;
            DepartmentRepo = departmentRepository;
        }
        public IActionResult Index() => View(InstructorRepo.GetAll().ToList());
        public IActionResult New(){
            List<Department> allDepartments = DepartmentRepo.GetAll().ToList();
            List<Course> allCourses = CourseRepo.GetAll().ToList();
            return View("Edit", new InstructorDepartmentCourse_ViewModel(allDepartments, allCourses));
        }
        public IActionResult Edit(int Id){
            List<Department> allDepartments = DepartmentRepo.GetAll().ToList();
            List<Course> allCourses = CourseRepo.GetAll().ToList();
            if (Id == 0){
                return View(new InstructorDepartmentCourse_ViewModel(allDepartments, allCourses));
            }
            Instructor? targetInstructor = InstructorRepo.GetById(Id);
            return View(new InstructorDepartmentCourse_ViewModel(targetInstructor, allDepartments, allCourses));
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
            if (instructor.Name == default || instructor.Address == default){
                return View("Edit", new InstructorDepartmentCourse_ViewModel(instructor, DepartmentRepo.GetAll().ToList(), CourseRepo.GetAll().ToList()));
            }
            if (instructor.Id == 0){
                InstructorRepo.Insert(instructor);
                return RedirectToAction("Index");   
            }
            InstructorRepo.Update(instructor);
            return RedirectToAction("Index");
        }
    }
}


