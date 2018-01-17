using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using v.CMS.Core;
using v.CMS.Core.Domain.Posts;
using v.CMS.Services.Posts;

namespace v.CMS.Admin.Controllers
{
    public class NewsController : BaseAdminController
    {
        #region Fields

        private IPostService _postService;

        #endregion

        #region Ctor

        public NewsController(IPostService postService)
        {
            _postService = postService;
        }

        #endregion

        #region Utilities

        [NonAction]
        protected virtual void PreparePostModel(Post model)
        {

        }

        #endregion

        public virtual ActionResult Create()
        {
            var model = new Post();

            PreparePostModel(model);

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Create(Post model, bool continueEditing = false)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}