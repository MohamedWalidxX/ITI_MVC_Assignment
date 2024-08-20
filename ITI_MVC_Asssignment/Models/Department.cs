namespace ITI_MVC_Asssignment.Models;

public class Department{
    public int Id { get; set; }
    public String Name { get; set; }
    public Instructor Manager { get; set; }
}