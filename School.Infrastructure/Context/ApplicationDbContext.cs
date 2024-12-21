namespace School.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSet Properties
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }
        public DbSet<SubjectMaterial> SubjectMaterials { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyGlobalConfigurations(modelBuilder);
            ConfigureEntities(modelBuilder);
            ConfigureRelationships(modelBuilder);
        }

        #region Configuration Methods
        private void ApplyGlobalConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyGlobalFilters<BaseEntity>(e => !e.IsDeleted);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name, "School");

                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    ConfigureBaseEntityProperties(modelBuilder, entityType.ClrType);
                }
            }
        }

        private void ConfigureBaseEntityProperties(ModelBuilder modelBuilder, Type entityType)
        {
            modelBuilder.Entity(entityType)
                .Property(nameof(BaseEntity.CreatedAt))
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity(entityType)
                .Property(nameof(BaseEntity.Status))
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity(entityType)
                .Property(nameof(BaseEntity.Metadata))
                .HasColumnType("nvarchar(max)");
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            ConfigureSubject(modelBuilder);
            ConfigureStudent(modelBuilder);
            ConfigureDepartment(modelBuilder);
            ConfigureJoinEntities(modelBuilder);
        }

        private void ConfigureSubject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(builder =>
            {
                builder.ToTable("Subjects");
                builder.HasKey(s => s.Id);

                // Basic Properties
                builder.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(s => s.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(20);

                builder.Property(s => s.Description)
                    .HasMaxLength(500);

                // Academic Properties
                builder.Property(s => s.CreditHours)
                    .IsRequired();

                builder.Property(s => s.Semester)
                    .HasMaxLength(20);

                builder.Property(s => s.PassingGrade)
                    .HasDefaultValue(50);

                // Schedule Properties
                builder.Property(s => s.ClassDays)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(d => Enum.Parse<DayOfWeek>(d))
                            .ToArray());

                // Indexes
                builder.HasIndex(s => s.SubjectCode)
                    .IsUnique();

                // Relationships
                builder.HasOne(s => s.PrerequisiteSubject)
                    .WithMany(s => s.DependentSubjects)
                    .HasForeignKey(s => s.PrerequisiteSubjectId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(s => s.SubjectMaterials)
                    .WithOne(m => m.Subject)
                    .HasForeignKey(m => m.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(builder =>
            {
                builder.ToTable("Students");
                builder.HasKey(s => s.Id);

                // Personal Information
                builder.Property(s => s.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(s => s.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(s => s.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                // Academic Information
                builder.Property(s => s.GPA)
                    .HasColumnType("decimal(3,2)");

                // Indexes
                builder.HasIndex(s => s.Email)
                    .IsUnique();

                builder.HasIndex(s => s.StudentId)
                    .IsUnique();

                builder.HasIndex(s => s.NationalId)
                    .IsUnique()
                    .HasFilter("[NationalId] IS NOT NULL");
            });
        }

        private void ConfigureDepartment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(builder =>
            {
                builder.ToTable("Departments");
                builder.HasKey(d => d.Id);

                builder.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(d => d.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(20);

                builder.HasIndex(d => d.DepartmentCode)
                    .IsUnique();
            });
        }

        private void ConfigureJoinEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentSubject>(builder =>
            {
                builder.HasKey(ds => new { ds.DepartmentId, ds.SubjectId });
                builder.ToTable("DepartmentSubjects");
            });

            modelBuilder.Entity<StudentSubject>(builder =>
            {
                builder.HasKey(ss => new { ss.StudentId, ss.SubjectId });
                builder.ToTable("StudentSubjects");
            });

            modelBuilder.Entity<InstructorSubject>(builder =>
            {
                builder.HasKey(ins => new { ins.InstructorId, ins.SubjectId });
                builder.ToTable("InstructorSubjects");
            });
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            ConfigureStudentRelationships(modelBuilder);
            ConfigureDepartmentRelationships(modelBuilder);
            ConfigureSubjectRelationships(modelBuilder);
        }

        private void ConfigureStudentRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(builder =>
            {
                builder.HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(s => s.StudentSubjects)
                    .WithOne(ss => ss.Student)
                    .HasForeignKey(ss => ss.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureDepartmentRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(builder =>
            {
                builder.HasMany(d => d.DepartmentSubjects)
                    .WithOne(ds => ds.Department)
                    .HasForeignKey(ds => ds.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(d => d.Instructors)
                    .WithOne(i => i.Department)
                    .HasForeignKey(i => i.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureSubjectRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(builder =>
            {
                builder.HasMany(s => s.DepartmentSubjects)
                    .WithOne(ds => ds.Subject)
                    .HasForeignKey(ds => ds.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(s => s.StudentsSubjects)
                    .WithOne(ss => ss.Subject)
                    .HasForeignKey(ss => ss.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(s => s.InstructorSubjects)
                    .WithOne(ins => ins.Subject)
                    .HasForeignKey(ins => ins.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion
    }

    #region Extensions
    public static class ModelBuilderExtensions
    {
        public static void ApplyGlobalFilters<TInterface>(
            this ModelBuilder modelBuilder,
            Expression<Func<TInterface, bool>> expression)
        {
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
                .Select(e => e.ClrType);

            foreach (var entity in entities)
            {
                var newParam = Expression.Parameter(entity);
                var newBody = ReplacingExpressionVisitor.Replace(
                    expression.Parameters.Single(),
                    newParam,
                    expression.Body);
                modelBuilder.Entity(entity).HasQueryFilter(
                    Expression.Lambda(newBody, newParam));
            }
        }
    }
    #endregion
}