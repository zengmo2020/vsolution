using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using v.CMS.Core.Data;
using v.CMS.Core.Domain.Posts;

namespace v.CMS.Services.Posts
{
    public partial class PostService : IPostService
    {
        #region Fields
        private readonly IRepository<Post> _postRepository;
        #endregion

        #region Ctor
        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        #endregion

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }
    }
}
