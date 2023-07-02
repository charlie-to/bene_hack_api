
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bene_hack_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bene_hack_api.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : Controller
    {
        // 初期値
        private List<User> users = new List<User>()
        {
            new User(){id=0,username="a",password=1234},
            new User(){id=1,username="大槻翼",password=1234},
            new User(){id=2,username="田中健太郎",password=1234},
            new User(){id=3,username="谷サン",password=1234},
            new User(){id=4,username="岡村穂香",password=1234}
        };

        // GET: api/values
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = users.Find(_user => _user.id == id);
            if(user == null) { return NotFound(); }
            return user;
        }
    }
}

