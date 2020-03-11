using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AppServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly IUrlShorteningService _service;
        public ShortUrlController(IUrlShorteningService service)
        {
            _service = service;
        }


        [HttpGet("Create")]
        public ActionResult<string> CreateUrl(string url)
        {
            try
            {
                var resp = _service.CreateUrl(url);
                return Ok(resp.ToString());
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpGet("Resolve")]
        public ActionResult<string> ResolveUrl(string url)
        {
            try
            {
                var resp = _service.GetUrl(url);
                return Ok(resp.ToString());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}