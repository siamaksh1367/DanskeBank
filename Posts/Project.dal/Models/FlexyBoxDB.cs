using Project.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Project.dal.Models
{
    public class ProjectDB : DbContext
    {
        private readonly IOptions<SQLConnectionString>? _option;
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public ProjectDB(DbContextOptions<ProjectDB> options, IOptions<SQLConnectionString>? option = null) : base(options)
        {
            _option = option;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_option is not null)
            {
                optionsBuilder.UseSqlServer(_option?.Value.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Posts).UsingEntity(
                    "PostTag",
                    l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId").HasPrincipalKey(nameof(Tag.Id)),
                    r => r.HasOne(typeof(Post)).WithMany().HasForeignKey("PostId").HasPrincipalKey(nameof(Post.Id)),
                    j => j.HasKey("PostId", "TagId")
                );

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(X => X.PostId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
