using System;
using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;

namespace ITI_MVC_Asssignment.Repository;

public interface IDepartmentRepository
{
    public AppDbContext context { get; set; }
    public Department GetById(int id);
    public Department GetByName(string name);
    public IEnumerable<Department> GetAll();
    public void Insert(Department department);
    public void Update(Department department);
    public void Remove(Department department);

}
