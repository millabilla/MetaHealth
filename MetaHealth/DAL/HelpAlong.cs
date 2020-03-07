namespace MetaHealth.Models {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HelpAlong : DbContext {
        public HelpAlong()
            : base("name=HelpAlong") {
        }

        public virtual DbSet<APIToDoList> APIToDoLists { get; set; }
        public virtual DbSet<CustomLevel> CustomLevels { get; set; }
        public virtual DbSet<HelpAlongUser> HelpAlongUsers { get; set; }
        public virtual DbSet<Mood> Moods { get; set; }
        public virtual DbSet<PreLevelList> PreLevelLists { get; set; }
        public virtual DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<HelpAlongUser>()
                .HasMany(e => e.APIToDoLists)
                .WithRequired(e => e.HelpAlongUser)
                .HasForeignKey(e => e.UserNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HelpAlongUser>()
                .HasMany(e => e.CustomLevels)
                .WithRequired(e => e.HelpAlongUser)
                .HasForeignKey(e => e.UserNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HelpAlongUser>()
                .HasMany(e => e.Moods)
                .WithRequired(e => e.HelpAlongUser)
                .HasForeignKey(e => e.UserNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HelpAlongUser>()
                .HasMany(e => e.ToDoLists)
                .WithRequired(e => e.HelpAlongUser)
                .HasForeignKey(e => e.UserNum)
                .WillCascadeOnDelete(false);
        }
    }
}
