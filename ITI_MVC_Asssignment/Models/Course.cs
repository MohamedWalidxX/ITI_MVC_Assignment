using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.Models;

public class Course
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter your name")]
    [StringLength(maximumLength:50, ErrorMessage = "Your name must not exceed 50 letters")]
    [MinLength(2, ErrorMessage = "Your name must be at least two letters")]
    [DisplayName("Nameee")]
    [Remote(action: "IsUnique", controller: "Course", ErrorMessage ="Your name is not unique", AdditionalFields ="Id")]
    public String Name { get; set; } 

    [Required(ErrorMessage = "Enter the degree of the course")]
    [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
    [DisplayName("Degree")]
    public double Degree { get; set; }

    [Required(ErrorMessage ="Enter the minimum degree of the course")]
    [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
    [DisplayName("Minimum Degree")]
    public double MinimumDegree { get; set; }
    public List<Instructor> Instructors { get; set; }

    [Required(ErrorMessage ="Select the course department")]
    [Range(1, double.MaxValue, ErrorMessage = "Choose the course department")]
    [DisplayName("Course Department")]
    public int DepartmentId { get; set; } 
    public Department? DepartmentNavigation { get; set; }
    public List<CourseResult> CourseResults { get; set; }
    
    
}
