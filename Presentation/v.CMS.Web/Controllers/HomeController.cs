using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using v.CMS.Core.Domain;
using v.CMS.Services.Posts;

namespace v.CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly IPostService _postService;
        #endregion

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var post = _postService.GetById(1);
            return Content(post.Title);
        }
    }
}