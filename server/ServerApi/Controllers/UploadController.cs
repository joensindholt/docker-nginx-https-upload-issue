using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServerApi.Controllers
{
    [Route("")]
    public class UploadController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Upload endpoint is live. Post your file...");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post()
        {
            var buffer = new byte[4 * 1024];
            var readBytes = 0;
            int totalBytes = 0;
            int intervalBytes = 0;
            int logInterval = 1024 * 1024; // 1MB

            while ((readBytes = Request.Body.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytes += readBytes;
                intervalBytes += readBytes;

                if (intervalBytes >= logInterval)
                {
                    Console.WriteLine($"Read {readBytes:N0} bytes with a total of {totalBytes:N0} bytes from input stream");
                    intervalBytes = 0;
                }
            }

            return Ok("Upload received");
        }
    }
}
