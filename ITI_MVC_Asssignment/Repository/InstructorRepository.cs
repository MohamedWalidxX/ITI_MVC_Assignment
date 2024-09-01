using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;

namespace ITI_MVC_Asssignment.Repository;

public class InstructorRepository : IInstructorRepository
{
    public AppDbContext context { get; set; }
    public InstructorRepository(AppDbContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Instructor> GetAll() => context.Instructors;

    public Instructor GetById(int id) => context.Instructors.FirstOrDefault(i => i.Id == id)!;

    public Instructor GetByName(string name) => context.Instructors.FirstOrDefault(i => i.Name == name)!;

    public void Insert(Instructor instructor)
    {
        context.Instructors.Add(instructor);
        context.SaveChanges();
    }

    public void Remove(Instructor instructor)
    {
        context.Instructors.Remove(instructor);
        context.SaveChanges();
    }

    public void Update(Instructor instructor)
    {
        Instructor target = context.Instructors.FirstOrDefault(i => i.Id == instructor.Id)!;
        target.Name = instructor.Name;
        target.Salary = instructor.Salary;
        target.Image = instructor.Image;
        target.DepartmentId = instructor.DepartmentId;
        target.CourseId = instructor.CourseId;
        target.Address = instructor.Address;
        context.SaveChanges();
    }
}
