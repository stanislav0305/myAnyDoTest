using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyDo.WebAPI.Models.CurrentUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnyDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CurrentUserController : Controller
    {
        // GET: api/currentUser
        [HttpGet]
        public CurrentUserApiModel Get()
        {
            return new CurrentUserApiModel() {
                FirstName = "TestFirstName"
            };
        }
    }
}
