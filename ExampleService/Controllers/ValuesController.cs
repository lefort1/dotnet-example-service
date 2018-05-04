using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace ExampleService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static List<string> stringBucket = new List<string>();
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return stringBucket;
        }

        // GET api/values/5
        [HttpGet("content")]
        public string GetFileContent([FromQuery (Name = "filePath")] string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Console.WriteLine("Hello, I'm the POST request");
            Console.WriteLine("Value is " + value);
            stringBucket.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
