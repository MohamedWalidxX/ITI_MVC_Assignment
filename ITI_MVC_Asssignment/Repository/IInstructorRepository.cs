using System;
using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;

namespace ITI_MVC_Asssignment.Repository;

public interface IInstructorRepository
{
    public AppDbContext context { get; set; }
    public Instructor GetById(int id);
    public Instructor GetByName(string name);
    public IEnumerable<Instructor> GetAll();
    public void Insert(Instructor instructor);
    public void Update(Instructor instructor);
    public void Remove(Instructor instructor);


}
