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

    public InstructorDepartmentCourse_ViewModel(List<Department> departments, List<Course> courses)
    {
        AllDepartments = departments;
        AllCourses = courses;
    }

    public InstructorDepartmentCourse_ViewModel(Instructor targetInstructor, List<Department> departments, List<Course> courses):this(departments,courses)
    {
        Id = targetInstructor.Id;
        Name = targetInstructor.Name;
        Salary = targetInstructor.Salary;
        Image = targetInstructor.Image;
        DepartmentId = targetInstructor.DepartmentId;
        Address = targetInstructor.Address;
        CourseId = targetInstructor.CourseId;
    }
}
