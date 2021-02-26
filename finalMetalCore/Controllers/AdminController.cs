using finalMetalCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalMetalCore.Controllers
{
    public class AdminController : Controller
    {

        private readonly RoleManager<IdentityRole> rolemanager;

        public AdminController(RoleManager<IdentityRole> rolemanager)
        {
            this.rolemanager = rolemanager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(projectRoles role)
        {
            var roleExist = await rolemanager.RoleExistsAsync(role.roleName);
            if (!roleExist)
            {
                var result = await rolemanager.CreateAsync(new IdentityRole(role.roleName));
            }

            return View();
        }
    }
}
