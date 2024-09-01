using System;
using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Asssignment.Repository;

public interface ICourseRepository
{
    public AppDbContext context { get; set; }
    public Course GetById(int id);
    public Course GetByName(string name);
    public IEnumerable<Course> GetAll();
    public void Insert(Course course);
    public void Update(Course course);
    public void Remove(Course course);

}
