namespace ITI_MVC_Asssignment.Models;

public class Department{
    public int Id { get; set; }
    public String Name { get; set; }
    public List<Instructor> Instructors { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public List<Student> Students { get; set; }

}