namespace ITI_MVC_Asssignment.Models;

public class Student{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Image { get; set; }
    public double Grade { get; set; }
    public int DepartmentId { get; set; }
    public Department DepartmentNavigation { get; set; }
    public List<CourseResult> CoursesResults { get; set; }
    
}
