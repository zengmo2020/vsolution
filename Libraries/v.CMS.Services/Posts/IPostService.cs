using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using v.CMS.Core;
using v.CMS.Core.Domain.Posts;

namespace v.CMS.Services.Posts
{
    /// <summary>
    /// post service
    /// </summary>
    public partial interface IPostService
    {
        /// <summary>
        /// Gets a post
        /// </summary>
        /// <param name="id">The news identifier</param>
        /// <returns>News</returns>
        Post GetById(int id);
    }
}
