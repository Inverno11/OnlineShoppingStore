using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace OnlineShoppingStore.Models
{
    public class ApplicationDbContext : IdentityDbContext<MyIdentity>
    {
        public ApplicationDbContext()
            : base("default")
        {

        }


        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());

        }

        /*  public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

          public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

          public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

          public virtual DbSet<AspNetUser> AspNetUsers { get; set; }*/

    }

    public class MyIdentity : IdentityUser
    {


    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    /*
    public partial class AspNetRole
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetRole()
        {

            this.AspNetUsers = new HashSet<AspNetUser>();

        }


        public string Id { get; set; }

        public string Name { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }

    }


    public partial class AspNetUser
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUser()
        {

            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();

            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();

            this.AspNetRoles = new HashSet<AspNetRole>();

        }


        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }

    }
    public partial class AspNetUserClaim
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }



        public virtual AspNetUser AspNetUser { get; set; }

    }


    public partial class AspNetUserLogin
    {

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string UserId { get; set; }



        public virtual AspNetUser AspNetUser { get; set; }

    }
    */

}