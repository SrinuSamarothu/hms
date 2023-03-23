
using Microsoft.EntityFrameworkCore;


namespace FluentApi.Entities;

public partial class AvailabilityScheduleContext : DbContext
{
    public AvailabilityScheduleContext()
    {
    }

    public AvailabilityScheduleContext(DbContextOptions<AvailabilityScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__doctor_s__E5AB9877AA5DE297");

            entity.ToTable("doctor_schedule");

            entity.Property(e => e.DoctorId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("Doctor_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
