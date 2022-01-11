using MainAPI.Business.DarlosValley;
using MainAPI.Models.DarlosValley;
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
    public class ImageSetController : ControllerBase
    {
        ImageSetBusiness _imageSetBusiness;
        JWTService _jwtService;

        public ImageSetController(ImageSetBusiness imageSetBusiness, JWTService jWTService)
        {
            _imageSetBusiness = imageSetBusiness;
            _jwtService = jWTService;
        }

        [HttpGet("Get")]

        public async Task<ActionResult> Get()
        {
            return Ok(await _imageSetBusiness.Get());
        }
        [HttpGet("GetByLocation")]

        public async Task<ActionResult> GetByLocation(string location)
        {
            return Ok(await _imageSetBusiness.GetByLocation(location));
        }

        [HttpGet("GetImageWithLocationByEditor")]

        public async Task<ActionResult> GetImageWithLocationByEditor(string location)
        {
            return Ok(await _imageSetBusiness.GetImageWithLocationByEditor(location));
        }

        // POST: api/CP
        [HttpPost("Post")]
        public async Task<ActionResult> Post([FromBody] ImageSet imageSet)
        {

            return Ok(await _imageSetBusiness.Create(imageSet));
        }

        // GET: api/CP/5
        [HttpGet("GetByID")]
        public async Task<ActionResult> GetByID(Guid id)
        {
            return Ok(await _imageSetBusiness.GetByID(id));
        }

        // PUT: api/CP/5
        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] ImageSet imageSet)
        {
            return Ok(await _imageSetBusiness.Update(imageSet));
        }

        [HttpGet("Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _imageSetBusiness.Delete(id));
        }

    }
}
