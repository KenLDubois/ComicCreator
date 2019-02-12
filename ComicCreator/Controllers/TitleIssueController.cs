using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ComicCreator.Controllers
{
    public class TitleIssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}