using System;
using ITI_MVC_Asssignment.Data;
using ITI_MVC_Asssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Asssignment.Repository;

public class CourseRepository : ICourseRepository
{
    public AppDbContext context { get ; set; }
    public CourseRepository(AppDbContext dbContext)
    {
        context = dbContext;
    }
    public Course GetById(int id) => context.Courses.FirstOrDefault(c => c.Id == id)!;
    

    public void Insert(Course course) {
        context.Courses.Add(course);
        context.SaveChanges();
    } 

    public void Remove(Course course) {
        context.Courses.Remove(course);
        context.SaveChanges();
    }

    public void Update(Course course)
    {
        Course target = context.Courses.FirstOrDefault(c => c.Id == course.Id)!;
        target.Name = course.Name;
        target.Degree = course.Degree;
        target.MinimumDegree = course.MinimumDegree;
        target.DepartmentId = course.DepartmentId;
        context.SaveChanges();
    }

    public IEnumerable<Course> GetAll() => context.Courses;

    public Course GetByName(string name) => context.Courses.FirstOrDefault(c => c.Name == name)!;
}
