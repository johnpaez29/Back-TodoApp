using Microsoft.EntityFrameworkCore;

namespace ToDoServiceApp.DataService.ModelsSql;

public partial class ToDoContext : DbContext
{
    public ToDoContext()
    {
    }

    public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<TodoObject> TodoObjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.IdTodoItem).HasName("PK__TodoItem__079C7BEFF09BD65F");

            entity.Property(e => e.IdTodoItem).HasColumnName("idTodoItem");
            entity.Property(e => e.IdTodoObject).HasColumnName("idTodoObject");
            entity.Property(e => e.IsCheck).HasColumnName("isCheck");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdTodoObjectNavigation).WithMany(p => p.TodoItems)
                .HasForeignKey(d => d.IdTodoObject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TodoItems__idTod__4222D4EF");
        });

        modelBuilder.Entity<TodoObject>(entity =>
        {
            entity.HasKey(e => e.IdTodoObject).HasName("PK__TodoObje__16F3AD563B02C9F9");

            entity.Property(e => e.IdTodoObject).HasColumnName("idTodoObject");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
