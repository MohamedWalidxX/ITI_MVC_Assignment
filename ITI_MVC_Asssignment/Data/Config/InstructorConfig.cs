using ITI_MVC_Asssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_MVC_Asssignment.Data.Config;

public class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasOne(i => i.DepartmentNavigation).WithMany(d => d.Instructors).HasForeignKey(i => i.DepartmentId).IsRequired();
        builder.HasOne(i => i.CourseNavigation).WithMany(c => c.Instructors).HasForeignKey(i => i.CourseId).IsRequired();
    }

}
