using ITI_MVC_Asssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_MVC_Asssignment.Data.Config;

public class CourseResultConfig : IEntityTypeConfiguration<CourseResult>
{
public void Configure(EntityTypeBuilder<CourseResult> builder)
    {
        builder.HasOne(cr => cr.StudentNavigation).WithMany(s => s.CoursesResults).HasForeignKey(cr => cr.StudentId).IsRequired();
        builder.HasOne(cr => cr.CourseNavigation).WithMany(c => c.CourseResults).HasForeignKey(cr => cr.CourseId).IsRequired();
    }
}