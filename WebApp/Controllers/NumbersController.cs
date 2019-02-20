using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AKQA.BL;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Numbers")]
    public class NumbersController : Controller
    {
        [Route("ToWords")]
        [HttpGet]
        public IActionResult ConvertToWords(string number)
        {
            var obj = Numbers.Convert<string>(number);

            var result = new ContentResult();
            result.Content = obj.ToString();
            return result;
        }
    }
}