using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using sauemk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sauemk.Controllers
{

    public class RoleManagerController : ApiController
    {

        ApplicationDbContext context = new ApplicationDbContext();
        // POST: RoleManager/addRole
        [HttpPost]
        [Route("rolemanager/addrole")]
        public IHttpActionResult addRole(RoleAddModel role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (roleManager.RoleExists(role.roleName) == false)
            {

                try
                {
                    var sa = roleManager.Create(new IdentityRole(role.roleName));
                    if (sa.Succeeded == true)
                    {
                        return Ok(sa);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return Conflict();
        }
        [HttpPost]
        [Route("rolemanager/addUserRoles")]
        public IHttpActionResult addUserRoles(UserRolesModel role)
        {
            ApplicationUser user;
            IdentityResult result;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            try
            {
                user = userManager.FindByName(role.UserName);
            }
            catch (Exception)
            {
                return BadRequest("Kullanıcı bulunamadı");
            }

            if (!userManager.IsInRole(user.Id, role.RoleName))
            {
                result = userManager.AddToRole(user.Id.ToString(), role.RoleName);
            }
            else
            {
                return Conflict();
            }
            if (result.Succeeded == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
