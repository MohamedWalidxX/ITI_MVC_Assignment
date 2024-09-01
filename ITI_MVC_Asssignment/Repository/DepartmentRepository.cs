using System;
using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;

namespace ITI_MVC_Asssignment.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    public AppDbContext context { get ;  set ; }

    public DepartmentRepository(AppDbContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<Department> GetAll() => context.Departments;

    public Department GetById(int id) => context.Departments.FirstOrDefault(d => d.Id == id)!;

    public Department GetByName(string name) => context.Departments.FirstOrDefault(d => d.Name == name)!;

    public void Insert(Department department) {
        context.Departments.Add(department);
        context.SaveChanges();
    }

    public void Remove(Department department) {
        context.Departments.Remove(department);
        context.SaveChanges();
    }

    public void Update(Department department)
    {
        Department target = context.Departments.FirstOrDefault(d => d.Id == department.Id)!;
        target.Name = department.Name;
        context.SaveChanges();

    }
}
