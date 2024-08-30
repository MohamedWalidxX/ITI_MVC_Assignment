using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;
using ITI_MVC_Asssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult IsUnique(String name, int Id){
            using AppDbContext context = new AppDbContext();
            Course? target = context.Courses.FirstOrDefault(c => c.Name == name);
            if (target == null || Id == target.Id){
                return Json(true);
            }
            return Json(false);
        }
        public ActionResult Index()
        {
            using AppDbContext context = new AppDbContext();
            List<Course> courses = context.Courses.ToList();
            return View(courses);
        }
        [HttpGet]
        public ActionResult New(){
            using AppDbContext context = new AppDbContext();
            List<Department> allDepartments = context.Departments.ToList();
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel{
                AllDepartments = allDepartments
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Course course){
            using AppDbContext context = new AppDbContext();
            ModelState.Remove("Instructors");
            ModelState.Remove("CourseResults");
            if (ModelState.IsValid){
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Department> allDepartments = context.Departments.ToList();
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel{
                AllDepartments = allDepartments,
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinimumDegree = course.MinimumDegree,
                DepartmentId = course.DepartmentId
            };
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Edit(int Id){
            using AppDbContext context = new AppDbContext();
            List<Department> allDepartments = context.Departments.ToList();
            Course targetCourse = context.Courses.FirstOrDefault(c => c.Id == Id)!;
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel{
                Id = targetCourse.Id,
                Name = targetCourse.Name,
                Degree = targetCourse.Degree,
                MinimumDegree = targetCourse.MinimumDegree,
                DepartmentId = targetCourse.DepartmentId,
                AllDepartments = allDepartments
            };
            return View(model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course){
            ModelState.Remove("Instructors");
            ModelState.Remove("CourseResults");
            using AppDbContext context = new AppDbContext();
            List<Department> allDepartments = context.Departments.ToList();
            if (ModelState.IsValid){
                Course targetCourse = context.Courses.FirstOrDefault(c => c.Id == course.Id)!;
                targetCourse.Name = course.Name;
                targetCourse.Degree = course.Degree;
                targetCourse.MinimumDegree = course.MinimumDegree;
                targetCourse.DepartmentId = course.DepartmentId;
                context.SaveChanges();
            }
            CourseDepartment_ViewModel model = new CourseDepartment_ViewModel{
                Id = course.Id,
                Name = course.Name,
                Degree = course.Degree,
                MinimumDegree = course.MinimumDegree,
                DepartmentId = course.DepartmentId,
                AllDepartments = allDepartments
            };
            return View(model);
        }
    }
}
