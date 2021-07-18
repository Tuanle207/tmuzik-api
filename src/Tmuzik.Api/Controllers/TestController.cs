using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tmuzik.Services;


namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ILogger<TestController> _logger;

        public TestController(ITestService testService, ILogger<TestController> logger)
        {
            _testService = testService;
            _logger = logger;
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestApi()
        {
            return Ok(await _testService.TestApi());
        }
        [HttpGet("stream")]
        public async Task<IActionResult> StreamMusic(CancellationToken cancellationToken)
        {
            var range = this.HttpContext.Request.Headers["Range"].ToString();
            _logger.LogInformation("Range:");
            _logger.LogInformation(range);

            if (String.IsNullOrEmpty(range))
            {
                return BadRequest(new {
                    message = "Range header required!"
                });
            }

            var fs = System.IO.File.Open(@"D:\storage\sources\Web\nodejs-streaming\audio.flac", FileMode.Open);
            using (var reader = new BinaryReader(fs))
            {
                // Parse range: "Byte=32334-"
                var videoSize = fs.Length;
                var CHUNK_SIZE = (int)Math.Pow(10, 6); // 1MB;
                var start = Int32.Parse(Regex.Replace(range, "[^0-9]", ""));
                var end = ((int)Math.Min(start + CHUNK_SIZE, videoSize - 1));
                var contentLength = end - start + 1;

                reader.BaseStream.Seek(start, SeekOrigin.Begin);
                byte[] buffer = reader.ReadBytes(CHUNK_SIZE);

                HttpContext.Response.Headers.Add("Content-Range", $"bytes {start}-{end}/{videoSize}");
                HttpContext.Response.Headers.Add("Accept-Ranges", "bytes");
                HttpContext.Response.Headers["Content-Length"] = buffer.Length.ToString();
                HttpContext.Response.Headers.Add("Content-Type", "audio/flac");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.PartialContent;
                await HttpContext.Response.Body.WriteAsync(buffer, cancellationToken);
            }

            return new EmptyResult();
        }

    }
}