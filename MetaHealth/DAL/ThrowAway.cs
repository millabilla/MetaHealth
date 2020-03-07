namespace MetaHealth.DAL {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    /// <summary>
    /// This particular context will most likely not be needed and was generated so that we could get some model classes from our
    /// for interacting with AspNetUsers database
    /// </summary>
    public partial class ThrowAway : DbContext {
        public ThrowAway()
            : base("name=ThrowAway") {
        }

        public virtual DbSet<APIToDoList> APIToDoLists { get; set; }
        public virtual DbSet<CustomLevel> CustomLevels { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Mood> Moods { get; set; }
        public virtual DbSet<MoodsInBetween> MoodsInBetweens { get; set; }
        public virtual DbSet<PreLevelList> PreLevelLists { get; set; }
        public virtual DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<List>()
                .HasMany(e => e.APIToDoLists)
                .WithRequired(e => e.List)
                .HasForeignKey(e => e.FK_List)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<List>()
                .HasMany(e => e.CustomLevels)
                .WithRequired(e => e.List)
                .HasForeignKey(e => e.FK_List)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<List>()
                .HasMany(e => e.ToDoLists)
                .WithRequired(e => e.List)
                .HasForeignKey(e => e.FK_List)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MoodsInBetween>()
                .HasMany(e => e.Moods)
                .WithRequired(e => e.MoodsInBetween)
                .HasForeignKey(e => e.FK_MoodsInBetween)
                .WillCascadeOnDelete(false);
        }
    }
}
