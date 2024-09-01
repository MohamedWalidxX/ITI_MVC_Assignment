using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;
using ITI_MVC_Asssignment.Repository;
using ITI_MVC_Asssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.Controllers
{
    public class CourseController : Controller
    {
        public ICourseRepository CourseRepo { get; set; }
        public IDepartmentRepository DepartmentRepo { get; set; }
        public CourseController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            CourseRepo = courseRepository;
            DepartmentRepo = departmentRepository;
        }
        public IActionResult IsUnique(String name, int Id){
            
            Course? target = CourseRepo.GetByName(name);
            if (target == null || Id == target.Id){
                return Json(true);
            }
            return Json(false);
        }
        public ActionResult Index() => View(CourseRepo.GetAll().ToList());

        [HttpGet]
        public ActionResult New(){
            List<Department> allDepartments = DepartmentRepo.GetAll().ToList();
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel(new Course(), allDepartments);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Course course){
            ModelState.Remove("Instructors");
            ModelState.Remove("CourseResults");
            if (ModelState.IsValid){
                CourseRepo.Insert(course);
                return RedirectToAction("Index");
            }
            List<Department> allDepartments = DepartmentRepo.GetAll().ToList();
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel(course, allDepartments);
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Edit(int Id){
            List<Department> allDepartments = DepartmentRepo.GetAll().ToList();
            Course targetCourse = CourseRepo.GetById(Id);
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel(targetCourse, allDepartments);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course){
            ModelState.Remove("Instructors");
            ModelState.Remove("CourseResults");
            List<Department> allDepartments = DepartmentRepo.GetAll().ToList();
            if (ModelState.IsValid){
                CourseRepo.Update(course);
                return RedirectToAction("Index");
            }
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel(course, allDepartments);
            return View(model);
        }
    }
}
