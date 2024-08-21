using ITI_MVC_Asssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI_MVC_Asssignment.Data.Config;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasOne(s => s.DepartmentNavigation).WithMany(dep => dep.Students).HasForeignKey(s => s.DepartmentId).IsRequired();
    }
}
