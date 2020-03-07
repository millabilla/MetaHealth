using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MetaHealth.DAL;
using System.Collections.Generic;

namespace MetaHealth.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<MoodsInBetween> MoodsInBetweens { get; set; }//creates a navigation property to MoodsInBetween.cs
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser() //constructor initializes navigation property
        {
            MoodsInBetweens = new HashSet<MoodsInBetween>();
        }
    }
  

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AzureDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //creating access between this table and our MoodsInBetween table
        public virtual DbSet<MoodsInBetween> MoodsInBetweens { get; set; }

        //Configure mapping between Identy context and user tables
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.MoodsInBetweens)
                .WithRequired(e => e.ApplicationUser)
                .HasForeignKey(e => e.FK_UserTable);
        }

    }
}
