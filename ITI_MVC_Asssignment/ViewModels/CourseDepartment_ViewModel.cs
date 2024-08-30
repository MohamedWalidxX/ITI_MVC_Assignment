using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ITI_MVC_Asssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.ViewModels;

//[MetadataType(typeof(Course))]
public class CourseDepartment_ViewModel
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Enter your name")]
    [StringLength(maximumLength:50, ErrorMessage = "Your name must not exceed 30 letters")]
    [MinLength(2, ErrorMessage = "Your name must be at least two letters")]
    [DisplayName("Name")]
    [Remote(action: "IsUnique", controller: "Course", ErrorMessage ="Your name is not unique", AdditionalFields ="Id")]
    public String Name { get; set; }

    [Required(ErrorMessage = "Enter the degree of the course")]
    [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
    [DisplayName("Degree")]
    public double Degree { get; set; }

    [Required(ErrorMessage ="Enter the minimum degree of the course")]
    [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
    [DisplayName("Minimum Degree")]
    public double  MinimumDegree { get; set; }

    [Required(ErrorMessage ="Select the course department")]
    [Range(1, double.MaxValue, ErrorMessage = "Choose the course department")]
    [DisplayName("Course Department")]
    public int DepartmentId { get; set; }
    public IEnumerable<Department> AllDepartments { get; set; }
}
