namespace ITI_MVC_Asssignment.Models;

public class CourseResult{
    public int Id { get; set; }
    public double Degree { get; set; }
    public int StudentId { get; set; }
    public Student StudentNavigation { get; set; }
    public int CourseId { get; set; }
    public Course CourseNavigation { get; set; }

}

