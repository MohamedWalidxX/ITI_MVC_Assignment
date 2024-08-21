using System;

namespace ITI_MVC_Asssignment.Models;

public class Course
{
    public int Id { get; set; }
    public String Name { get; set; } 
    public double Degree { get; set; }
    public double MinimumDegree { get; set; }
    public List<Instructor> Instructors { get; set; }
    public int DepartmentId { get; set; } 
    public Department? DepartmentNavigation { get; set; }
    public List<CourseResult> CourseResults { get; set; }
}
