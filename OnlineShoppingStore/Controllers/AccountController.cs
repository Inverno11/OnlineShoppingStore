using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShoppingStore.Models;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{

    public class AccountController : Controller
    {


        private readonly UserManager<MyIdentity> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly RoleManager<IdentityRole> roleManager;

       public AccountController()
        {
            dbContext = new ApplicationDbContext();
            var userStore = new UserStore<MyIdentity>(dbContext);
            userManager = new UserManager<MyIdentity>(userStore);
            var roleStore = new RoleStore<IdentityRole>(dbContext);
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            
            new LoginViewModel()
            { ReturnUrl = ReturnUrl };
            return View
                (
             new LoginViewModel() { ReturnUrl = ReturnUrl }

                );


        }


        [HttpPost]
          public ActionResult login(LoginViewModel model)
            {
            


               var isexist = userManager.Find(model.Email, model.Password);
            if (isexist != null)
            {
                SignIn(isexist);

                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {

                    return Redirect(model.ReturnUrl);

                }
                else
                {
                    return RedirectToAction("Index","Home");
                }

            }
            else
            {
                return HttpNotFound("no found");
            }

        }

    


        public void SignIn(MyIdentity identity)
        {
            var user = userManager.CreateIdentity(identity,DefaultAuthenticationTypes.ApplicationCookie);
            var owinContext = HttpContext.Request.GetOwinContext();
            var owinAuth = owinContext.Authentication;
            owinAuth.SignIn(user);


        }

    }

}

    
