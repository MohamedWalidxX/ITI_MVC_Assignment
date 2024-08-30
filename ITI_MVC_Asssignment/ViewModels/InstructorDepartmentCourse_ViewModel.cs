using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ITI_MVC_Asssignment.Models;

namespace ITI_MVC_Asssignment.ViewModels;

public class InstructorDepartmentCourse_ViewModel
{
    public int Id { get; set; }

    public String? Name { get; set; }
    public double Salary { get; set; }
    public String Address { get; set; }
    public String Image { get; set; }
    public int DepartmentId { get; set; }
    public List<Department> AllDepartments { get; set; }
    public int CourseId { get; set; }
    public List<Course> AllCourses { get; set; }
}
