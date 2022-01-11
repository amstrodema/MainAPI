using MainAPI.Business.CP;
using MainAPI.Business.DarlosValley;
using MainAPI.Models.CP;
using MainAPI.Models.DarlosValley;
using MainAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using MainAPI.Services;

namespace MainAPI.Controllers.CP
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPController : ControllerBase
    {
        UserBusiness _userBusiness;
        BlogBusiness _BlogBusiness;
        WorkBusiness _WorkBusiness;
        JWTService _jwtService;


        public CPController(WorkBusiness workBusiness, JWTService jWTService, UserBusiness userBusiness, BlogBusiness blogBusiness)
        {
            _jwtService = jWTService;
            _userBusiness = userBusiness;
            _BlogBusiness = blogBusiness;
            _WorkBusiness = workBusiness;
        }

        // GET: api/CP
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userBusiness.GetUsers());
        }
        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterParams registerParams)
        {
              return Ok(await _userBusiness.Create(registerParams.User, registerParams.Person));
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUser([FromBody] LogInParams logInParams)
        {
            return Ok(await _userBusiness.VerifyUser(logInParams));
        }


        /*
        * 
        * 
        * 
        * 
        Darlos Blog
        * 
        * 
        * 
        * 
        * 
        */

        [HttpGet("GetDarlosBlogPosts")]

        public async Task<ActionResult> GetDarlosBlogPosts()
        {
            return Ok(await _BlogBusiness.GetBlogs());
        }



        // GET: api/CP/5
        [HttpGet("GetDarlosBlogPost")]
        public async Task<ActionResult> GetDarlosBlogPost(Guid id)
        {
            return Ok(await _BlogBusiness.GetBlogByID(id, "Admin"));
        }

        // POST: api/CP
        [HttpPost("PostInDarlosBlog")]
        public async Task<ActionResult> PostInDarlosBlog([FromBody] Blog blog)
        {

            return Ok(await _BlogBusiness.Create(blog));
        }

        // PUT: api/CP/5
        [HttpPut("PutInDarlosBlog")]
        public async Task<ActionResult> PutInDarlosBlog([FromBody] Blog blog)
        {
            return Ok(await _BlogBusiness.Update(blog));
        }


        // DELETE: api/CP/5
        [HttpGet("DeleteDarlosBlog")]
        public async Task<ActionResult> DeleteDarlosBlog(Guid id)
        {
            return Ok(await _BlogBusiness.Delete(id));
        }
        /*
         * 
         * 
         * 
         * 
         Darlos Work
         * 
         * 
         * 
         * 
         * 
         */
        [HttpGet("GetWorks")]

        public async Task<ActionResult> GetWorks()
        {
           return Ok(await _WorkBusiness.GetWorks());
        }

        // GET: api/CP/5
        [HttpGet("GetWork")]
        public async Task<ActionResult> GetWork(Guid id)
        {
            return Ok(await _WorkBusiness.GetWorkByID(id, "Admin"));
        }

        [HttpPost("PostInDarlosWork")]
        public async Task<ActionResult> PostInDarlosWork([FromBody] Work work)
        {
            return Ok(await _WorkBusiness.Create(work));
        }

        // PUT: api/CP/5
        [HttpPut("PutInDarlosWork")]
        public async Task<ActionResult> PutInDarlosWork([FromBody] Work work)
        {
            return Ok(await _WorkBusiness.Update(work));
        }


        // DELETE: api/CP/5
        [HttpGet("DeleteDarlosWork")]
        public async Task<ActionResult> DeleteDarlosWork(Guid id)
        {
            return Ok(await _WorkBusiness.Delete(id));
        }

    }
}
