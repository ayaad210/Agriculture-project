using Agriculture_projectv1.Models;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agriculture_projectv1.Startup))]
namespace Agriculture_projectv1
{
    public partial class Startup
    {
        ApplicationDbContext db = new Models.ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateRoles();
            CreateUsers();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CrossType, CrossTypeViewModel>();
                cfg.CreateMap<CrossTypeViewModel, CrossType>();

            });
          
        }
        public void CreateUsers()
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            ApplicationUser user = new ApplicationUser();
            user.Email = "Ayaad210@gmail.com";
            user.UserName = "Ayaad210@gmail.com";
            user.Name = "MasterAdmin";
            var check = userManager.Create(user, "As123+");
            if (check.Succeeded)
            {
                userManager.AddToRoles(user.Id, "Admins");
            }



        }


        public void CreateRoles()
        {
            var rolemanegaer = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!rolemanegaer.RoleExists("Admins"))
            {
                rolemanegaer.Create(new IdentityRole() { Name = "Admins" });
            }
            if (!rolemanegaer.RoleExists("Teachers"))
            {
                rolemanegaer.Create(new IdentityRole() { Name = "Visitors" });
            }

        }





    }
}

