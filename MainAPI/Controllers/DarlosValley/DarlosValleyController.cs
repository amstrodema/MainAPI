using MainAPI.Business.CP;
using MainAPI.Business.DarlosValley;
using MainAPI.Models;
using MainAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainAPI.Controllers.DarlosValley
{
    [Route("api/[controller]")]
    [ApiController]
    public class DarlosValleyController : ControllerBase
    {

        BlogBusiness _BlogBusiness;
        WorkBusiness _WorkBusiness;
        JWTService _jwtService;
        EmailService _emailService;

        public DarlosValleyController(BlogBusiness blogBusiness, JWTService jWTService, WorkBusiness workBusiness, EmailService emailService)
        {
            _BlogBusiness = blogBusiness;
            _jwtService = jWTService;
            _WorkBusiness = workBusiness;
            _emailService = emailService;
        }

        [HttpGet("GetBlogs")]

        public async Task<ActionResult> GetBlogs()
        {
            var result = await _BlogBusiness.GetBlogs();
           return Ok(result);
        }

        [HttpGet("GetHomeData")]
        public async Task<ActionResult> GetHomeData()
        {
           return Ok(await _BlogBusiness.GetHomeData());
        }

        [HttpGet("GetDarlosBlogPost_Limited")]
        public async Task<ActionResult> GetDarlosBlogPost_Limited()
        {
           return Ok(await _BlogBusiness.GetBlogs_Limited());
        }
        // GET: api/CP/5
        [HttpGet("GetBlog")]
        public async Task<ActionResult> GetBlog(Guid id)
        {
            return Ok(await _BlogBusiness.GetBlogByID(id, "User"));
        }
        [HttpGet("Like")]
        public async Task<ActionResult> Like(Guid id)
        {
            return Ok(await _BlogBusiness.Like(id));
        }

        //Work

        [HttpGet("GetWorks")]

        public async Task<ActionResult> GetWorks()
        {
            return Ok(await _WorkBusiness.GetWorks());
        }
        [HttpGet("GetDarlosWorkPost_Limited")]
        public async Task<ActionResult> GetDarlosWorkPost_Limited()
        {
            return Ok(await _WorkBusiness.GetWorks_Limited());
        }
        // GET: api/CP/5
        [HttpGet("GetWork")]
        public async Task<ActionResult> GetWork(Guid id)
        {
            return Ok(await _WorkBusiness.GetWorkByID(id, "User"));
        }

        [HttpGet("LikeWork")]
        public async Task<ActionResult> LikeWork(Guid id)
        {
            return Ok(await _WorkBusiness.Like(id));
        }
        [HttpGet("RecieveContactMessage")]
        public async Task<ActionResult> RecieveContactMessage(Email email)
        {
           await _emailService.Send(email);
            return Ok();
        }
    }
}
