using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace OnlineShoppingStore.Models
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentity(context);
            base.Seed(context);
        }

        public void InitializeIdentity(ApplicationDbContext db)
        {

            var userManager = new UserManager<MyIdentity>(new UserStore<MyIdentity>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var name = "Admin@Admin.com";
            var password = "Admin@Admin";
            var roleName = "Admin";


            var user = new MyIdentity();
            user.UserName = name;
            user.Email = name;

            var isUserExist = userManager.FindByName(user.UserName);

            if (isUserExist == null)
            {
                var result = userManager.Create(user, password);
            }


            var isRoleExist = roleManager.FindByName(roleName);
            if (isRoleExist == null)
            {

                isRoleExist = new IdentityRole(roleName);
                var result = roleManager.Create(isRoleExist);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(isRoleExist.Name))
            {
                var result = userManager.AddToRole(user.Id, isRoleExist.Name);

            }

        }
    }
}